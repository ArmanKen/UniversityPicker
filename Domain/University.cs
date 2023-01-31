namespace Domain
{
	public class University
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public City City { get; set; }
		public string Address { get; set; }
		public int Rating { get; set; }
		public int TimesRated { get; set; }
		public string Website { get; set; }
		public string Info { get; set; }
		public string Telephone { get; set; }
		public int StudentsCount { get; set; }
		public Photo TitlePhoto { get; set; } = new Photo();
		public ICollection<Photo> Photos { get; set; } = new List<Photo>();
		public ICollection<Specialty> Specialties { get; set; } = new List<Specialty>();
		public ICollection<Comment> Comments { get; set; } = new List<Comment>();
		public ICollection<UniversityAdministrator> UniversityAdministrators { get; set; } = new List<UniversityAdministrator>();
		public ICollection<SelectedUniversity> AppUserSelected { get; set; } = new List<SelectedUniversity>();
	}
}