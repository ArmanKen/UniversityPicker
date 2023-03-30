using Domain;

namespace Application.DTOs
{
	public class ReviewDto
	{
		public Guid Id { get; set; }
		public int Rating { get; set; }
		public string Body { get; set; }
		public string UserName { get; set; }
		public string FullName { get; set; }
		public string Image { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}