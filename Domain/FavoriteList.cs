namespace Domain
{
	public class FavoriteList
	{
		public string AppUserId { get; set; }
		public AppUser AppUser { get; set; }
		public Guid UniversityId { get; set; }
		public University University { get; set; }
	}
}