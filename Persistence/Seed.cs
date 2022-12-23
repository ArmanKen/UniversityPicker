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
					Name = "Інженерія програмного забезпечення",
					Info = "Інформація про предмет Інженерія програмного забезпечення"
				},
				new Discipline
				{
					Name = "Філософія",
					Info = "Інформація про предмет Філософія"
				},
				new Discipline
				{
					Name = "Правознавство",
					Info = "Інформація про предмет Правознавство"
				},
				new Discipline
				{
					Name = "Операційні системи",
					Info = "Інформація про предмет Операційні системи"
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
					Code = 11,
					Price = "70000",
					Info = "Інформація про спеціальність Науки про освіту"
				},
				new Specialty
				{
					Name = "Інженер програмного забезпечення",
					Disciplines = new List<SpecialtyDisciplines>(
						disciplines.Select(x=>new SpecialtyDisciplines{Discipline=x})),
					Code = 121,
					Price = "120000",
					Info = "Інформація про спеціальність Інженер програмного забезпечення"
				},
				new Specialty
				{
					Name = "Кібербезпека",
					Disciplines = new List<SpecialtyDisciplines>(
						disciplines.Select(x=>new SpecialtyDisciplines{Discipline=x})),
					Code = 122,
					Price = "100000",
					Info = "Інформація про спеціальність Кібербезпека"
				}
			};

			if (context.Universities.Any()) return;
			var universities = new University
			{
				Name = "ДТЕУ",
				Specialties = new List<UniversitySpecialties>(specialties.Select(x => new UniversitySpecialties { Specialty = x })),
				Info = "Інформація про університет ДТЕУ"
			};
			await context.Disciplines.AddRangeAsync(disciplines);
			await context.Universities.AddRangeAsync(universities);
			await context.Specialties.AddRangeAsync(specialties);
			await context.SaveChangesAsync();
		}
	}
}