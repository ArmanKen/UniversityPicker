namespace Domain
{
	public class Photo
	{
		public string Id { get; set; }
		public string Url { get; set; }
		public ICollection<HigherEducationFacility> HigherEducationFacilities { get; set; } = new List<HigherEducationFacility>();
	}
}