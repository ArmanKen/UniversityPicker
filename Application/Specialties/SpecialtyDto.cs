using Application.Disciplines;
using Domain;

namespace Application.Specialties
{
	public class SpecialtyDto
	{
		public Guid Id { get; set; }

		public int Code { get; set; }

		public string? Name { get; set; }

		public string? Price { get; set; }

		public string? Info { get; set; }

		public bool BudgetAllowed { get; set; }

		public ICollection<DisciplineDto>? Disciplines { get; set; }
	}
}