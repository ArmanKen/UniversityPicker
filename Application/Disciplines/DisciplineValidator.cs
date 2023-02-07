using Application.DTOs;
using FluentValidation;

namespace Application.Disciplines
{
	public class DisciplineValidator : AbstractValidator<DisciplineDto>
	{
		public DisciplineValidator()
		{
			RuleFor(x => x.Name).NotEmpty();
		}
	}
}