using Domain;

namespace Application.DTOs
{
	public class Profile
	{
		public string Username { get; set; }
		public string FullName { get; set; }
		public string Bio { get; set; }
		public Photo Photo { get; set; }
		public CurrentStatus CurrentStatus { get; set; }
		public UniversityDto University { get; set; }
		public FacultyDto Faculty { get; set; }
		public SpecialtyBaseDto SpecialtyBase { get; set; }
		public Degree Degree { get; set; }
	}
}