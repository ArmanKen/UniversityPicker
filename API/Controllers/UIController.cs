using Application.DropdownLists;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class UIController : BaseApiController
	{
		[AllowAnonymous]
		[HttpGet("list")]
		public async Task<IActionResult> GetSpecialtyBases()
		{
			return HandleResult(await Mediator.Send(new List.Query()));
		}
	}
}