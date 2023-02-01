using Domain;
using FluentValidation;

namespace Application.Disciplines
{
	public class DisciplineValidator : AbstractValidator<Discipline>
	{
		public DisciplineValidator()
		{
			RuleFor(x => x.Name).NotEmpty();
		}
	}
}