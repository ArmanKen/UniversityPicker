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
			return HandlePagedResult(await Mediator.Send(new List.Query
			{ Params = param }));
		}

		[AllowAnonymous]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetUniversity(Guid id)
		{
			return HandleResult(await Mediator.Send(new Details.Query
			{ Id = id }));
		}

		[Authorize(Policy = "IsGlobalAdmin")]
		[HttpPost]
		public async Task<IActionResult> CreateUniversity(University university)
		{
			return HandleResult(await Mediator.Send(new Create.Command
			{ University = university }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPut("{id}")]
		public async Task<IActionResult> ChangeUniversity(Guid id, University university)
		{
			university.Id = id;
			return HandleResult(await Mediator.Send(new Edit.Command
			{ Id = id, University = university }));
		}

		[Authorize(Policy = "IsGlobalAdmin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUniversity(Guid id)
		{
			return HandleResult(await Mediator.Send(new Delete.Command
			{ Id = id }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost("{id}/localAdmin/{username}")]
		public async Task<IActionResult> ToggleLocalAdmin(Guid id, string username)
		{
			return HandleResult(await Mediator.Send(new ToggleLocalAdministrator.Command
			{ Id = id, Username = username }));
		}

		[Authorize]
		[HttpPost("{id}/selectUniversity")]
		public async Task<IActionResult> SelectUniversity(Guid id)
		{
			return HandleResult(await Mediator.Send(new Application.SelectedUniversities.SelectedToggle.Command
			{ TargetUniversityId = id }));
		}

		[AllowAnonymous]
		[HttpGet("{id}/specialties")]
		public async Task<IActionResult> GetSpecialties([FromQuery] Application.Specialties.SpecialtyParams param, Guid id)
		{
			return HandlePagedResult(await Mediator.Send(new Application.Specialties.List.Query
			{ Id = id, Params = param }));
		}

		[AllowAnonymous]
		[HttpGet("{id}/specialties/{specialtyId}")]
		public async Task<IActionResult> GetSpecialty(Guid specialtyId)
		{
			return HandleResult(await Mediator.Send(new Application.Specialties.Details.Query
			{ SpecialtyId = specialtyId }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost("{id}/specialties/")]
		public async Task<IActionResult> CreateSpecialty(Application.DTOs.SpecialtyDto specialty, Guid id)
		{
			return HandleResult(await Mediator.Send(new Application.Specialties.Create.Command
			{ Specialty = specialty, UniversityId = id }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPut("{id}/specialties/{specialtyId}")]
		public async Task<IActionResult> EditSpecialty(Specialty specialty, Guid specialtyId)
		{
			specialty.Id = specialtyId;
			return HandleResult(await Mediator.Send(new Application.Specialties.Edit.Command
			{ Specialty = specialty, SpecialtyId = specialtyId }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpDelete("{id}/specialties/{specialtyId}")]
		public async Task<IActionResult> DeleteSpecialty(Guid specialtyId, Guid id)
		{
			return HandleResult(await Mediator.Send(new Application.Specialties.Delete.Command
			{ Id = specialtyId }));
		}

		[AllowAnonymous]
		[HttpGet("{id}/specialties/{specialtyId}/disciplines")]
		public async Task<IActionResult> GetDisciplines(Guid specialtyId)
		{
			return HandleResult(await Mediator.Send(new Application.Disciplines.List.Query
			{ SpecialtyId = specialtyId }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost("{id}/specialties/{specialtyId}/disciplines")]
		public async Task<IActionResult> CreateDiscipline(Guid specialtyId, Application.DTOs.DisciplineDto discipline)
		{
			return HandleResult(await Mediator.Send(new Application.Disciplines.Create.Command
			{ Discipline = discipline }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPut("{id}/specialties/{specialtyId}/disciplines/{disciplineId}")]
		public async Task<IActionResult> EditDiscipline(int disciplineId, Discipline discipline)
		{
			discipline.Id = disciplineId;
			return HandleResult(await Mediator.Send(new Application.Disciplines.Edit.Command
			{ Id = disciplineId, Discipline = discipline }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpDelete("{id}/specialties/{specialtyId}/disciplines/{disciplineId}")]
		public async Task<IActionResult> DeleteDiscipline(Guid disciplineId)
		{
			return HandleResult(await Mediator.Send(new Application.Disciplines.Delete.Command
			{ Id = disciplineId }));
		}
	}
}