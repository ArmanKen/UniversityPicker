namespace Domain
{
	public class Region
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<City> Cities { get; set; } = new List<City>();
	}
}