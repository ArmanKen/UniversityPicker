using Domain;

namespace Persistence
{
	public class Seed
	{
		public static async Task SeedData(DataContext context)
		{
			if (context.Disciplines.Any()) return;
			var disciplines = new List<Discipline>
			{
				new Discipline
				{
					Name = "Інженерія програмного забезпечення"
				},
				new Discipline
				{
					Name = "Філософія"
				},
				new Discipline
				{
					Name = "Правознавство"
				},
				new Discipline
				{
					Name = "Операційні системи"
				}
			};

			if (context.Specialties.Any()) return;
			var specialties = new List<Specialty>
			{
				new Specialty
				{
					Name = "Науки про освіту",
					Disciplines = new List<SpecialtyDisciplines>(
						disciplines.Skip(1).SkipLast(1).Select(x=>new SpecialtyDisciplines{Discipline=x})),
					Code = 11
				},
				new Specialty
				{
					Name = "Інженер програмного забезпечення",
					Disciplines = new List<SpecialtyDisciplines>(
						disciplines.Select(x=>new SpecialtyDisciplines{Discipline=x})),
					Code = 121
				},
				new Specialty
				{
					Name = "Кібербезпека",
					Disciplines = new List<SpecialtyDisciplines>(
						disciplines.Select(x=>new SpecialtyDisciplines{Discipline=x})),
					Code = 122
				}
			};

			if (context.Universities.Any()) return;
			var universities = new University
			{
				Name = "ДТЕУ",
				Specialties = new List<UniversitySpecialties>(specialties.Select(x => new UniversitySpecialties { Specialty = x }))
			};
			await context.Disciplines.AddRangeAsync(disciplines);
			await context.Universities.AddRangeAsync(universities);
			await context.Specialties.AddRangeAsync(specialties);
			await context.SaveChangesAsync();
		}
	}
}