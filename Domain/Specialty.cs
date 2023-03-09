namespace Domain
{
	public class Specialty
	{
		public Guid Id { get; set; }
		public SpecialtyBase SpecialtyBase { get; set; }
		public int PriceUAH { get; set; }
		public string Description { get; set; }
		public bool BudgetAllowed { get; set; }
		public int EctsCredits { get; set; }
		public int StartYear { get; set; }
		public int EndYear { get; set; }
		public Degree Degree { get; set; }
		public University University { get; set; }
		public ICollection<SpecialtyDiscipline> Disciplines { get; set; } = new List<SpecialtyDiscipline>();
	}
}