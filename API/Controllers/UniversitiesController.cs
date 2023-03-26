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
			return HandleResult(await Mediator.Send(new ToggleLocalAdmin.Command
			{ Id = id, Username = username }));
		}

		[Authorize]
		[HttpPost("{id}/selectUniversity")]
		public async Task<IActionResult> SelectUniversity(Guid id)
		{
			return HandleResult(await Mediator.Send(new Application.FavoriteLists.FavoriteToggle.Command
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
		[HttpGet("{id}/specialties/{specialtyId}/eduComponents")]
		public async Task<IActionResult> GetEduComponents(Guid specialtyId)
		{
			return HandleResult(await Mediator.Send(new Application.EduComponents.List.Query
			{ SpecialtyId = specialtyId }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost("{id}/specialties/{specialtyId}/eduComponents")]
		public async Task<IActionResult> CreateDiscipline(Guid specialtyId, Application.DTOs.EduComponentDto educationComponent)
		{
			return HandleResult(await Mediator.Send(new Application.EduComponents.Create.Command
			{ EducationComponent = educationComponent }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPut("{id}/specialties/{specialtyId}/eduComponents/{educationComponentId}")]
		public async Task<IActionResult> EditDiscipline(int educationComponentId, EduComponent educationComponent)
		{
			educationComponent.Id = educationComponentId;
			return HandleResult(await Mediator.Send(new Application.EduComponents.Edit.Command
			{ Id = educationComponentId, EducationComponent = educationComponent }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpDelete("{id}/specialties/{specialtyId}/eduComponents/{educationComponentId}")]
		public async Task<IActionResult> DeleteDiscipline(Guid disciplineId)
		{
			return HandleResult(await Mediator.Send(new Application.EduComponents.Delete.Command
			{ Id = disciplineId }));
		}
	}
}