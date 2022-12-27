namespace Domain
{
	public class Specialty
	{
		public Guid Id { get; set; }

		public int Code { get; set; }

		public string? Name { get; set; }

		public string? Price { get; set; }
		
		public string? Info { get; set; }

		public bool BudgetAllowed { get; set; }
		
		public UniversitySpecialties? University { get; set; }

		public ICollection<SpecialtyDisciplines> Disciplines { get; set; } = new List<SpecialtyDisciplines>();
	}
}