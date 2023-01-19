namespace Domain
{
	public class ISCED
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public ICollection<SpecialtyBase> SpecialtyBases { get; set; } = new List<SpecialtyBase>();
	}
}