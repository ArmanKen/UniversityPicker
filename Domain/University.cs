namespace Domain
{
	public class University
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Region Region { get; set; }
		public City City { get; set; }
		public string Address { get; set; }
		public int Rating { get; set; }
		public int TimesRated { get; set; }
		public string Website { get; set; }
		public string Info { get; set; }
		public string Telephone { get; set; }
		public int StudentsCount { get; set; }
		public ICollection<Specialty> JunBachalor { get; set; } = new List<Specialty>();
		public ICollection<Specialty> Bachalor { get; set; } = new List<Specialty>();
		public ICollection<Specialty> Magister { get; set; } = new List<Specialty>();
		public ICollection<Comment> Comments { get; set; } = new List<Comment>();
	}
}