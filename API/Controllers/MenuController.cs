using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class MenuController : BaseApiController
	{
		[AllowAnonymous]
		[HttpGet("specialtyBases")]
		public async Task<IActionResult> GetSpecialtyBases()
		{
			return HandleResult(await Mediator.Send(new Application.Menu.SpecialtyBasesList.Query()));
		}

		[AllowAnonymous]
		[HttpGet("regions")]
		public async Task<IActionResult> GetRegions()
		{
			return HandleResult(await Mediator.Send(new Application.Menu.RegionsList.Query()));
		}
	}
}