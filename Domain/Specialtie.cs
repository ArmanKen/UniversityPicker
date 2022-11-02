namespace Domain
{
	public class Specialtie
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public int BranchesOfKnowledgesId { get; set; }
		public BrancheOfKnowledge? BranchesOfKnowledges { get; set; }
	}
}