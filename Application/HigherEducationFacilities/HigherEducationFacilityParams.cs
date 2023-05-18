using Application.Core;

namespace Application.HigherEducationFacilities
{
	public class HigherEducationFacilityParams : HigherEducationFacilityPagingParams
	{
		public string Name { get; set; }
		public string AccreditationId { get; set; }
		public string RegionsId { get; set; }
		public string CitiesId { get; set; }
		public string KnowledgeBranchesId { get; set; }
		public string DegreeId { get; set; }
		public string SpecialtyBasesId { get; set; }
		public string MinPrice { get; set; }
		public string MaxPrice { get; set; }
		public string Budget { get; set; }
		public string UkraineTop { get; set; }
	}
}