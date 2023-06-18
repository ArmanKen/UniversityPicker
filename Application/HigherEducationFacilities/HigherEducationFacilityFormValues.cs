using Domain;

namespace Application.DTOs
{
	public class HigherEducationFacilityFormValues
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Accreditation { get; set; }
		public int Region { get; set; }
		public int City { get; set; }
		public string Address { get; set; }
		public string Website { get; set; }
		public string Info { get; set; }
		public string Telephone { get; set; }
		public int UkraineTop { get; set; }
		public double LocationLong { get; set; }
		public double LocationLat { get; set; }
	}
}