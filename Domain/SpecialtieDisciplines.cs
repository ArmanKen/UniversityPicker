namespace Domain
{
    public class SpecialtieDisciplines
    {
        public Guid SpecialtieId { get; set; }

		public Specialtie? Specialtie { get; set; }

		public Guid DisciplineId { get; set; }

		public Discipline? Discipline { get; set; }
    }
}