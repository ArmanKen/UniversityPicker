using Application.Disciplines;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class DisciplinesController : BaseApiController
	{
		[HttpGet]
		public async Task<IActionResult> GetDisciplines()
		{
			return HandleResult(await Mediator.Send(new List.Query()));
		}
	}
}