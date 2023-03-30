using Domain;

namespace Application.DTOs
{
	public class SpecialtyDto
	{
		public Guid Id { get; set; }
		public SpecialtyBaseDto SpecialtyBase { get; set; }
		public Degree Degree { get; set; }
		public string PriceUAH { get; set; }
		public string Description { get; set; }
		public bool BudgetAllowed { get; set; }
		public int EctsCredits { get; set; }
		public int Year { get; set; }
		public ICollection<Language> Languages { get; set; }
		public ICollection<StudyForm> StudyForms { get; set; }
	}
}