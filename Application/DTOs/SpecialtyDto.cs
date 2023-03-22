namespace Application.DTOs
{
	public class SpecialtyDto
	{
		public Guid Id { get; set; }
		public string SpecialtyBaseId { get; set; }
		public string Name { get; set; }
		public ICollection<IscedDto> Isceds { get; set; }
		public string PriceUAH { get; set; }
		public string Description { get; set; }
		public bool BudgetAllowed { get; set; }
		public int EctsCredits { get; set; }
		public int Year { get; set; }
		public string Degree { get; set; }
	}
}