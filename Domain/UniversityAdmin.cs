namespace Domain
{
	public class UniversityAdmin
	{
		public string AppUserId { get; set; }
		public AppUser AppUser { get; set; }
		public Guid UniversityId { get; set; }
		public University University { get; set; }
	}
}