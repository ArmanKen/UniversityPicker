namespace Domain
{
	public class SpecialtyDisciplines
	{
		public Guid SpecialtyId { get; set; }
		public Specialty Specialty { get; set; }
		public Guid DisciplineId { get; set; }
		public Discipline Discipline { get; set; }
		public bool IsOptional { get; set; }
	}
}