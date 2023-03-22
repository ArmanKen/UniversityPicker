namespace Domain
{
	public class Specialty
	{
		public Guid Id { get; set; }
		public SpecialtyBase SpecialtyBase { get; set; }
		public int PriceUAH { get; set; }
		public string Description { get; set; }
		public bool BudgetAllowed { get; set; }
		public int Year { get; set; }
		public Degree Degree { get; set; }
		public Faculty Faculty { get; set; }
		public ICollection<Language> Languages { get; set; } = new List<Language>();
		public ICollection<StudyForm> StudyForms { get; set; } = new List<StudyForm>();
		public ICollection<EduComponent> EduComponents { get; set; } = new List<EduComponent>();
	}
}