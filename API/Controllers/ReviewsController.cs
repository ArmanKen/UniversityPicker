using Application.DTOs;
using Application.Reviews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class ReviewsController : BaseApiController
	{
		[AllowAnonymous]
		[HttpGet("list/{higherEducationFacilityId}")]
		public async Task<IActionResult> GetReviews(Guid higherEducationFacilityId, [FromQuery] ReviewParams param )
		{
			return HandlePagedResult(await Mediator.Send(new List.Query
			{ HigherEducationFacilityId = higherEducationFacilityId, Params = param }));
		}

		[AllowAnonymous]
		[HttpGet("{reviewId}")]
		public async Task<IActionResult> GetReview(Guid reviewId)
		{
			return HandleResult(await Mediator.Send(new Details.Query
			{ ReviewId = reviewId }));
		}

		[Authorize]
		[HttpGet("user/{higherEducationFacilityId}")]
		public async Task<IActionResult> GetUserReview(Guid higherEducationFacilityId)
		{
			return HandleResult(await Mediator.Send(new GetUserReview.Query
			{ HigherEducationFacilityId = higherEducationFacilityId }));
		}

		[Authorize]
		[HttpPost("create/{higherEducationFacilityId}")]
		public async Task<IActionResult> CreateReview(ReviewFormValues Review, Guid higherEducationFacilityId)
		{
			return HandleResult(await Mediator.Send(new Create.Command
			{ Review = Review, UniversirtyId = higherEducationFacilityId }));
		}

		[Authorize]
		[HttpPut("{higherEducationFacilityId}/{reviewId}")]
		public async Task<IActionResult> EditReview(ReviewFormValues Review, Guid reviewId)
		{
			Review.Id = reviewId;
			return HandleResult(await Mediator.Send(new Edit.Command
			{ Review = Review }));
		}

		[Authorize]
		[HttpDelete("{higherEducationFacilityId}/{reviewId}")]
		public async Task<IActionResult> DeleteReview(Guid reviewId)
		{
			return HandleResult(await Mediator.Send(new Delete.Command
			{ ReviewId = reviewId }));
		}
	}
}