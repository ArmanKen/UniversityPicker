namespace Domain;
public class Discipline
{
	public Guid Id { get; set; }

	public string? Name { get; set; }

	public string? Info { get; set; }

	public bool Optional { get; set; }

	public ICollection<SpecialtyDisciplines> Specialties { get; set; } = new List<SpecialtyDisciplines>();
}
