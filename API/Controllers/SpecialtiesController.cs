using Application.Specialties;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class SpecialtiesController : BaseApiController
	{
		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> GetSpecialties()
		{
			return HandleResult(await Mediator.Send(new List.Query()));
		}

		[AllowAnonymous]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetSpecialty(Guid id)
		{
			return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost]
		public async Task<IActionResult> CreateSpecialty(Specialty specialty)
		{
			return HandleResult(await Mediator.Send(new Create.Command { Specialty = specialty }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPut("{id}")]
		public async Task<IActionResult> EditSpecialty(Specialty specialty, Guid id)
		{
			return HandleResult(await Mediator.Send(new Edit.Command { Specialty = specialty, Id = id }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSpecialty(Guid id)
		{
			return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
		}
	}
}