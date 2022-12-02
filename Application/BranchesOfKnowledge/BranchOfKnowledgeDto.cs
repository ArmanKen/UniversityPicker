using Application.Specialties;

namespace Application.BranchesOfKnowledge
{
	public class BranchOfKnowledgeDto
	{
		public Guid Id { get; set; }

		public string? Name { get; set; }

		public ICollection<SpecialtyDto>? Specialties { get; set; }
	}
}