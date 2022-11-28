namespace Domain
{
	public class UniversitySpecialties
	{
		public Guid UniversityId { get; set; }

		public University? University { get; set; }

		public Guid SpecialtyId { get; set; }

		public Specialty? Specialty { get; set; }
	}
}