using Application.Photos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class PhotosController : BaseApiController
	{
		[AllowAnonymous]
		[HttpGet("universities/{universityId}/gallery")]
		public async Task<IActionResult> GetUniversityPhotos(Guid universityId)
		{
			return HandleResult(await Mediator.Send(new List.Query { UniversityId = universityId }));
		}

		[Authorize]
		[HttpPost("user/add")]
		public async Task<IActionResult> AddUsersPhoto([FromForm] AddUsersPhoto.Command command)
		{
			return HandleResult(await Mediator.Send(command));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost("universities/{universityId}/gallery")]
		public async Task<IActionResult> AddUniversityPhoto(Guid universityId, [FromForm] AddUniversityPhoto.Command command)
		{
			command.UniversityId = universityId;
			return HandleResult(await Mediator.Send(command));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost("universities/{universityId}/titleImage/")]
		public async Task<IActionResult> AddUniversityTitlePhoto(Guid universityId, [FromForm] AddUniversityPhoto.Command command)
		{
			command.UniversityId = universityId;
			return HandleResult(await Mediator.Send(command));
		}

		[Authorize]
		[HttpDelete("{photoId}")]
		public async Task<IActionResult> Delete(string photoId)
		{
			return HandleResult(await Mediator.Send(new Delete.Command { Id = photoId }));
		}
	}
}