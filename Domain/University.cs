namespace Domain
{
	public class University
	{
		public Guid Id { get; set; }

		public string? Name { get; set; }

		public string? Region { get; set; }

		public string? City { get; set; }

		public string? Address { get; set; }

		public string? Website { get; set; }

		public string? Info { get; set; }

		public int Rating { get; set; }

		public ICollection<UniversitySpecialties> Specialties { get; set; } = new List<UniversitySpecialties>();
	}
}