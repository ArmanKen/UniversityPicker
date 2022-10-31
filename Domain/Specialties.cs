namespace Domain
{
	public class Specialties
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public int BranchesOfKnowledgesId { get; set; }
		public BranchesOfKnowledges? BranchesOfKnowledges { get; set; }
	}
}