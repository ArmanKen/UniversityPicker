using Application.DTOs;
using Application.HigherEducationFacilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class HigherEducationFacilitiesController : BaseApiController
	{
		[AllowAnonymous]
		[HttpGet("list")]
		public async Task<IActionResult> GetHigherEducationFacilities([FromQuery] HigherEducationFacilityParams param)
		{
			return HandlePagedResult(await Mediator.Send(new List.Query
			{ Params = param }));
		}

		[AllowAnonymous]
		[HttpGet("{higherEducationFacilityId}")]
		public async Task<IActionResult> GetHigherEducationFacility(Guid higherEducationFacilityId)
		{
			return HandleResult(await Mediator.Send(new Details.Query
			{ HigherEducationFacilityId = higherEducationFacilityId }));
		}

		[Authorize(Policy = "IsGlobalAdmin")]
		[HttpPost("create")]
		public async Task<IActionResult> CreateHigherEducationFacility(HigherEducationFacilityFormValues higherEducationFacility)
		{
			return HandleResult(await Mediator.Send(new Create.Command
			{ HigherEducationFacility = higherEducationFacility }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPut("{higherEducationFacilityId}")]
		public async Task<IActionResult> ChangeHigherEducationFacility(Guid higherEducationFacilityId,
			HigherEducationFacilityFormValues higherEducationFacility)
		{
			higherEducationFacility.Id = higherEducationFacilityId;
			return HandleResult(await Mediator.Send(new Edit.Command
			{ HigherEducationFacility = higherEducationFacility }));
		}

		[Authorize(Policy = "IsGlobalAdmin")]
		[HttpDelete("{higherEducationFacilityId}")]
		public async Task<IActionResult> DeleteHigherEducationFacility(Guid higherEducationFacilityId)
		{
			return HandleResult(await Mediator.Send(new Delete.Command
			{ HigherEducationFacilityId = higherEducationFacilityId }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost("{higherEducationFacilityId}/updateLocalAdmin/{username}")]
		public async Task<IActionResult> UpdateLocalAdmin(Guid higherEducationFacilityId, string username)
		{
			return HandleResult(await Mediator.Send(new UpdateLocalAdmin.Command
			{ HigherEducationFacilityId = higherEducationFacilityId, Username = username }));
		}
	}
}