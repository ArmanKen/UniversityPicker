namespace Domain
{
    public class BachelorSpecilaty
    {
		public Guid SpecialtyId { get; set; }
		public Specialty Specilaty { get; set; }
		public Guid UniversityId { get; set; }
		public University University { get; set; }
    }
}