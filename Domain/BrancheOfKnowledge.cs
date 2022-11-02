namespace Domain
{
	public class BrancheOfKnowledge
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public ICollection<Specialtie>? Specialties { get; set; }
	}
}