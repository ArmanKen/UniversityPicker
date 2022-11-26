namespace Domain
{
	public class BranchOfKnowledgeSpecialties
	{
		public Guid BranchOfKnowledgeId { get; set; }

		public BranchOfKnowledge? BranchOfKnowledge { get; set; }

		public Guid SpecialtieId { get; set; }

		public Specialtie? Specialtie { get; set; }
	}
}