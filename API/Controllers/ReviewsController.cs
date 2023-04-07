using Application.DTOs;
using Application.Reviews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class ReviewsController : BaseApiController
	{
		[AllowAnonymous]
		[HttpGet("list/{universityId}")]
		public async Task<IActionResult> GetReview([FromQuery] ReviewParams param, Guid universityId)
		{
			return HandlePagedResult(await Mediator.Send(new List.Query
			{ UniversityId = universityId, Params = param }));
		}

		[AllowAnonymous]
		[HttpGet("{reviewId}")]
		public async Task<IActionResult> GetReview(Guid reviewId)
		{
			return HandleResult(await Mediator.Send(new Details.Query
			{ ReviewId = reviewId }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost("create/{universityId}")]
		public async Task<IActionResult> CreateReview(ReviewDto Review, Guid universityId)
		{
			return HandleResult(await Mediator.Send(new Create.Command
			{ Review = Review, UniversirtyId = universityId }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPut("{reviewId}")]
		public async Task<IActionResult> EditReview(ReviewDto Review, Guid reviewId)
		{
			Review.Id = reviewId;
			return HandleResult(await Mediator.Send(new Edit.Command
			{ Review = Review }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpDelete("{reviewId}")]
		public async Task<IActionResult> DeleteReview(Guid reviewId)
		{
			return HandleResult(await Mediator.Send(new Delete.Command
			{ ReviewId = reviewId }));
		}
	}
}