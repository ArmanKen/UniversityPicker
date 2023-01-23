using Application.Disciplines;
using Application.SpecialtiesBases;
using Domain;

namespace Application.Specialties
{
	public class SpecialtyDto
	{
		public Guid Id { get; set; }
		public string SpecialtyBaseId { get; set; }
		public string Name { get; set; }
		public ICollection<ISCED> ISCEDs { get; set; } = new List<ISCED>();
		public string PriceUAH { get; set; }
		public string Description { get; set; }
		public bool BudgetAllowed { get; set; }
		public int EctsCredits { get; set; }
		public int StartYear { get; set; }
		public int EndYear { get; set; }
		public string Degree { get; set; }
	}
}