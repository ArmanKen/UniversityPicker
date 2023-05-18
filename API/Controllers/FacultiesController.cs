using Application.DTOs;
using Application.Faculties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class FacultiesController : BaseApiController
	{
		[AllowAnonymous]
		[HttpGet("list/{higherEducationFacilityId}")]
		public async Task<IActionResult> GetFaculties(Guid higherEducationFacilityId)
		{
			return HandleResult(await Mediator.Send(new List.Query { HigherEducationFacilityId = higherEducationFacilityId }));
		}

		[AllowAnonymous]
		[HttpGet("{facultyId}")]
		public async Task<IActionResult> GetFaculty(Guid facultyId)
		{
			return HandleResult(await Mediator.Send(new Details.Query { FacultyId = facultyId }));
		}

		[Authorize(Policy = "IsGlobalAdmin")]
		[HttpPost("/create/{higherEducationFacilityId}")]
		public async Task<IActionResult> CreateFaculty(FacultyDto Faculty, Guid higherEducationFacilityId)
		{
			return HandleResult(await Mediator.Send(new Create.Command
			{ Faculty = Faculty, HigherEducationFacilityId = higherEducationFacilityId }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPut("{higherEducationFacilityId}/{facultyId}")]
		public async Task<IActionResult> ChangeFaculty(Guid facultyId, FacultyDto Faculty)
		{
			Faculty.Id = facultyId;
			return HandleResult(await Mediator.Send(new Edit.Command
			{ Faculty = Faculty }));
		}

		[Authorize(Policy = "IsGlobalAdmin")]
		[HttpDelete("{higherEducationFacilityId}/{facultyId}")]
		public async Task<IActionResult> DeleteFaculty(Guid facultyId)
		{
			return HandleResult(await Mediator.Send(new Delete.Command
			{ FacultyId = facultyId }));
		}
	}
}