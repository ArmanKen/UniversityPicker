using Application.Specialties;

namespace Application.Universities
{
	public class UniversityDto
	{
		public Guid Id { get; set; }

		public string? Name { get; set; }

		public string? Region { get; set; }

		public string? City { get; set; }

		public string? Address { get; set; }

		public string? Website { get; set; }

		public string? ShortInfo { get; set; }

		public string? FullInfo { get; set; }

		public int Rating { get; set; }

		public string? Telephone { get; set; }

		public ICollection<SpecialtyDto>? Specialties { get; set; }
	}
}