namespace Domain
{
	public class BranchOfKnowledge
	{
		public Guid Id { get; set; }

		public string? Name { get; set; }

		public UniversityBranchesOfKnowledge? University { get; set; }

		public ICollection<BranchOfKnowledgeSpecialties> Specialties { get; set; } = new List<BranchOfKnowledgeSpecialties>();
	}
}