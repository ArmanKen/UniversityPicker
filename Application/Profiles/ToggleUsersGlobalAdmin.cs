using Application.Core;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Profiles
{
	public class ToggleUsersGlobalAdmin
	{
		public class Command : IRequest<Result<Unit>>
		{
			public string Username { get; set; }
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
		{
			private readonly DataContext _context;
			private readonly IUserAccessor _userAccessor;

			public Handler(DataContext context, IUserAccessor userAccessor)
			{
				_userAccessor = userAccessor;
				_context = context;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == request.Username);
				if (user == null) return Result<Unit>.Failure("Failed to update profile");
				user.IsGlobalAdmin = !user.IsGlobalAdmin;
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to update profile");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}