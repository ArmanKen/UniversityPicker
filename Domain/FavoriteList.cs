namespace Domain
{
	public class FavoriteList
	{
		public string AppUserId { get; set; }
		public AppUser AppUser { get; set; }
		public Guid HigherEducationFacilityId { get; set; }
		public HigherEducationFacility HigherEducationFacility { get; set; }
	}
}