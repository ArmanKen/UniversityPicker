namespace Domain
{
	public class SpecialtyBase
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public ICollection<Specialty> Specialties { get; set; } = new List<Specialty>();
		public ICollection<Isced> Isceds { get; set; } = new List<Isced>();
		public ICollection<Discipline> AllDisciplines { get; set; } = new List<Discipline>();
	}
}