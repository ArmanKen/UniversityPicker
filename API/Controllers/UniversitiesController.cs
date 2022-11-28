using Application.Universities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class UniversitiesController : BaseApiController
	{
		public async Task<IActionResult> GetUniversities()
		{
			return HandleResult(await Mediator.Send(new List.Query()));
		}
	}
}