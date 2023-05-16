using Domain;

namespace Application.DTOs
{
	public class UniversityDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Accreditation Accreditation { get; set; }
		public RegionDto Region { get; set; }
		public City City { get; set; }
		public string Address { get; set; }
		public double Rating { get; set; }
		public string Website { get; set; }
		public string Info { get; set; }
		public string Telephone { get; set; }
		public int UkraineTop { get; set; }
		public int StudentsCount { get; set; }
		public string TitlePhoto { get; set; }
		public Location Location { get; set; }
		public bool InFavoriteList { get; set; }
	}
}