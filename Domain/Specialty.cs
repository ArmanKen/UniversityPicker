namespace Domain
{
	public class Specialty
	{
		public Guid Id { get; set; }
		public SpecialtyBase SpecialtyBase { get; set; }
		public string PriceUAH { get; set; }
		public string Description { get; set; }
		public bool BudgetAllowed { get; set; }
		public int EctsCredits { get; set; }
		public int StartYear { get; set; }
		public int EndYear { get; set; }
		public string Degree { get; set; } 
		public JunBachelorSpecialty JunBachelor { get; set; }
		public BachelorSpecialty Bachelor { get; set; }
		public MagisterSpecialty Magister { get; set; }
		public ICollection<SpecialtyDiscipline> Disciplines { get; set; } = new List<SpecialtyDiscipline>();
	}
}