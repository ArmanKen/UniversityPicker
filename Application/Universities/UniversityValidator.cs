using Domain;
using FluentValidation;

namespace Application.Universities
{
	public class UniversityValidator : AbstractValidator<University>
	{
		public UniversityValidator()
		{
			RuleFor(x => x.Name).NotEmpty();
		}
	}
}