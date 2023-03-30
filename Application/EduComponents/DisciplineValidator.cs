using Application.DTOs;
using FluentValidation;

namespace Application.EduComponents
{
	public class EducationComponentValidator : AbstractValidator<EduComponentDto>
	{
		public EducationComponentValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
			RuleFor(x => x.Name).NotEmpty();
		}
	}
}