using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class MenuController : BaseApiController
	{
		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> GetSpecialtyBases()
		{
			return HandleResult(await Mediator.Send(new Application.SpecialtiesBases.List.Query()));
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> GetRegions()
		{
			return HandleResult(await Mediator.Send(new Application.Region.List.Query()));
		}
	}
}