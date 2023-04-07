using Application.DTOs;
using Application.Faculties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class FacultiesController : BaseApiController
	{
		[AllowAnonymous]
		[HttpGet("list/{universityId}")]
		public async Task<IActionResult> GetFaculties(Guid universityId)
		{
			return HandleResult(await Mediator.Send(new List.Query { UniversityId = universityId }));
		}

		[AllowAnonymous]
		[HttpGet("{facultyId}")]
		public async Task<IActionResult> GetFaculty(Guid facultyId)
		{
			return HandleResult(await Mediator.Send(new Details.Query { FacultyId = facultyId }));
		}

		[Authorize(Policy = "IsGlobalAdmin")]
		[HttpPost("create/{universityId}")]
		public async Task<IActionResult> CreateFaculty(FacultyDto Faculty, Guid universityId)
		{
			return HandleResult(await Mediator.Send(new Create.Command
			{ Faculty = Faculty, UniversityId = universityId }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPut("{facultyId}")]
		public async Task<IActionResult> ChangeFaculty(Guid facultyId, FacultyDto Faculty)
		{
			Faculty.Id = facultyId;
			return HandleResult(await Mediator.Send(new Edit.Command
			{ Faculty = Faculty }));
		}

		[Authorize(Policy = "IsGlobalAdmin")]
		[HttpDelete("{facultyId}")]
		public async Task<IActionResult> DeleteFaculty(Guid facultyId)
		{
			return HandleResult(await Mediator.Send(new Delete.Command
			{ FacultyId = facultyId }));
		}
	}
}