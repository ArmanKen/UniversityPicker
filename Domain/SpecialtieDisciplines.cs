namespace Domain
{
    public class SpecialtieDisciplines
    {
        public Guid SpecialtyId { get; set; }

		public Specialty? Specialty { get; set; }

		public Guid DisciplineId { get; set; }

		public Discipline? Discipline { get; set; }
    }
}