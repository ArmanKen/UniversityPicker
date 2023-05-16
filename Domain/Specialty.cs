namespace Domain
{
	public class Specialty
	{
		public Guid Id { get; set; }
		public SpecialtyBase SpecialtyBase { get; set; }
		public int PriceUAH { get; set; }
		public string Description { get; set; }
		public bool BudgetAllowed { get; set; }
		public int StartYear { get; set; } = DateTime.UtcNow.Year;
		public int EndYear { get; set; } = DateTime.UtcNow.Year + 1;
		public Degree Degree { get; set; }
		public Faculty Faculty { get; set; }
		public ICollection<Language> Languages { get; set; } = new List<Language>();
		public ICollection<StudyForm> StudyForms { get; set; } = new List<StudyForm>();
		public ICollection<EduComponent> EduComponents { get; set; } = new List<EduComponent>();
	}
}