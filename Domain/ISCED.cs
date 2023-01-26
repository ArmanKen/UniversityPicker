namespace Domain
{
	public class Isced
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public ICollection<SpecialtyBase> SpecialtyBases { get; set; } = new List<SpecialtyBase>();
	}
}