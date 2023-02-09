using Application.Profiles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class ProfileController : BaseApiController
	{
		[AllowAnonymous]
		[HttpGet("{username}")]
		public async Task<IActionResult> GetProfile(string username)
		{
			return HandleResult(await Mediator.Send(new Details.Query { Username = username }));
		}

		[Authorize]
		[HttpPut]
		public async Task<IActionResult> Edit(Edit.Command command)
		{
			return HandleResult(await Mediator.Send(command));
		}

		[Authorize]
		[HttpGet("selected")]
		public async Task<IActionResult> ListSelectedUniversity()
		{
			return HandleResult(await Mediator.Send(new Application.SelectedUniversities.List.Query
			{ }));
		}
	}
}