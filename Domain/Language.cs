namespace Domain
{
	public class Language
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public ICollection<Specialty> Specialties { get; set; } = new List<Specialty>();
	}
}