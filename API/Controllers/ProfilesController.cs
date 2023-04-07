using Application.Profiles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class ProfilesController : BaseApiController
	{
		[AllowAnonymous]
		[HttpGet("{username}")]
		public async Task<IActionResult> GetProfile(string username)
		{
			return HandleResult(await Mediator.Send(new Details.Query { Username = username }));
		}

		[Authorize]
		[HttpPut("update")]
		public async Task<IActionResult> Edit(Edit.Command command)
		{
			return HandleResult(await Mediator.Send(command));
		}

		[Authorize]
		[HttpGet("favoriteList")]
		public async Task<IActionResult> FavoriteList()
		{
			return HandlePagedResult(await Mediator.Send(new Application.FavoriteLists.List.Query { }));
		}


		[Authorize]
		[HttpPost("favoriteToggle/{universityId}")]
		public async Task<IActionResult> FavoriteToggle(Guid universityId)
		{
			return HandleResult(await Mediator.Send(new Application.FavoriteLists.FavoriteToggle.Command
			{ TargetUniversityId = universityId }));
		}
	}
}