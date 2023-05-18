using Domain;

namespace Application.DTOs
{
	public class SpecialtyDto
	{
		public Guid Id { get; set; }
		public Guid HigherEducationFacilityId { get; set; }
		public Guid FacultyId { get; set; }
		public SpecialtyBaseIscedDto SpecialtyBase { get; set; }
		public Degree Degree { get; set; }
		public string PriceUAH { get; set; }
		public string Description { get; set; }
		public bool BudgetAllowed { get; set; }
		public int EctsCredits { get; set; }
		public int StartYear { get; set; }
		public int EndYear { get; set; }
		public ICollection<LanguageDto> Languages { get; set; }
		public ICollection<StudyFormDto> StudyForms { get; set; }
	}
}