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
			return HandlePagedResult(await Mediator.Send(new List.Query { UniversityId = universityId }));
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
		[HttpDelete]
		public async Task<IActionResult> DeleteUserPhoto()
		{
			return HandleResult(await Mediator.Send(new DeleteUserPhoto.Command { }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpDelete("{universityId}/{photoId}")]
		public async Task<IActionResult> DeleteUniversityPhoto(Guid universityId, string photoId)
		{
			return HandleResult(await Mediator.Send(new DeleteUniversityPhoto.Command { PhotoId = photoId }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpDelete("{universityId}")]
		public async Task<IActionResult> DeleteUniversityTitlePhoto(Guid universityId)
		{
			return HandleResult(await Mediator.Send(new DeleteUniversityTitlePhoto.Command { UniversityId = universityId }));
		}
	}
}