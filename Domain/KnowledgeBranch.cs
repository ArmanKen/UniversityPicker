namespace Domain
{
	public class KnowledgeBranch
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public ICollection<SpecialtyBase> SpecialtyBases { get; set; } = new List<SpecialtyBase>();
		public ICollection<Faculty> Faculties { get; set; } = new List<Faculty>();
	}
}