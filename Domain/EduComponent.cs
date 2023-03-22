namespace Domain;
public class EduComponent
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Info { get; set; }
	public int EctsCredits { get; set; }
	public bool IsOptional { get; set; }
	public Specialty Specialty { get; set; }
}