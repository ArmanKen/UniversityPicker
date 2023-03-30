using Application.DTOs;
using Domain;

namespace Application.DropdownLists
{
	public class DropdownValues
	{
		public ICollection<Degree> Degrees { get; set; }
		public ICollection<Region> Regions { get; set; }
		public ICollection<CurrentStatus> CurrentStatuses { get; set; }
		public ICollection<KnowledgeBranchDto> KnowledgeBranches { get; set; }
		public ICollection<Language> Languages { get; set; }
		public ICollection<StudyForm> StudyForms { get; set; }
		public ICollection<Accreditation> Accreditations { get; set; }
	}
}