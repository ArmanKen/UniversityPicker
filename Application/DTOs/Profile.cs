using Domain;

namespace Application.DTOs
{
	public class Profile
	{
		public string Username { get; set; }
		public string FullName { get; set; }
		public string Bio { get; set; }
		public Photo Photo { get; set; }
		public int CurrentStatus { get; set; }
		public InstitutionDto Institution { get; set; }
		public int SpecialtyBase { get; set; }
		public int Degree { get; set; }
	}
}