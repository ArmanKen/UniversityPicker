using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
	public class Seed
	{
		public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
		{
			if (!userManager.Users.Any())
			{
				var users = new List<AppUser>
				{
					new AppUser
					{
						DisplayName = "Bob",
						UserName = "bob",
						Email = "bob@test.com",
						Bio="1"
					},
					new AppUser
					{
						DisplayName = "Jane",
						UserName = "jane",
						Email = "jane@test.com",
						Bio="2"
					},
					new AppUser
					{
						DisplayName = "Tom",
						UserName = "tom",
						Email = "tom@test.com",
						Bio="3"
					},
				};
				foreach (var user in users)
				{
					await userManager.CreateAsync(user, "Pa$$w0rd");
				}
				if (!context.City.Any())
				{
					var region = new Region { Name = "Київ", Cities = new City[] { new City { Name = "Київ" } } };
					var isced = new ISCED { Name = "IT", Id = "022" };
					var discipline = new Discipline { Name = "Філософія" };
					var discipline1 = new Discipline { Name = "Політологія" };
					var discipline2 = new SpecialtyDiscipline { Discipline = discipline1, IsOptional = true };
					var specialtyBase = new SpecialtyBase
					{
						Id = "121",
						Name = "Інженер програмного забезпечення",
						ISCEDs = new ISCED[] { isced },
						AllDisciplines = new Discipline[] { discipline }
					};
					var specialty = new Specialty
					{
						SpecialtyBase = specialtyBase,
						PriceUAH = "10000",
						Description = "Info",
						BudgetAllowed = true,
						EctsCredits = 540,
						StartYear = 2023,
						EndYear = 2024,
						Degree = "Bachelor",
						Disciplines = new SpecialtyDiscipline[] { discipline2 }
					};
					var university = new University
					{
						Name = "Дтеу",
						Region = region,
						Address = "lol",
						Rating = 1,
						TimesRated = 2,
						Website = "www.knteu.edu.ua",
						Info = "lol",
						Telephone = "+3811111111",
						StudentsCount = 40000,
						BachelorSpecialties = new BachelorSpecialty[] { new BachelorSpecialty { Specialty = specialty } },
						UniversityAdministrators = new UniversityAdministrator[] { new UniversityAdministrator { AppUser = users[0] } },
						AppUserSelected = new SelectedUniversity[] { new SelectedUniversity { AppUser = users[0] } }
					};
					await context.Universities.AddRangeAsync(university);
				}
			}
			// await context.Disciplines.AddRangeAsync(disciplines);
			// await context.Universities.AddRangeAsync(universities);
			// await context.Specialties.AddRangeAsync(specialties);
			await context.SaveChangesAsync();
		}
	}
}