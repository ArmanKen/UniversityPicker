namespace Domain
{
	public class Faculty
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Info { get; set; }
		public int StudentsCount { get; set; }
		public Photo FacultyPhoto { get; set; }
		public HigherEducationFacility HigherEducationFacility { get; set; }
		public ICollection<KnowledgeBranch> KnowledgeBranches { get; set; } = new List<KnowledgeBranch>();
		public ICollection<Specialty> Specialties { get; set; } = new List<Specialty>();
	}
}