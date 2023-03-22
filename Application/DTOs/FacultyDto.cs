using Domain;

namespace Application.DTOs
{
	public class FacultyDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Info { get; set; }
		public int StudentsCount { get; set; }
		public Photo FacultyPhoto { get; set; }
		public ICollection<Language> Languages { get; set; }
		public ICollection<StudyForm> StudyForms { get; set; }
		public ICollection<KnowledgeBranchDto> KnowledgeBranches { get; set; }
	}
}