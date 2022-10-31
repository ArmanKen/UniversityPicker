namespace Domain
{
	public class BranchesOfKnowledges
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public ICollection<Specialties>? Specialties { get; set; }
	}
}