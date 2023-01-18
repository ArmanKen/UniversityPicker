namespace Domain;
public class Discipline
{
	public int Id { get; set; }
	public string Name { get; set; }
	public ICollection<SpecialtyDiscipline> Specialties { get; set; } = new List<SpecialtyDiscipline>();
	public ICollection<SpecialtyBase> BasedSpecialties { get; set; } = new List<SpecialtyBase>();
}
