using Domain;

namespace Application.Profiles
{
	public class Profile
	{
		public string Username { get; set; }
		public string DisplayName { get; set; }
		public string Bio { get; set; }
		public SpecialtyBase Specialty { get; set; }
		public Photo Photo { get; set; }
		public string Degree { get; set; }
	}
}