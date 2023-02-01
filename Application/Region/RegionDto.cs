namespace Application.Region
{
	public class RegionDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<CityDto> Cities { get; set; }
	}
}