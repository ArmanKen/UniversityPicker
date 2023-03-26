using Application.DTOs;
using FluentValidation;

namespace Application.Faculties
{
    public class FacultyValidator : AbstractValidator<FacultyDto>
	{
		public FacultyValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
			RuleFor(x => x.Name).NotEmpty();
		}
	}
}