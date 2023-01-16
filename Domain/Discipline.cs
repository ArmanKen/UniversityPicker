namespace Domain;
public class Discipline
{
	public int Id { get; set; }
	public string Name { get; set; }
	public ICollection<SpecialtyDisciplines> Specialties { get; set; } = new List<SpecialtyDisciplines>();
}
