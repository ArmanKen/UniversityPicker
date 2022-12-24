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
			var specialties2 = new List<Specialty>
			{
				new Specialty
				{
					Name = "Науки про освіту",
					Disciplines = new List<SpecialtyDisciplines>(
						disciplines.Skip(1).SkipLast(1).Select(x=>new SpecialtyDisciplines{Discipline=x})),
					Code = 11,
					Price = "50000",
					Info = "Інформація про спеціальність Науки про освіту"
				},
				new Specialty
				{
					Name = "Інженер програмного забезпечення",
					Disciplines = new List<SpecialtyDisciplines>(
						disciplines.Select(x=>new SpecialtyDisciplines{Discipline=x})),
					Code = 121,
					Price = "140000",
					Info = "Інформація про спеціальність Інженер програмного забезпечення"
				},
				new Specialty
				{
					Name = "Кібербезпека",
					Disciplines = new List<SpecialtyDisciplines>(
						disciplines.Select(x=>new SpecialtyDisciplines{Discipline=x})),
					Code = 122,
					Price = "130000",
					Info = "Інформація про спеціальність Кібербезпека"
				}
			};
			var specialties3 = new List<Specialty>
			{
				new Specialty
				{
					Name = "Науки про освіту",
					Disciplines = new List<SpecialtyDisciplines>(
						disciplines.Skip(1).SkipLast(1).Select(x=>new SpecialtyDisciplines{Discipline=x})),
					Code = 11,
					Price = "90000",
					Info = "Інформація про спеціальність Науки про освіту"
				},
				new Specialty
				{
					Name = "Інженер програмного забезпечення",
					Disciplines = new List<SpecialtyDisciplines>(
						disciplines.Select(x=>new SpecialtyDisciplines{Discipline=x})),
					Code = 121,
					Price = "180000",
					Info = "Інформація про спеціальність Інженер програмного забезпечення"
				},
				new Specialty
				{
					Name = "Кібербезпека",
					Disciplines = new List<SpecialtyDisciplines>(
						disciplines.Select(x=>new SpecialtyDisciplines{Discipline=x})),
					Code = 122,
					Price = "160000",
					Info = "Інформація про спеціальність Кібербезпека"
				}
			};

			var specialties4 = new List<Specialty>
			{
				new Specialty
				{
					Name = "Науки про освіту",
					Disciplines = new List<SpecialtyDisciplines>(
						disciplines.Skip(1).SkipLast(1).Select(x=>new SpecialtyDisciplines{Discipline=x})),
					Code = 11,
					Price = "60000",
					Info = "Інформація про спеціальність Науки про освіту"
				},
				new Specialty
				{
					Name = "Інженер програмного забезпечення",
					Disciplines = new List<SpecialtyDisciplines>(
						disciplines.Select(x=>new SpecialtyDisciplines{Discipline=x})),
					Code = 121,
					Price = "110000",
					Info = "Інформація про спеціальність Інженер програмного забезпечення"
				},
				new Specialty
				{
					Name = "Кібербезпека",
					Disciplines = new List<SpecialtyDisciplines>(
						disciplines.Select(x=>new SpecialtyDisciplines{Discipline=x})),
					Code = 122,
					Price = "90000",
					Info = "Інформація про спеціальність Кібербезпека"
				}
			};

			if (context.Universities.Any()) return;
			var universities = new University
			{
				Name = "ДТЕУ",
				Specialties = new List<UniversitySpecialties>(specialties.Select(x => new UniversitySpecialties { Specialty = x })),
				Info = "Інформація про університет ДТЕУ",
				Telephone = "+380 000 00 00",
				Address = "вул. Миру 1",
				City = "м.Київ",
				Region = "м.Київ",
				Rating = 99,
				Website = "knute.edu.ua/"
			};
			var universities2 = new University
			{
				Name = "КЕУ",
				Specialties = new List<UniversitySpecialties>(specialties2.Select(x => new UniversitySpecialties { Specialty = x })),
				Info = "Інформація про університет КЕУ",
				Telephone = "+380 111 11 11",
				Address = "вул. Миру 2",
				City = "м.Київ",
				Region = "м.Київ",
				Rating = 4,
				Website = "knute.edu.ua/"
			};
			var universities3 = new University
			{
				Name = "КАУ",
				Specialties = new List<UniversitySpecialties>(specialties3.Select(x => new UniversitySpecialties { Specialty = x })),
				Info = "Інформація про університет КАУ",
				Telephone = "+380 222 22 22",
				Address = "вул. Миру 3",
				City = "м.Київ",
				Region = "м.Київ",
				Rating = 1,
				Website = "knute.edu.ua/"
			};
			var universities4 = new University
			{
				Name = "КУХ",
				Specialties = new List<UniversitySpecialties>(specialties4.Select(x => new UniversitySpecialties { Specialty = x })),
				Info = "Інформація про університет КУХ",
				Telephone = "+380 333 33 33",
				Address = "вул. Миру 4",
				City = "м.Київ",
				Region = "м.Київ",
				Rating = 12,
				Website = "knute.edu.ua/"
			};
			
			await context.Disciplines.AddRangeAsync(disciplines);
			await context.Universities.AddRangeAsync(universities);
			await context.Universities.AddRangeAsync(universities2);
			await context.Universities.AddRangeAsync(universities3);
			await context.Universities.AddRangeAsync(universities4);
			await context.Specialties.AddRangeAsync(specialties);
			await context.Specialties.AddRangeAsync(specialties2);
			await context.Specialties.AddRangeAsync(specialties3);
			await context.Specialties.AddRangeAsync(specialties4);
			await context.SaveChangesAsync();
		}
	}
}