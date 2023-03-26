using Microsoft.AspNetCore.Identity;

namespace Domain
{
	public class AppUser : IdentityUser
	{
		public string FullName { get; set; }
		public string Bio { get; set; }
		public Photo Photo { get; set; }
		public CurrentStatus CurrentStatus { get; set; }
		public University University { get; set; }
		public SpecialtyBase SpecialtyBase { get; set; }
		public Degree Degree { get; set; }
		public bool IsGlobalAdmin { get; set; }
		public ICollection<Review> Reviews { get; set; }
		public ICollection<UniversityAdmin> UniversitiesAdmin { get; set; } = new List<UniversityAdmin>();
		public ICollection<FavoriteList> FavoriteList { get; set; } = new List<FavoriteList>();
	}
}