using Domain;

namespace API.DTOs
{
	public class UserDTO
	{
		public string FullName { get; set; }
		public string Token { get; set; }
		public string Username { get; set; }
		public string Image { get; set; }
		public bool isGlobalAdmin { get; set; }
		public ICollection<HigherEducationFacilityAdmin> HigherEducationFacilitiesAdmin { get; set; } = new List<HigherEducationFacilityAdmin>();
	}
}