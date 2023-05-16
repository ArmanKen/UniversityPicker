using Application.DTOs;
using Application.EduComponents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class EduComponentsController : BaseApiController
	{
		[AllowAnonymous]
		[HttpGet("list/{specialtyId}")]
		public async Task<IActionResult> GetEduComponents(Guid specialtyId)
		{
			return HandleResult(await Mediator.Send(new List.Query
			{ SpecialtyId = specialtyId }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost("{universityId}/create/{specialtyId}")]
		public async Task<IActionResult> CreateEduComponent(Guid specialtyId, Application.DTOs.EduComponentDto educationComponent)
		{
			return HandleResult(await Mediator.Send(new Create.Command
			{ SpecialtyId = specialtyId, EducationComponent = educationComponent }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPut("{universityId}/{educationComponentId}")]
		public async Task<IActionResult> EditEduComponent(int educationComponentId, EduComponentDto educationComponent)
		{
			educationComponent.Id = educationComponentId;
			return HandleResult(await Mediator.Send(new Edit.Command
			{ EducationComponent = educationComponent }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpDelete("{universityId}/{educationComponentId}")]
		public async Task<IActionResult> DeleteEduComponent(Guid educationComponentId)
		{
			return HandleResult(await Mediator.Send(new Delete.Command
			{ EduComponentId = educationComponentId }));
		}
	}
}