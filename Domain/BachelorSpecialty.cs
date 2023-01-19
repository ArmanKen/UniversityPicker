namespace Domain
{
	public class BachelorSpecialty
	{
		public Guid SpecialtyId { get; set; }
		public Specialty Specialty { get; set; }
		public Guid UniversityId { get; set; }
		public University University { get; set; }
	}
}