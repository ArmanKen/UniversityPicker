using Application.DTOs;
using Domain;
using FluentValidation;

namespace Application.HigherEducationFacilities
{
	public class HigherEducationFacilityValidator : AbstractValidator<HigherEducationFacilityDto>
	{
		public HigherEducationFacilityValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
			RuleFor(x => x.Name).NotEmpty();
		}
	}
}