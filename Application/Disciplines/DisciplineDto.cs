namespace Application.Disciplines
{
	public class DisciplineDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Info { get; set; }
		public bool IsOptional { get; set; }
	}
}