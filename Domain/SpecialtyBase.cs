namespace Domain
{
	public class SpecialtyBase
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public ICollection<ISCED> ISCED { get; set; } = new List<ISCED>();
		public ICollection<Discipline> AllDisciplines { get; set; } = new List<Discipline>();
	}
}