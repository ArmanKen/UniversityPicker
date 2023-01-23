using Application.Core;

namespace Application.Universities
{
	public class UniversityParams : PagingParams
	{
		public string Region { get; set; }
		public string City { get; set; }
		public string Degree { get; set; }
		public string SpecialtyBaseId { get; set; }
		public bool BudgetAllowed { get; set; }
		public string MinPrice { get; set; }		
		public string MaxPrice { get; set; }		
	}
}