namespace Domain
{
	public class FavoriteList
	{
		public string AppUserId { get; set; }
		public AppUser AppUser { get; set; }
		public Guid InstitutionId { get; set; }
		public Institution Institution { get; set; }
	}
}