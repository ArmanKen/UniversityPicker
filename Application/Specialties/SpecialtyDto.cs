using Application.Disciplines;
using Domain;

namespace Application.Specialties
{
	public class SpecialtyDto
	{
		public Guid Id { get; set; }

		public int Code { get; set; }

		public string? Name { get; set; }

		public string? BranchOfKnowledge { get; set; }

		public ICollection<DisciplineDto>? Disciplines { get; set; }
	}
}