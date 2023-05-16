namespace Domain
{
    public class Photo
    {
		public string Id { get; set; }
		public string Url { get; set; }
		public ICollection<University> Universities { get; set; } = new List<University>();
    }
}