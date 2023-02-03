using Microsoft.AspNetCore.Identity;

namespace Domain
{
	public class AppUser : IdentityUser
	{
		public string DisplayName { get; set; }
		public string Bio { get; set; }
		public University University { get; set; }
		public string Specialty { get; set; }
		public Photo Photo { get; set; }
		public string Degree { get; set; }
		public bool IsGlobalAdmin { get; set; }
		public ICollection<UniversityAdministrator> UniversityAdministration { get; set; } = new List<UniversityAdministrator>();
		public ICollection<SelectedUniversity> SelectedUniversities { get; set; } = new List<SelectedUniversity>();
	}
}