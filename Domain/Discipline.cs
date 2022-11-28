namespace Domain;
public class Discipline
{
	public Guid Id { get; set; }

	public string? Name { get; set; }

	public ICollection<SpecialtieDisciplines> Specialties { get; set; } = new List<SpecialtieDisciplines>();
}
