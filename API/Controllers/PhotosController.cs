using Application.Core;
using Application.Photos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class PhotosController : BaseApiController
	{
		[AllowAnonymous]
		[HttpGet("{higherEducationFacilityId}/gallery")]
		public async Task<IActionResult> GetHigherEducationFacilityPhotos(Guid higherEducationFacilityId, [FromQuery] PhotoPagingParams photoPagingParams)
		{
			return HandlePagedResult(await Mediator.Send(new List.Query { HigherEducationFacilityId = higherEducationFacilityId, Params = photoPagingParams }));
		}

		[Authorize]
		[HttpPost("user/add")]
		public async Task<IActionResult> AddUsersPhoto([FromForm] AddUsersPhoto.Command command)
		{
			return HandleResult(await Mediator.Send(command));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost("{higherEducationFacilityId}/gallery")]
		public async Task<IActionResult> AddHigherEducationFacilityPhoto(Guid higherEducationFacilityId, [FromForm] AddHigherEducationFacilityPhoto.Command command)
		{
			command.HigherEducationFacilityId = higherEducationFacilityId;
			return HandleResult(await Mediator.Send(command));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost("{higherEducationFacilityId}/titleImage")]
		public async Task<IActionResult> AddHigherEducationFacilityTitlePhoto(Guid higherEducationFacilityId, [FromForm] AddHigherEducationFacilityTitlePhoto.Command command)
		{
			command.HigherEducationFacilityId = higherEducationFacilityId;
			return HandleResult(await Mediator.Send(command));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost("{higherEducationFacilityId}/{facultyId}")]
		public async Task<IActionResult> AddFacultyPhoto(Guid facultyId, [FromForm] AddFacultyPhoto.Command command)
		{
			command.FacultyId = facultyId;
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
		public async Task<IActionResult> DeletePhoto(Guid higherEducationFacilityId, string photoId)
		{
			return HandleResult(await Mediator.Send(new DeletePhoto.Command { PhotoId = photoId }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpDelete("{higherEducationFacilityId}")]
		public async Task<IActionResult> DeleteHigherEducationFacilityTitlePhoto(Guid higherEducationFacilityId)
		{
			return HandleResult(await Mediator.Send(new DeleteHigherEducationFacilityTitlePhoto.Command { HigherEducationFacilityId = higherEducationFacilityId }));
		}
	}
}