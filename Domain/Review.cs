namespace Domain
{
	public class Review
	{
		public Guid Id { get; set; }
		public string Body { get; set; }
		public int Rating { get; set; }
		public AppUser Author { get; set; }
		public HigherEducationFacility HigherEducationFacility { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}
}