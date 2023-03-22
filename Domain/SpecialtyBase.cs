namespace Domain
{
	public class SpecialtyBase
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public KnowledgeBranch KnowledgeBranch { get; set; }
		public ICollection<Specialty> Specialties { get; set; } = new List<Specialty>();
		public ICollection<Isced> Isceds { get; set; } = new List<Isced>();
	}
}