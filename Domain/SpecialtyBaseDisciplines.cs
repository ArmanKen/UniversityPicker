namespace Domain
{
	public class SpecialtyBaseDisciplines
	{
		public Guid SpecialtyBaseId { get; set; }
		public SpecialtyBase SpecialtyBase { get; set; }
		public Guid DisciplineId { get; set; }
		public Discipline Discipline { get; set; }
	}
}