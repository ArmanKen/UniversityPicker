using Application.Core;

namespace Application.Universities
{
	public class UniversityParams : UniversityPagingParams
	{
		public string Name { get; set; }
		public string Region { get; set; }
		public string City { get; set; }
		public string BranchBaseId { get; set; }
		public string Degree { get; set; }
		public string SpecialtyBaseId { get; set; }
		public string Budget { get; set; }
		public string MinPrice { get; set; }
		public string MaxPrice { get; set; }
		public string UkraineTop { get; set; }
		public string AccreditationId { get; set; }
	}
}