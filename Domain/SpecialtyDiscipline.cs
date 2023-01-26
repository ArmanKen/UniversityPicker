namespace Domain
{
	public class SpecialtyDiscipline
	{
		public Guid SpecialtyId { get; set; }
		public Specialty Specialty { get; set; }
		public int DisciplineId { get; set; }
		public Discipline Discipline { get; set; }
		public int EctsCredits { get; set; }
		public bool IsOptional { get; set; }
	}
}