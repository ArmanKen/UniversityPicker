using Application.Comments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
	public class ChatHub : Hub
	{
		private readonly IMediator _mediator;
		public ChatHub(IMediator mediator)
		{
			_mediator = mediator;
		}

		[Authorize]
		public async Task SendComment(Create.Command command)
		{
			var comment = await _mediator.Send(command);
			await Clients.Group(command.UniversirtyId.ToString())
				.SendAsync("ReceiveComment", comment.Value);
		}

		[Authorize]
		public async Task EditComment(Edit.Command command)
		{
			var comment = await _mediator.Send(command);
			await Clients.Group(command.UniversirtyId.ToString())
				.SendAsync("EditComment", comment.Value);
		}

		[Authorize]
		public async Task DeleteComment(Delete.Command command)
		{
			var comment = await _mediator.Send(command);
			await Clients.Group(command.UniversirtyId.ToString())
				.SendAsync("DeleteComment", comment.Value);
		}

		public override async Task OnConnectedAsync()
		{
			var httpContext = Context.GetHttpContext();
			var universirtyId = httpContext!.Request.Query["universirtyId"];
			await Groups.AddToGroupAsync(Context.ConnectionId, universirtyId);
			var result = await _mediator.Send(new List.Query { UniversirtyId = Guid.Parse(universirtyId) });
			await Clients.Caller.SendAsync("LoadComments", result.Value);
		}
	}
}