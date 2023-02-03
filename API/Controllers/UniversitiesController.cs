using Application.Universities;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class UniversitiesController : BaseApiController
	{
		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> GetUniversities([FromQuery] UniversityParams param)
		{
			return HandlePagedResult(await Mediator.Send(new List.Query { Params = param }));
		}

		[AllowAnonymous]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetUniversity(Guid id)
		{
			return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
		}

		[Authorize(Policy = "IsGlobalAdmin")]
		[HttpPost]
		public async Task<IActionResult> CreateUniversity(University university)
		{
			return HandleResult(await Mediator.Send(new Create.Command { University = university }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPut("{id}")]
		public async Task<IActionResult> ChangeUniversity(Guid id, University university)
		{
			university.Id = id;
			return HandleResult(await Mediator.Send(new Edit.Command { Id = id, University = university }));
		}

		[Authorize(Policy = "IsGlobalAdmin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUniversity(Guid id)
		{
			return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
		}

		[AllowAnonymous]
		[HttpGet("{id}/specialties")]
		public async Task<IActionResult> GetUniversitySpecialties(Guid id)
		{
			return HandleResult(await Mediator.Send(new Application.Specialties.List.Query { Id = id }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost("{id}/specialties")]
		public async Task<IActionResult> CreateSpecialty(Specialty specialty, Guid id)
		{
			return HandleResult(await Mediator.Send(new Application.Specialties.Create.Command { Specialty = specialty, UniversityId = id }));
		}
	}
}