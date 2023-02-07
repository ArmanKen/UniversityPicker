namespace Application.DTOs
{
	public class SpecialtyBaseDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public ICollection<IscedDto> Isceds { get; set; }
	}
}