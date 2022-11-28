namespace Domain
{
	public class BranchOfKnowledgeSpecialties
	{
		public Guid BranchOfKnowledgeId { get; set; }

		public BranchOfKnowledge? BranchOfKnowledge { get; set; }

		public Guid SpecialtyId { get; set; }

		public Specialty? Specialty { get; set; }
	}
}