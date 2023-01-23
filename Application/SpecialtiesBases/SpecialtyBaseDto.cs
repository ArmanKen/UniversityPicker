using Domain;

namespace Application.SpecialtiesBases
{
	public class SpecialtyBaseDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public ICollection<ISCED> ISCEDs { get; set; } = new List<ISCED>();
	}
}