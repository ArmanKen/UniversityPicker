using Application.Specialties;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SpecialtiesController : BaseApiController
    {
		[HttpGet]
		public async Task<IActionResult> GetSpecialties()
		{
			return HandleResult(await Mediator.Send(new List.Query()));
		}
    }
}