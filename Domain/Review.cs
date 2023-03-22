namespace Domain
{
	public class Review
	{
		public int Id { get; set; }
		public string Body { get; set; }
		public int Rating { get; set; }
		public AppUser Author { get; set; }
		public Faculty Faculty { get; set; }
		public SpecialtyBase SpecialtyBase { get; set; }
		public Institution Institution { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}
}