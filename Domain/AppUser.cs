using Microsoft.AspNetCore.Identity;

namespace Domain
{
	public class AppUser : IdentityUser
	{
		public string DisplayName { get; set; }
		public string Bio { get; set; }
		public University University { get; set; }
		public SpecialtyBase Specialty { get; set; }
		public Photo Photo { get; set; }
		public string Grade { get; set; }
		public ICollection<University> Favorites { get; set; } = new List<University>();
	}
}