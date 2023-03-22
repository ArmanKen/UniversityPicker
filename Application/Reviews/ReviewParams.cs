using Application.Core;

namespace Application.Reviews
{
	public class ReviewParams : ReviewPagingParams
	{
		public string BadRating { get; set; }
		public string GoodRating { get; set; }
		public string FacultyId { get; set; }
	}
}