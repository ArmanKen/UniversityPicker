using Application.DTOs;
using Application.Universities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class UniversitiesController : BaseApiController
	{
		[AllowAnonymous]
		[HttpGet("list")]
		public async Task<IActionResult> GetUniversities([FromQuery] UniversityParams param)
		{
			return HandlePagedResult(await Mediator.Send(new List.Query
			{ Params = param }));
		}

		[AllowAnonymous]
		[HttpGet("{universityId}")]
		public async Task<IActionResult> GetUniversity(Guid universityId)
		{
			return HandleResult(await Mediator.Send(new Details.Query
			{ UniversityId = universityId }));
		}

		[Authorize(Policy = "IsGlobalAdmin")]
		[HttpPost("create")]
		public async Task<IActionResult> CreateUniversity(UniversityDto university)
		{
			return HandleResult(await Mediator.Send(new Create.Command
			{ University = university }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPut("{universityId}")]
		public async Task<IActionResult> ChangeUniversity(Guid universityId, UniversityDto university)
		{
			university.Id = universityId;
			return HandleResult(await Mediator.Send(new Edit.Command
			{ University = university }));
		}

		[Authorize(Policy = "IsGlobalAdmin")]
		[HttpDelete("{universityId}")]
		public async Task<IActionResult> DeleteUniversity(Guid universityId)
		{
			return HandleResult(await Mediator.Send(new Delete.Command
			{ UniversityId = universityId }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost("{universityId}/updateLocalAdmin/{username}")]
		public async Task<IActionResult> UpdateLocalAdmin(Guid universityId, string username)
		{
			return HandleResult(await Mediator.Send(new UpdateLocalAdmin.Command
			{ UniversityId = universityId, Username = username }));
		}
	}
}