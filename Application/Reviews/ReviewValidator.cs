using Application.DTOs;
using FluentValidation;

namespace Application.Reviews
{
	public class ReviewValidator : AbstractValidator<ReviewDto>
	{
		public ReviewValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
			RuleFor(x => x.Body).NotEmpty();
			RuleFor(x => x.UserName).NotEmpty();
		}
	}
}