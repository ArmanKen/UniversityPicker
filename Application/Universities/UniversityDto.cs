using Application.Specialties;
using Domain;

namespace Application.Universities
{
	public class UniversityDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Region { get; set; }
		public string City { get; set; }
		public string Address { get; set; }
		public int Rating { get; set; }
		public int TimesRated { get; set; }
		public string Website { get; set; }
		public string Info { get; set; }
		public string Telephone { get; set; }
		public int StudentsCount { get; set; }
		public SpecialtyDto Specialty { get; set; }
	}
}