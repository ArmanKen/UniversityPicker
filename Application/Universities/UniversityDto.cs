using Application.BranchesOfKnowledge;

namespace Application.Universities
{
	public class UniversityDto
	{
		public Guid Id { get; set; }

		public string? Name { get; set; }

		public string? Region { get; set; }

		public string? City { get; set; }

		public string? Address { get; set; }

		public string? Website { get; set; }

		public ICollection<BranchOfKnowledgeDto>? BranchesOfKnowledge { get; set; }
	}
}