namespace Domain
{
    public class MagisterSpecialty
    {
		public Guid SpecialtyId { get; set; }
		public Specialty Specialty { get; set; }
		public Guid UniversityId { get; set; }
		public University University { get; set; }
    }
}