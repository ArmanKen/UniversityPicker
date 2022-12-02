namespace Domain
{
	public class UniversityBranchesOfKnowledge
	{

		public Guid UniversityId { get; set; }

		public University? University { get; set; }

		public Guid BranchOfKnowledgeId { get; set; }

		public BranchOfKnowledge? BranchOfKnowledge { get; set; }
	}
}