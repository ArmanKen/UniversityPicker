namespace Domain
{
	public class University
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Region Region { get; set; }
		public City City { get; set; }
		public Location Location { get; set; }
		public Accreditation Accreditation { get; set; }
		public string Address { get; set; }
		public string Website { get; set; }
		public string Info { get; set; }
		public string Telephone { get; set; }
		public int UkraineTop { get; set; }
		public Photo TitlePhoto { get; set; }
		public ICollection<Photo> Photos { get; set; } = new List<Photo>();
		public ICollection<Faculty> Faculties { get; set; } = new List<Faculty>();
		public ICollection<Review> Reviews { get; set; } = new List<Review>();
		public ICollection<UniversityAdmin> UniversityAdmins { get; set; } = new List<UniversityAdmin>();
		public ICollection<FavoriteList> FavoriteList { get; set; } = new List<FavoriteList>();
	}
}