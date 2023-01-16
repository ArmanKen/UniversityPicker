namespace Domain
{
	public class SpecialtyBase
	{
		public int Code { get; set; }
		public string Name { get; set; }
		public ICollection<SpecialtyBaseDisciplines> AllDisciplines { get; set; } = new List<SpecialtyBaseDisciplines>();
	}
}