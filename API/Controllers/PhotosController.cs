using Application.Photos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class PhotosController : BaseApiController
	{
		[Authorize(Policy = "IsUser")]
		[HttpPost]
		public async Task<IActionResult> AddUsersPhoto([FromForm] AddUsersPhoto.Command command)
		{
			return HandleResult(await Mediator.Send(command));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost("{id}/gallery/")]
		public async Task<IActionResult> AddUniversityPhoto(Guid universityId, [FromForm] AddUniversityPhoto.Command command)
		{
			command.UniversityId = universityId;
			return HandleResult(await Mediator.Send(command));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost("{id}/titleImage/")]
		public async Task<IActionResult> AddUniversityTitlePhoto(Guid universityId, [FromForm] AddUniversityPhoto.Command command)
		{
			command.UniversityId = universityId;
			return HandleResult(await Mediator.Send(command));
		}

		[Authorize(Policy = "IsUser")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(string id)
		{
			return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
		}
	}
}