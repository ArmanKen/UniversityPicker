using Application.Universities;
using Domain;

namespace Application.Profiles
{
	public class Profile
	{
		public string Username { get; set; }
		public string DisplayName { get; set; }
		public string Bio { get; set; }
		public string Specialty { get; set; }
		public University University { get; set; }
		public Photo Photo { get; set; }
		public string Degree { get; set; }
		public ICollection<UniversityDto> SelectedUniversities { get; set; }
	}
}