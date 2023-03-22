using Domain;

namespace Application.DTOs
{
	public class RegionDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<City> Cities { get; set; }
	}
}