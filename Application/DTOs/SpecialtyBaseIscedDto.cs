namespace Application.DTOs
{
	public class SpecialtyBaseIscedDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public ICollection<IscedDto> Isceds { get; set; }
	}
}