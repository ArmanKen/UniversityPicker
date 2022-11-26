namespace Domain
{
	public class UniversitySpecialties
	{
		public Guid UniversityId { get; set; }

		public University? University { get; set; }

		public Guid SpecialtieId { get; set; }

		public Specialtie? Specialtie { get; set; }
	}
}