namespace Application.DTOs
{
    public class KnowledgeBranchDto
    {
		public string Id { get; set; }
		public string Name { get; set; }
		public ICollection<SpecialtyBaseDto> SpecialtyBases { get; set; }
    }
}