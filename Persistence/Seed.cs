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
					var City = new City { Name = "Київ", Region = new Region { Name = "Київ" } };
					var City1 = new City { Name = "Суми", Region = new Region { Name = "Сумська" } };
					var isced = new ISCED { Name = "IT", Id = "022" };
					var discipline = new Discipline { Name = "Філософія" };
					var discipline1 = new Discipline { Name = "Політологія" };
					var discipline2 = new SpecialtyDiscipline { Discipline = discipline1, IsOptional = true };
					var specialtyBase = new SpecialtyBase
					{
						Id = "121",
						Name = "Інженер програмного забезпечення",
						ISCEDs = new List<ISCED> { isced },
						AllDisciplines = new List<Discipline> { discipline }
					};
					var specialtyBase1 = new SpecialtyBase
					{
						Id = "122",
						Name = "Інженер програмного забезпечення",
						ISCEDs = new List<ISCED> { isced },
						AllDisciplines = new List<Discipline> { discipline }
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
						Disciplines = new List<SpecialtyDiscipline> { discipline2 }
					};
					var specialty1 = new Specialty
					{
						SpecialtyBase = specialtyBase1,
						PriceUAH = "10000",
						Description = "Info",
						BudgetAllowed = true,
						EctsCredits = 540,
						StartYear = 2023,
						EndYear = 2024,
						Degree = "Bachelor",
						Disciplines = new List<SpecialtyDiscipline> { discipline2 }
					};
					var specialty2 = new Specialty
					{
						SpecialtyBase = specialtyBase,
						PriceUAH = "20000",
						Description = "Info1",
						BudgetAllowed = true,
						EctsCredits = 540,
						StartYear = 2023,
						EndYear = 2024,
						Degree = "JunBachelor",
						Disciplines = new List<SpecialtyDiscipline> { discipline2 }
					};
					var university = new University
					{
						Name = "Дтеу",
						City = City,
						Address = "lol",
						Rating = 1,
						TimesRated = 2,
						Website = "www.knteu.edu.ua",
						Info = "lol",
						Telephone = "+3811111111",
						StudentsCount = 40000,
						BachelorSpecialties = new List<BachelorSpecialty> { new BachelorSpecialty { Specialty = specialty } },
						UniversityAdministrators = new List<UniversityAdministrator> { new UniversityAdministrator { AppUser = users[0] } },
						AppUserSelected = new List<SelectedUniversity> { new SelectedUniversity { AppUser = users[0] } }
					};
					await context.Universities.AddRangeAsync(university);
					var university1 = new University
					{
						Name = "2Дтеу",
						City = City1,
						Address = "lol",
						Rating = 1,
						TimesRated = 2,
						Website = "www.knteu.edu.ua",
						Info = "lol",
						Telephone = "+3811111111",
						StudentsCount = 40000,
						BachelorSpecialties = new List<BachelorSpecialty> { new BachelorSpecialty { Specialty = specialty1 } },
						UniversityAdministrators = new List<UniversityAdministrator> { new UniversityAdministrator { AppUser = users[0] } },
						AppUserSelected = new List<SelectedUniversity> { new SelectedUniversity { AppUser = users[0] } }
					};
					var university2 = new University
					{
						Name = "3Дтеу",
						City = City1,
						Address = "lol",
						Rating = 1,
						TimesRated = 2,
						Website = "www.knteu.edu.ua",
						Info = "lol",
						Telephone = "+3811111111",
						StudentsCount = 40000,
						JunBachelorSpecialties = new List<JunBachelorSpecialty> { new JunBachelorSpecialty { Specialty = specialty2 } },
						UniversityAdministrators = new List<UniversityAdministrator> { new UniversityAdministrator { AppUser = users[0] } },
						AppUserSelected = new List<SelectedUniversity> { new SelectedUniversity { AppUser = users[0] } }
					};
					await context.Universities.AddRangeAsync(university);
					await context.Universities.AddRangeAsync(university1);
					await context.Universities.AddRangeAsync(university2);
				}
			}
			await context.SaveChangesAsync();
		}
	}
}