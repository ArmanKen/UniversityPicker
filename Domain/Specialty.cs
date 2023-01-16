namespace Domain
{
	public class Specialty
	{
		public Guid Id { get; set; }
		public string PriceUAH { get; set; }
		public string Description { get; set; }
		public bool BudgetAllowed { get; set; }
		public int EctsCredits { get; set; }
		public int StartYear { get; set; }
		public int EndYear { get; set; }
		public string Grade { get; set; } // to bad?
		public University University { get; set; }
		public ICollection<SpecialtyDisciplines> Disciplines { get; set; } = new List<SpecialtyDisciplines>();
	}
}