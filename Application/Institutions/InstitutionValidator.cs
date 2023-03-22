using Domain;
using FluentValidation;

namespace Application.Institutions
{
	public class InstitutionValidator : AbstractValidator<Institution>
	{
		public InstitutionValidator()
		{
			RuleFor(x => x.Name).NotEmpty();
		}
	}
}