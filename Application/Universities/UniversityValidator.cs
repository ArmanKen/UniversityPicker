using Application.DTOs;
using Domain;
using FluentValidation;

namespace Application.Universities
{
	public class UniversityValidator : AbstractValidator<UniversityDto>
	{
		public UniversityValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
			RuleFor(x => x.Name).NotEmpty();
		}
	}
}