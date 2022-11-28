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
			if (context.BranchesOfKnowledge.Any()) return;
			var branchesOfKnowledge = new List<BranchOfKnowledge>
			{
				new BranchOfKnowledge
				{
					Name = "Освіта"
				},
				new BranchOfKnowledge
				{
					Name = "Культура і мистецтво"
				},
				new BranchOfKnowledge
				{
					Name = "Гуманітарні науки"
				},
				new BranchOfKnowledge
				{
					Name = "Богослов’я"
				},
				new BranchOfKnowledge
				{
					Name = "Соціальні та поведінкові науки"
				},
				new BranchOfKnowledge
				{
					Name = "Управління та адміністрування"
				},
				new BranchOfKnowledge
				{
					Name = "Право"
				},
				new BranchOfKnowledge
				{
					Name = "Біологія"
				},
				new BranchOfKnowledge
				{
					Name = "Природничі науки"
				},
				new BranchOfKnowledge
				{
					Name = "Математика та статистика"
				},
				new BranchOfKnowledge
				{
					Name = "Інформаційні технології"
				},
				new BranchOfKnowledge
				{
					Name = "Механічна інженерія"
				},
				new BranchOfKnowledge
				{
					Name = "Електрична інженерія"
				},
				new BranchOfKnowledge
				{
					Name = "Автоматизація та приладобудування"
				},
				new BranchOfKnowledge
				{
					Name = "Хімічна та біоінженерія"
				},
				new BranchOfKnowledge
				{
					Name = "Електроніка та телекомунікації"
				},
				new BranchOfKnowledge
				{
					Name = "Виробництво та технології"
				},
				new BranchOfKnowledge
				{
					Name = "Архітектура та будівництво"
				},
				new BranchOfKnowledge
				{
					Name = "Аграрні науки та продовольство"
				},
				new BranchOfKnowledge
				{
					Name = "Електрична інженерія"
				},
				new BranchOfKnowledge
				{
					Name = "Ветеринарна медицина"
				},
				new BranchOfKnowledge
				{
					Name = "Охорона здоров’я"
				},
				new BranchOfKnowledge
				{
					Name = "Соціальна робота"
				},
				new BranchOfKnowledge
				{
					Name = "Сфера обслуговування"
				},
				new BranchOfKnowledge
				{
					Name = "Воєнні науки, національна безпека, безпека державного кордону"
				},
				new BranchOfKnowledge
				{
					Name = "Цивільна безпека"
				},
				new BranchOfKnowledge
				{
					Name = "Транспорт"
				}
			};
			if (context.Specialties.Any()) return;
			var specialties = new List<Specialty>
			{
				new Specialty
				{
					Name = "Інженер програмного забезпечення",
					BranchOfKnowledge=new BranchOfKnowledgeSpecialties
					{
						BranchOfKnowledge = branchesOfKnowledge[10]
					},
					Disciplines = new List<SpecialtieDisciplines>
					{
						new SpecialtieDisciplines
						{
							Discipline = disciplines[0]
						},
						new SpecialtieDisciplines
						{
							Discipline = disciplines[1]
						},
						new SpecialtieDisciplines
						{
							Discipline = disciplines[2]
						}
					},
					Code = 121
				},
				new Specialty
				{
				Name = "Кібербезпека",
				BranchOfKnowledge=new BranchOfKnowledgeSpecialties
				{
					BranchOfKnowledge = branchesOfKnowledge[10]
				},
				Disciplines = new List<SpecialtieDisciplines>
					{
						new SpecialtieDisciplines
						{
							Discipline = disciplines[0]
						},
						new SpecialtieDisciplines
						{
							Discipline = disciplines[1]
						},
						new SpecialtieDisciplines
						{
							Discipline = disciplines[2]
						}
					},
				Code = 122
				}
			};

			if (context.Universities.Any()) return;
			var universities = new University
			{
				Name = "ДТЕУ",
				Specialties = new List<UniversitySpecialties>
				{
					new UniversitySpecialties
					{
						Specialty = specialties[0]
					},
					new UniversitySpecialties
					{
						Specialty = specialties[1]
					}
				}
			};
			await context.BranchesOfKnowledge.AddRangeAsync(branchesOfKnowledge);
			await context.Disciplines.AddRangeAsync(disciplines);
			await context.Universities.AddRangeAsync(universities);
			await context.Specialties.AddRangeAsync(specialties);
			await context.SaveChangesAsync();
		}
	}
}