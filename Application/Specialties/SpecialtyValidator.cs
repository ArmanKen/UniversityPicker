using Application.DTOs;
using FluentValidation;

namespace Application.Specialties
{
	public class SpecialtyValidator : AbstractValidator<SpecialtyDto>
	{
		public SpecialtyValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
			RuleFor(x => x.SpecialtyBase.Id).NotEmpty();
			RuleFor(x => x.SpecialtyBase.Name).NotEmpty();
		}
	}
}