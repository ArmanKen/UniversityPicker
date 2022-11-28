namespace Domain
{
	public class Specialty
	{
		public Guid Id { get; set; }

		public int Code { get; set; }

		public string? Name { get; set; }

		public UniversitySpecialties? University { get; set; }

		public BranchOfKnowledgeSpecialties? BranchOfKnowledge { get; set; }

		public ICollection<SpecialtieDisciplines>? Disciplines { get; set; }
	}
}