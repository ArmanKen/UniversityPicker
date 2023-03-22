namespace Domain
{
	public class StudyForm
	{
		public int Id { get; set; }
		public string Form { get; set; }
		public ICollection<Specialty> Specialties { get; set; } = new List<Specialty>();
	}
}