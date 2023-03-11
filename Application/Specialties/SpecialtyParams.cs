using Application.Core;

namespace Application.Specialties
{
	public class SpecialtyParams : SpecialtyPagingParams
	{
		public string SpecialtyName { get; set; }
		public string SpecialtyBaseId { get; set; }
	}
}