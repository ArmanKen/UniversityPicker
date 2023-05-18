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
		[HttpPost("favoriteToggle/{higherEducationFacilityId}")]
		public async Task<IActionResult> FavoriteToggle(Guid higherEducationFacilityId)
		{
			return HandleResult(await Mediator.Send(new Application.FavoriteLists.FavoriteToggle.Command
			{ HigherEducationFacilityId = higherEducationFacilityId }));
		}

		[Authorize("IsGlobalAdmin")]
		[HttpPut("admin/{username}")]
		public async Task<IActionResult> ToggleUsersGlobalAdmin(string username)
		{
			return HandleResult(await Mediator.Send(new Application.Profiles.ToggleUsersGlobalAdmin.Command
			{ Username = username }));
		}
	}
}