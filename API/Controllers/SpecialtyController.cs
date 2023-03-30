using Application.DTOs;
using Application.Specialties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class SpecialtyController : BaseApiController
	{
		[AllowAnonymous]
		[HttpGet("list/{facultyId}")]
		public async Task<IActionResult> GetSpecialties([FromQuery] SpecialtyParams param, Guid facultyId)
		{
			return HandlePagedResult(await Mediator.Send(new List.Query
			{ FacultyId = facultyId, Params = param }));
		}

		[AllowAnonymous]
		[HttpGet("{specialtyId}")]
		public async Task<IActionResult> GetSpecialty(Guid specialtyId)
		{
			return HandleResult(await Mediator.Send(new Details.Query
			{ SpecialtyId = specialtyId }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost("create/{facultyId}")]
		public async Task<IActionResult> CreateSpecialty(SpecialtyDto specialty, Guid facultyId)
		{
			return HandleResult(await Mediator.Send(new Create.Command
			{ Specialty = specialty, FacultyId = facultyId }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPut("{specialtyId}")]
		public async Task<IActionResult> EditSpecialty(SpecialtyDto specialty, Guid specialtyId)
		{
			specialty.Id = specialtyId;
			return HandleResult(await Mediator.Send(new Edit.Command
			{ Specialty = specialty }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpDelete("{specialtyId}")]
		public async Task<IActionResult> DeleteSpecialty(Guid specialtyId)
		{
			return HandleResult(await Mediator.Send(new Delete.Command
			{ SpecialtyId = specialtyId }));
		}
	}
}