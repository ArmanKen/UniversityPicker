using Application.Photos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class PhotosController : BaseApiController
	{
		[AllowAnonymous]
		[HttpGet("higherEducationFacilities/{higherEducationFacilityId}/gallery")]
		public async Task<IActionResult> GetHigherEducationFacilityPhotos(Guid higherEducationFacilityId)
		{
			return HandlePagedResult(await Mediator.Send(new List.Query { HigherEducationFacilityId = higherEducationFacilityId }));
		}

		[Authorize]
		[HttpPost("user/add")]
		public async Task<IActionResult> AddUsersPhoto([FromForm] AddUsersPhoto.Command command)
		{
			return HandleResult(await Mediator.Send(command));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost("higherEducationFacilities/{higherEducationFacilityId}/gallery")]
		public async Task<IActionResult> AddHigherEducationFacilityPhoto(Guid higherEducationFacilityId, [FromForm] AddHigherEducationFacilityPhoto.Command command)
		{
			command.HigherEducationFacilityId = higherEducationFacilityId;
			return HandleResult(await Mediator.Send(command));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost("higherEducationFacilities/{higherEducationFacilityId}/titleImage/")]
		public async Task<IActionResult> AddHigherEducationFacilityTitlePhoto(Guid higherEducationFacilityId, [FromForm] AddHigherEducationFacilityPhoto.Command command)
		{
			command.HigherEducationFacilityId = higherEducationFacilityId;
			return HandleResult(await Mediator.Send(command));
		}

		[Authorize]
		[HttpDelete]
		public async Task<IActionResult> DeleteUserPhoto()
		{
			return HandleResult(await Mediator.Send(new DeleteUserPhoto.Command { }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpDelete("{higherEducationFacilityId}/{photoId}")]
		public async Task<IActionResult> DeleteHigherEducationFacilityPhoto(Guid higherEducationFacilityId, string photoId)
		{
			return HandleResult(await Mediator.Send(new DeleteHigherEducationFacilityPhoto.Command { PhotoId = photoId }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpDelete("{higherEducationFacilityId}")]
		public async Task<IActionResult> DeleteHigherEducationFacilityTitlePhoto(Guid higherEducationFacilityId)
		{
			return HandleResult(await Mediator.Send(new DeleteHigherEducationFacilityTitlePhoto.Command { HigherEducationFacilityId = higherEducationFacilityId }));
		}
	}
}