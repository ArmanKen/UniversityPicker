using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
	public class Seed
	{
		public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
		{
			if (!userManager.Users.Any())
			{

				var degrees = new List<Degree>
{
new Degree{Name="Junior Bachelor"},
new Degree{Name="Bachelor"},
new Degree{Name="Master"}
};
				await context.Degrees.AddRangeAsync(degrees);

				var accreditation = new List<Accreditation>
{
new Accreditation{AccreditationLevel="I"},
new Accreditation{AccreditationLevel="II"},
new Accreditation{AccreditationLevel="III"},
new Accreditation{AccreditationLevel="IV"},
};
				await context.Accreditations.AddRangeAsync(accreditation);

				var languages = new List<Language>
{
new Language
{
Id = "English",
Name = "en"
},
new Language
{
Id = "Ukrainian",
Name = "uk"
},
new Language
{
Id = "French",
Name = "fr"
}
};
				await context.Languages.AddRangeAsync(languages);

				var studyForms = new List<StudyForm>
{
new StudyForm{Form = "Full-time"},
new StudyForm{Form = "Part-time"},
new StudyForm{Form = "Mixed"},
};
				await context.StudyForms.AddRangeAsync(studyForms);

				var currentStatuses = new List<CurrentStatus>
{
new CurrentStatus{Status="Study at school"},
new CurrentStatus{Status="Looking for college"},
new CurrentStatus{Status="Study in college"},
new CurrentStatus{Status="I'm looking for a university"},
new CurrentStatus{Status="I study at university"},
new CurrentStatus{Status="I work by profession"},
new CurrentStatus{Status="I'm not working by profession"}
};
				await context.CurrentStatuses.AddRangeAsync(currentStatuses);

				var users = new List<AppUser>
{
new AppUser
{
FullName = "GlobalAdmin",
UserName = "GlobalAdmin1",
Email = "GlobalAdmin@test.com",
Bio="GlobalAdmin!",
IsGlobalAdmin = true,
CurrentStatus = currentStatuses[1],
},
new AppUser
{
FullName = "LocalAdmin",
UserName = "LocalAdmin1",
Email = "LocalAdmin@test.com",
Bio="LocalAdmin!",
CurrentStatus = currentStatuses[0],
},
new AppUser
{
FullName = "User",
UserName = "User1",
Email = "User@test.com",
Bio="User!",
CurrentStatus = currentStatuses[2],
},
};
				foreach (var user in users)
				{
					await userManager.CreateAsync(user, "Pa$$w0rd");
				}

				var regions = new List<Region>
					{
						new Region
						{
							Name = "м. Севастополь",
							Cities = new List<City>
							{
								new City
								{
									Name = "Севастополь"
								},
								new City
								{
									Name = "Інкерман"
								},
							},
						},
						new Region
						{
							Name = "АР Крим",
							Cities = new List<City>
							{
								new City
								{
									Name = "Алупка"
								},
								new City
								{
									Name = "Алушта"
								},
								new City
								{
									Name = "Армянськ"
								},
								new City
								{
									Name = "Бахчисарай"
								},
								new City
								{
									Name = "Білогірськ"
								},
								new City
								{
									Name = "Джанкой"
								},
								new City
								{
									Name = "Євпаторія"
								},
								new City
								{
									Name = "Керч"
								},
								new City
								{
									Name = "Красноперекопськ(Яни Капу)"
								},
								new City
								{
									Name = "Саки"
								},
								new City
								{
									Name = "Сімферополь"
								},
								new City
								{
									Name = "Старий Крим"
								},
								new City
								{
									Name = "Судак"
								},
								new City
								{
									Name = "Феодосія"
								},
								new City
								{
									Name = "Щолкіне"
								},
								new City
								{
									Name = "Ялта"
								},
							}
						},
						new Region
						{
							Name = "Вінницька область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Бар"
								},
								new City
								{
									Name = "Бершадь"
								},
								new City
								{
									Name = "Вінниця"
								},
								new City
								{
									Name = "Гайсин"
								},
								new City
								{
									Name = "Гнівань"
								},
								new City
								{
									Name = "Жмеринка"
								},
								new City
								{
									Name = "Іллінці"
								},
								new City
								{
									Name = "Калинівка"
								},
								new City
								{
									Name = "Козятин"
								},
								new City
								{
									Name = "Ладижин"
								},
								new City
								{
									Name = "Липовець"
								},
								new City
								{
									Name = "Могилів-Подільський"
								},
								new City
								{
									Name = "Немирів"
								},
								new City
								{
									Name = "Погребище"
								},
								new City
								{
									Name = "Тульчин"
								},
								new City
								{
									Name = "Хмільник"
								},
								new City
								{
									Name = "Шаргород"
								},
								new City
								{
									Name = "Ямпіль"
								},
							}
						},
						new Region
						{
							Name = "Волинська область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Берестечко"
								},
								new City
								{
									Name = "Володимир"
								},
								new City
								{
									Name = "Горохів"
								},
								new City
								{
									Name = "Камінь-Каширський"
								},
								new City
								{
									Name = "Ківерці"
								},
								new City
								{
									Name = "Ковель"
								},
								new City
								{
									Name = "Луцьк"
								},
								new City
								{
									Name = "Любомль"
								},
								new City
								{
									Name = "Нововолинськ"
								},
								new City
								{
									Name = "Рожище"
								},
								new City
								{
									Name = "Устилуг"
								},
							}
						},
						new Region
						{
							Name = "Дніпропетровська область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Апостолове"
								},
								new City
								{
									Name = "Верхівцеве"
								},
								new City
								{
									Name = "Верхньодніпровськ"
								},
								new City
								{
									Name = "Вільногірськ"
								},
								new City
								{
									Name = "Дніпро"
								},
								new City
								{
									Name = "Жовті Води"
								},
								new City
								{
									Name = "Зеленодольськ"
								},
								new City
								{
									Name = "Кам'янське"
								},
								new City
								{
									Name = "Кривий Ріг"
								},
								new City
								{
									Name = "Марганець"
								},
								new City
								{
									Name = "Нікополь"
								},
								new City
								{
									Name = "Новомосковськ"
								},
								new City
								{
									Name = "Павлоград"
								},
								new City
								{
									Name = "Перещепине"
								},
								new City
								{
									Name = "Першотравенськ"
								},
								new City
								{
									Name = "Підгородне"
								},
								new City
								{
									Name = "Покров"
								},
								new City
								{
									Name = "П'ятихатки"
								},
								new City
								{
									Name = "Синельникове"
								},
								new City
								{
									Name = "Тернівка"
								},
							}
						},
						new Region
						{
							Name = "Донецька область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Авдіївка"
								},
								new City
								{
									Name = "Амвросіївка"
								},
								new City
								{
									Name = "Бахмут"
								},
								new City
								{
									Name = "Білицьке"
								},
								new City
								{
									Name = "Білозерське"
								},
								new City
								{
									Name = "Бунге"
								},
								new City
								{
									Name = "Волноваха"
								},
								new City
								{
									Name = "Вуглегірськ"
								},
								new City
								{
									Name = "Вугледар"
								},
								new City
								{
									Name = "Гірник"
								},
								new City
								{
									Name = "Горлівка"
								},
								new City
								{
									Name = "Дебальцеве"
								},
								new City
								{
									Name = "Добропілля"
								},
								new City
								{
									Name = "Докучаєвськ"
								},
								new City
								{
									Name = "Донецьк"
								},
								new City
								{
									Name = "Дружківка"
								},
								new City
								{
									Name = "Єнакієве"
								},
								new City
								{
									Name = "Жданівка"
								},
								new City
								{
									Name = "Залізне"
								},
								new City
								{
									Name = "Зугрес"
								},
								new City
								{
									Name = "Іловайськ"
								},
								new City
								{
									Name = "Кальміуське"
								},
								new City
								{
									Name = "Костянтинівка"
								},
								new City
								{
									Name = "Краматорськ"
								},
								new City
								{
									Name = "Красногорівка"
								},
								new City
								{
									Name = "Курахове"
								},
								new City
								{
									Name = "Лиман"
								},
								new City
								{
									Name = "Макіївка"
								},
								new City
								{
									Name = "Маріуполь"
								},
								new City
								{
									Name = "Мар'їнка"
								},
								new City
								{
									Name = "Миколаївка"
								},
								new City
								{
									Name = "Мирноград"
								},
								new City
								{
									Name = "Моспине"
								},
								new City
								{
									Name = "Новоазовськ"
								},
								new City
								{
									Name = "Новогродівка"
								},
								new City
								{
									Name = "Покровськ"
								},
								new City
								{
									Name = "Родинське"
								},
								new City
								{
									Name = "Світлодарськ"
								},
								new City
								{
									Name = "Святогірськ"
								},
								new City
								{
									Name = "Селидове"
								},
								new City
								{
									Name = "Сіверськ"
								},
								new City
								{
									Name = "Слов'янськ"
								},
								new City
								{
									Name = "Сніжне"
								},
								new City
								{
									Name = "Соледар"
								},
								new City
								{
									Name = "Торецьк"
								},
								new City
								{
									Name = "Українськ"
								},
								new City
								{
									Name = "Харцизьк"
								},
								new City
								{
									Name = "Хрестівка"
								},
								new City
								{
									Name = "Часів Яр"
								},
								new City
								{
									Name = "Чистякове"
								},
								new City
								{
									Name = "Шахтарськ"
								},
								new City
								{
									Name = "Ясинувата"
								},
							}
						},
						new Region
						{
							Name = "Житомирська область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Андрушівка"
								},
								new City
								{
									Name = "Баранівка"
								},
								new City
								{
									Name = "Бердичів"
								},
								new City
								{
									Name = "Житомир"
								},
								new City
								{
									Name = "Звягель"
								},
								new City
								{
									Name = "Коростень"
								},
								new City
								{
									Name = "Коростишів"
								},
								new City
								{
									Name = "Малин"
								},
								new City
								{
									Name = "Овруч"
								},
								new City
								{
									Name = "Олевськ"
								},
								new City
								{
									Name = "Радомишль"
								},
								new City
								{
									Name = "Чуднів"
								},
							}
						},
						new Region
						{
							Name = "Закарпатська область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Берегове"
								},
								new City
								{
									Name = "Виноградів"
								},
								new City
								{
									Name = "Іршава"
								},
								new City
								{
									Name = "Мукачево"
								},
								new City
								{
									Name = "Перечин"
								},
								new City
								{
									Name = "Рахів"
								},
								new City
								{
									Name = "Свалява"
								},
								new City
								{
									Name = "Тячів"
								},
								new City
								{
									Name = "Ужгород"
								},
								new City
								{
									Name = "Хуст"
								},
								new City
								{
									Name = "Чоп"
								},
							}
						},
						new Region
						{
							Name = "Запорізька область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Бердянськ"
								},
								new City
								{
									Name = "Василівка"
								},
								new City
								{
									Name = "Вільнянськ"
								},
								new City
								{
									Name = "Гуляйполе"
								},
								new City
								{
									Name = "Дніпрорудне"
								},
								new City
								{
									Name = "Енергодар"
								},
								new City
								{
									Name = "Запоріжжя"
								},
								new City
								{
									Name = "Кам'янка-Дніпровська"
								},
								new City
								{
									Name = "Мелітополь"
								},
								new City
								{
									Name = "Молочанськ"
								},
								new City
								{
									Name = "Оріхів"
								},
								new City
								{
									Name = "Пологи"
								},
								new City
								{
									Name = "Приморськ"
								},
								new City
								{
									Name = "Токмак"
								},
							}
						},
						new Region
						{
							Name = "Івано-Франківська область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Болехів"
								},
								new City
								{
									Name = "Бурштин"
								},
								new City
								{
									Name = "Галич"
								},
								new City
								{
									Name = "Городенка"
								},
								new City
								{
									Name = "Долина"
								},
								new City
								{
									Name = "Івано-Франківськ"
								},
								new City
								{
									Name = "Калуш"
								},
								new City
								{
									Name = "Коломия"
								},
								new City
								{
									Name = "Косів"
								},
								new City
								{
									Name = "Надвірна"
								},
								new City
								{
									Name = "Рогатин"
								},
								new City
								{
									Name = "Снятин"
								},
								new City
								{
									Name = "Тисмениця"
								},
								new City
								{
									Name = "Тлумач"
								},
								new City
								{
									Name = "Яремче"
								},
							}
						},
						new Region
						{
							Name = "Київська область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Березань"
								},
								new City
								{
									Name = "Біла Церква"
								},
								new City
								{
									Name = "Богуслав"
								},
								new City
								{
									Name = "Бориспіль"
								},
								new City
								{
									Name = "Боярка"
								},
								new City
								{
									Name = "Бровари"
								},
								new City
								{
									Name = "Буча"
								},
								new City
								{
									Name = "Васильків"
								},
								new City
								{
									Name = "Вишгород"
								},
								new City
								{
									Name = "Вишневе"
								},
								new City
								{
									Name = "Ірпінь"
								},
								new City
								{
									Name = "Кагарлик"
								},
								new City
								{
									Name = "Миронівка"
								},
								new City
								{
									Name = "Обухів"
								},
								new City
								{
									Name = "Переяслав"
								},
								new City
								{
									Name = "Прип'ять"
								},
								new City
								{
									Name = "Ржищів"
								},
								new City
								{
									Name = "Сквира"
								},
								new City
								{
									Name = "Славутич"
								},
								new City
								{
									Name = "Тараща"
								},
								new City
								{
									Name = "Тетіїв"
								},
								new City
								{
									Name = "Узин"
								},
								new City
								{
									Name = "Українка"
								},
								new City
								{
									Name = "Фастів"
								},
								new City
								{
									Name = "Чорнобиль"
								},
								new City
								{
									Name = "Яготин"
								},
							}
						},
						new Region
						{
							Name = "Кіровоградська область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Благовіщенське"
								},
								new City
								{
									Name = "Бобринець"
								},
								new City
								{
									Name = "Гайворон"
								},
								new City
								{
									Name = "Долинська"
								},
								new City
								{
									Name = "Знам'янка"
								},
								new City
								{
									Name = "Кропивницький"
								},
								new City
								{
									Name = "Мала Виска"
								},
								new City
								{
									Name = "Новомиргород"
								},
								new City
								{
									Name = "Новоукраїнка"
								},
								new City
								{
									Name = "Олександрія"
								},
								new City
								{
									Name = "Помічна"
								},
								new City
								{
									Name = "Світловодськ"
								},
							}
						},
						new Region
						{
							Name = "Луганська область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Алмазна"
								},
								new City
								{
									Name = "Алчевськ"
								},
								new City
								{
									Name = "Антрацит"
								},
								new City
								{
									Name = "Боково-Хрустальне"
								},
								new City
								{
									Name = "Брянка"
								},
								new City
								{
									Name = "Вознесенівка"
								},
								new City
								{
									Name = "Гірське"
								},
								new City
								{
									Name = "Голубівка"
								},
								new City
								{
									Name = "Довжанськ"
								},
								new City
								{
									Name = "Зимогір'я"
								},
								new City
								{
									Name = "Золоте"
								},
								new City
								{
									Name = "Зоринськ"
								},
								new City
								{
									Name = "Ірміно"
								},
								new City
								{
									Name = "Кадіївка"
								},
								new City
								{
									Name = "Кипуче"
								},
								new City
								{
									Name = "Кремінна"
								},
								new City
								{
									Name = "Лисичанськ"
								},
								new City
								{
									Name = "Луганськ"
								},
								new City
								{
									Name = "Лутугине"
								},
								new City
								{
									Name = "Міусинськ"
								},
								new City
								{
									Name = "Молодогвардійськ"
								},
								new City
								{
									Name = "Новодружеськ"
								},
								new City
								{
									Name = "Олександрівськ"
								},
								new City
								{
									Name = "Первомайськ"
								},
								new City
								{
									Name = "Перевальськ"
								},
								new City
								{
									Name = "Петрово-Красносілля"
								},
								new City
								{
									Name = "Попасна"
								},
								new City
								{
									Name = "Привілля"
								},
								new City
								{
									Name = "Ровеньки"
								},
								new City
								{
									Name = "Рубіжне"
								},
								new City
								{
									Name = "Сватове"
								},
								new City
								{
									Name = "Сєвєродонецьк"
								},
								new City
								{
									Name = "Сорокине"
								},
								new City
								{
									Name = "Старобільськ"
								},
								new City
								{
									Name = "Суходільськ"
								},
								new City
								{
									Name = "Хрустальний"
								},
								new City
								{
									Name = "Щастя"
								},
							}
						},
						new Region
						{
							Name = "Львівська область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Белз"
								},
								new City
								{
									Name = "Бібрка"
								},
								new City
								{
									Name = "Борислав"
								},
								new City
								{
									Name = "Броди"
								},
								new City
								{
									Name = "Буськ"
								},
								new City
								{
									Name = "Великі Мости "
								},
								new City
								{
									Name = "Винники"
								},
								new City
								{
									Name = "Глиняни"
								},
								new City
								{
									Name = "Городок"
								},
								new City
								{
									Name = "Добромиль"
								},
								new City
								{
									Name = "Дрогобич"
								},
								new City
								{
									Name = "Дубляни"
								},
								new City
								{
									Name = "Жидачів"
								},
								new City
								{
									Name = "Жовква"
								},
								new City
								{
									Name = "Золочів"
								},
								new City
								{
									Name = "Кам'янка-Бузька"
								},
								new City
								{
									Name = "Комарно"
								},
								new City
								{
									Name = "Львів"
								},
								new City
								{
									Name = "Миколаїв"
								},
								new City
								{
									Name = "Моршин"
								},
								new City
								{
									Name = "Мостиська"
								},
								new City
								{
									Name = "Новий Калинів"
								},
								new City
								{
									Name = "Новий Розділ"
								},
								new City
								{
									Name = "Новояворівськ"
								},
								new City
								{
									Name = "Перемишляни"
								},
								new City
								{
									Name = "Пустомити"
								},
								new City
								{
									Name = "Рава-Руська"
								},
								new City
								{
									Name = "Радехів"
								},
								new City
								{
									Name = "Рудки"
								},
								new City
								{
									Name = "Самбір"
								},
								new City
								{
									Name = "Сколе"
								},
								new City
								{
									Name = "Сокаль"
								},
								new City
								{
									Name = "Соснівка"
								},
								new City
								{
									Name = "Старий Самбір"
								},
								new City
								{
									Name = "Стебник"
								},
								new City
								{
									Name = "Стрий"
								},
								new City
								{
									Name = "Судова Вишня"
								},
								new City
								{
									Name = "Трускавець"
								},
								new City
								{
									Name = "Турка"
								},
								new City
								{
									Name = "Угнів"
								},
								new City
								{
									Name = "Хирів"
								},
								new City
								{
									Name = "Ходорів"
								},
								new City
								{
									Name = "Червоноград"
								},
								new City
								{
									Name = "Яворів"
								},
							}
						},
						new Region
						{
							Name = "Миколаївська область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Баштанка"
								},
								new City
								{
									Name = "Вознесенськ"
								},
								new City
								{
									Name = "Миколаїв"
								},
								new City
								{
									Name = "Нова Одеса"
								},
								new City
								{
									Name = "Новий Буг"
								},
								new City
								{
									Name = "Очаків"
								},
								new City
								{
									Name = "Первомайськ"
								},
								new City
								{
									Name = "Снігурівка"
								},
								new City
								{
									Name = "Южноукраїнськ"
								},
							}
						},
						new Region
						{
							Name = "Одеська область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Ананьїв"
								},
								new City
								{
									Name = "Арциз"
								},
								new City
								{
									Name = "Балта"
								},
								new City
								{
									Name = "Березівка"
								},
								new City
								{
									Name = "Білгород-Дністровський "
								},
								new City
								{
									Name = "Біляївка"
								},
								new City
								{
									Name = "Болград"
								},
								new City
								{
									Name = "Вилкове"
								},
								new City
								{
									Name = "Ізмаїл"
								},
								new City
								{
									Name = "Кілія"
								},
								new City
								{
									Name = "Кодима"
								},
								new City
								{
									Name = "Одеса"
								},
								new City
								{
									Name = "Подільськ"
								},
								new City
								{
									Name = "Рені"
								},
								new City
								{
									Name = "Роздільна"
								},
								new City
								{
									Name = "Татарбунари"
								},
								new City
								{
									Name = "Теплодар"
								},
								new City
								{
									Name = "Чорноморськ"
								},
								new City
								{
									Name = "Южне"
								},
							}
						},
						new Region
						{
							Name = "Полтавська область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Гадяч"
								},
								new City
								{
									Name = "Глобине"
								},
								new City
								{
									Name = "Горішні Плавні"
								},
								new City
								{
									Name = "Гребінка"
								},
								new City
								{
									Name = "Заводське"
								},
								new City
								{
									Name = "Зіньків"
								},
								new City
								{
									Name = "Карлівка"
								},
								new City
								{
									Name = "Кобеляки"
								},
								new City
								{
									Name = "Кременчук"
								},
								new City
								{
									Name = "Лохвиця"
								},
								new City
								{
									Name = "Лубни"
								},
								new City
								{
									Name = "Миргород"
								},
								new City
								{
									Name = "Пирятин"
								},
								new City
								{
									Name = "Полтава"
								},
								new City
								{
									Name = "Решетилівка"
								},
								new City
								{
									Name = "Хорол"
								}
							}
						},
						new Region
						{
							Name = "Рівненська область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Березне"
								},
								new City
								{
									Name = "Вараш"
								},
								new City
								{
									Name = "Дубно"
								},
								new City
								{
									Name = "Дубровиця"
								},
								new City
								{
									Name = "Здолбунів"
								},
								new City
								{
									Name = "Корець"
								},
								new City
								{
									Name = "Костопіль"
								},
								new City
								{
									Name = "Острог"
								},
								new City
								{
									Name = "Радивилів"
								},
								new City
								{
									Name = "Рівне"
								},
								new City
								{
									Name = "Сарни"
								},
							}
						},
						new Region
						{
							Name = "Сумська область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Білопілля"
								},
								new City
								{
									Name = "Буринь"
								},
								new City
								{
									Name = "Ворожба"
								},
								new City
								{
									Name = "Глухів"
								},
								new City
								{
									Name = "Дружба"
								},
								new City
								{
									Name = "Конотоп"
								},
								new City
								{
									Name = "Кролевець"
								},
								new City
								{
									Name = "Лебедин"
								},
								new City
								{
									Name = "Охтирка"
								},
								new City
								{
									Name = "Путивль"
								},
								new City
								{
									Name = "Ромни"
								},
								new City
								{
									Name = "Середина-Буда"
								},
								new City
								{
									Name = "Суми"
								},
								new City
								{
									Name = "Тростянець"
								},
								new City
								{
									Name = "Шостка"
								},
							}
						},
						new Region
						{
							Name = "Тернопільська область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Бережани"
								},
								new City
								{
									Name = "Борщів"
								},
								new City
								{
									Name = "Бучач"
								},
								new City
								{
									Name = "Заліщики"
								},
								new City
								{
									Name = "Збараж"
								},
								new City
								{
									Name = "Зборів"
								},
								new City
								{
									Name = "Копичинці"
								},
								new City
								{
									Name = "Кременець"
								},
								new City
								{
									Name = "Ланівці"
								},
								new City
								{
									Name = "Монастириська"
								},
								new City
								{
									Name = "Підгайці"
								},
								new City
								{
									Name = "Почаїв"
								},
								new City
								{
									Name = "Скалат"
								},
								new City
								{
									Name = "Теребовля"
								},
								new City
								{
									Name = "Тернопіль"
								},
								new City
								{
									Name = "Хоростків"
								},
								new City
								{
									Name = "Чортків"
								},
								new City
								{
									Name = "Шумськ"
								},
							}
						},
						new Region
						{
							Name = "Харківська область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Балаклія"
								},
								new City
								{
									Name = "Барвінкове"
								},
								new City
								{
									Name = "Богодухів"
								},
								new City
								{
									Name = "Валки"
								},
								new City
								{
									Name = "Вовчанськ"
								},
								new City
								{
									Name = "Дергачі"
								},
								new City
								{
									Name = "Зміїв"
								},
								new City
								{
									Name = "Ізюм"
								},
								new City
								{
									Name = "Красноград"
								},
								new City
								{
									Name = "Куп'янськ"
								},
								new City
								{
									Name = "Лозова"
								},
								new City
								{
									Name = "Люботин"
								},
								new City
								{
									Name = "Мерефа"
								},
								new City
								{
									Name = "Первомайський"
								},
								new City
								{
									Name = "Південне"
								},
								new City
								{
									Name = "Харків"
								},
								new City
								{
									Name = "Чугуїв"
								},
							}
						},
						new Region
						{
							Name = "Херсонська область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Берислав"
								},
								new City
								{
									Name = "Генічеськ"
								},
								new City
								{
									Name = "Гола Пристань"
								},
								new City
								{
									Name = "Каховка"
								},
								new City
								{
									Name = "Нова Каховка"
								},
								new City
								{
									Name = "Олешки"
								},
								new City
								{
									Name = "Скадовськ"
								},
								new City
								{
									Name = "Таврійськ"
								},
								new City
								{
									Name = "Херсон"
								},
							}
						},
						new Region
						{
							Name = "Хмельницька область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Волочиськ"
								},
								new City
								{
									Name = "Городок"
								},
								new City
								{
									Name = "Деражня"
								},
								new City
								{
									Name = "Дунаївці"
								},
								new City
								{
									Name = "Ізяслав"
								},
								new City
								{
									Name = "Кам'янець-Подільський"
								},
								new City
								{
									Name = "Красилів"
								},
								new City
								{
									Name = "Нетішин"
								},
								new City
								{
									Name = "Полонне"
								},
								new City
								{
									Name = "Славута"
								},
								new City
								{
									Name = "Старокостянтинів"
								},
								new City
								{
									Name = "Хмельницький"
								},
								new City
								{
									Name = "Шепетівка"
								},
							}
						},
						new Region
						{
							Name = "Черкаська область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Ватутіне"
								},
								new City
								{
									Name = "Городище"
								},
								new City
								{
									Name = "Жашків"
								},
								new City
								{
									Name = "Звенигородка"
								},
								new City
								{
									Name = "Золотоноша"
								},
								new City
								{
									Name = "Кам'янка"
								},
								new City
								{
									Name = "Канів"
								},
								new City
								{
									Name = "Корсунь-Шевченківський"
								},
								new City
								{
									Name = "Монастирище"
								},
								new City
								{
									Name = "Сміла"
								},
								new City
								{
									Name = "Тальне"
								},
								new City
								{
									Name = "Умань"
								},
								new City
								{
									Name = "Христинівка"
								},
								new City
								{
									Name = "Черкаси"
								},
								new City
								{
									Name = "Чигирин"
								},
								new City
								{
									Name = "Шпола"
								},
							}
						},
						new Region
						{
							Name = "Чернівецька область",
							Cities = new List<City>
							{
								new City
								{
									Name = "Вашківці"
								},
								new City
								{
									Name = "Вижниця"
								},
								new City
								{
									Name = "Вашківці"
								},
								new City
								{
									Name = "Герца"
								},
								new City
								{
									Name = "Заставна"
								},
								new City
								{
									Name = "Кіцмань"
								},
								new City
								{
									Name = "Новодністровськ"
								},
								new City
								{
									Name = "Новоселиця"
								},
								new City
								{
									Name = "Сокиряни"
								},
								new City
								{
									Name = "Сторожинець"
								},
								new City
								{
									Name = "Хотин"
								},
								new City
								{
									Name = "Чернівці"
								},
							}
						},
						new Region
						{
							Name = "Чернігівська область" ,
							Cities = new List<City>
							{
								new City
								{
									Name = "Чернігів"
								},
								new City
								{
									Name = "Сновськ"
								},
								new City
								{
									Name = "Семенівка"
								},
								new City
								{
									Name = "Прилуки"
								},
								new City
								{
									Name = "Остер"
								},
								new City
								{
									Name = "Носівка"
								},
								new City
								{
									Name = "Новгород-Сіверський"
								},
								new City
								{
									Name = "Ніжин"
								},
								new City
								{
									Name = "Мена"
								},
								new City
								{
									Name = "Корюківка"
								},
								new City
								{
									Name = "Ічня"
								},
								new City
								{
									Name = "Городня"
								},
								new City
								{
									Name = "Борзна"
								},
								new City
								{
									Name = "Бобровиця"
								},
								new City
								{
									Name = "Бахмач"
								},
								new City
								{
									Name = "Батурин"
								}
							}
						},
						new Region
						{
							Name = "м.Київ",
							Cities = new List<City>
							{
								new City
								{
									Name = "Київ"
								}
							}
						}
					};
				await context.Regions.AddRangeAsync(regions);

				var isceds = new List<Isced>
					{
						new Isced
						{
							Id = "0111",
							Name = "Education science",
						},
						new Isced
						{
							Id = "0112",
							Name = "Training for pre-school teachers",
						},
						new Isced
						{
							Id = "0113",
							Name = "Teacher training without subject specialisation",
						},
						new Isced
						{
							Id = "0114",
							Name = "Teacher training with subject specialisation",
						},
						new Isced
						{
							Id = "1014",
							Name = "Sports",
						},
						new Isced
						{
							Id = "0211",
							Name = "Audio-visual techniques and media production",
						},
						new Isced
						{
							Id = "0212",
							Name = "Fashion, interior and industrial design",
						},
						new Isced
						{
							Id = "0213",
							Name = "Fine arts",
						},
						new Isced
						{
							Id = "0214",
							Name = "Handicrafts",
						},
						new Isced
						{
							Id = "0215",
							Name = "Music and performing arts",
						},
						new Isced
						{
							Id = "0322",
							Name = "Library, information and archival studies",
						},
						new Isced
						{
							Id = "0413",
							Name = "Management and administration",
						},
						new Isced
						{
							Id = "0415",
							Name = "Secretarial and office work",
						},
						new Isced
						{
							Id = "0221",
							Name = "Religion and theology",
						},
						new Isced
						{
							Id = "0222",
							Name = "History and archaeology",
						},
						new Isced
						{
							Id = "0223",
							Name = "Philosophy and ethics",
						},
						new Isced
						{
							Id = "0314",
							Name = "Sociology and cultural studies",
						},
						new Isced
						{
							Id = "0231",
							Name = "Language acquisition",
						},
						new Isced
						{
							Id = "0232",
							Name = "Literature and linguistics",
						},
						new Isced
						{
							Id = "0311",
							Name = "Economics",
						},
						new Isced
						{
							Id = "0312",
							Name = "Political sciences and civics",
						},
						new Isced
						{
							Id = "0313",
							Name = "Psychology",
						},
						new Isced
						{
							Id = "0321",
							Name = "Journalism and reporting",
						},
						new Isced
						{
							Id = "0411",
							Name = "Accounting and taxation",
						},
						new Isced
						{
							Id = "0412",
							Name = "Finance, banking and insurance",
						},
						new Isced
						{
							Id = "0414",
							Name = "Marketing and advertising",
						},
						new Isced
						{
							Id = "0416",
							Name = "Wholesale and retail sales",
						},
						new Isced
						{
							Id = "0421",
							Name = "Law",
						},
						new Isced
						{
							Id = "0511",
							Name = "Biology",
						},
						new Isced
						{
							Id = "0512",
							Name = "Biochemistry",
						},
						new Isced
						{
							Id = "0522",
							Name = "Natural environments and wildlife",
						},
						new Isced
						{
							Id = "0521",
							Name = "Environmental sciences",
						},
						new Isced
						{
							Id = "0531",
							Name = "Chemistry",
						},
						new Isced
						{
							Id = "0532",
							Name = "Earth sciences",
						},
						new Isced
						{
							Id = "0533",
							Name = "Physics",
						},
						new Isced
						{
							Id = "0588",
							Name = "Inter-disciplinary programmes and qualifications involving natural sciences, mathematics and statistics",
						},
						new Isced
						{
							Id = "0541",
							Name = "Mathematics",
						},
						new Isced
						{
							Id = "0542",
							Name = "Statistics",
						},
						new Isced
						{
							Id = "0613",
							Name = "Software and applications development and analysis",
						},
						new Isced
						{
							Id = "0612",
							Name = "Database and network design and administration",
						},
						new Isced
						{
							Id = "0714",
							Name = "Electronics and automation",
						},
						new Isced
						{
							Id = "0688",
							Name = "Inter-disciplinary programmes and qualifications involving Information and Communication Technologies (ICTs)",
						},
						new Isced
						{
							Id = "0611",
							Name = "Computer use",
						},
						new Isced
						{
							Id = "0715",
							Name = "Mechanics and metal trades",
						},
						new Isced
						{
							Id = "0788",
							Name = "Inter-disciplinary programmes and qualifications involving engineering, manufacturing and construction",
						},
						new Isced
						{
							Id = "0716",
							Name = "Motor vehicles, ships and aircraft",
						},
						new Isced
						{
							Id = "0713",
							Name = "Electricity and energy",
						},
						new Isced
						{
							Id = "0711",
							Name = "Chemical engineering and processes",
						},
						new Isced
						{
							Id = "0721",
							Name = "Food processing",
						},
						new Isced
						{
							Id = "0723",
							Name = "Textiles (clothes, footwear and leather)",
						},
						new Isced
						{
							Id = "0712",
							Name = "Environmental protection technology",
						},
						new Isced
						{
							Id = "0724",
							Name = "Mining and extraction",
						},
						new Isced
						{
							Id = "0722",
							Name = "Materials (glass, paper, plastic and wood)",
						},
						new Isced
						{
							Id = "0731",
							Name = "Architecture and town planning",
						},
						new Isced
						{
							Id = "0732",
							Name = "Building and civil engineering",
						},
						new Isced
						{
							Id = "0811",
							Name = "Crop and livestock production",
						},
						new Isced
						{
							Id = "0812",
							Name = "Horticulture",
						},
						new Isced
						{
							Id = "0821",
							Name = "Forestry",
						},
						new Isced
						{
							Id = "0831",
							Name = "Fisheries",
						},
						new Isced
						{
							Id = "0888",
							Name = "Inter-disciplinary programmes and qualifications involving agriculture, forestry, fisheries and veterinary",
						},
						new Isced
						{
							Id = "0841",
							Name = "Veterinary",
						},
						new Isced
						{
							Id = "1022",
							Name = "Occupational health and safety",
						},
						new Isced
						{
							Id = "0911",
							Name = "Dental studies",
						},
						new Isced
						{
							Id = "0912",
							Name = "Medicine",
						},
						new Isced
						{
							Id = "0913",
							Name = "Nursing and midwifery",
						},
						new Isced
						{
							Id = "0914",
							Name = "Medical diagnostic and treatment technology",
						},
						new Isced
						{
							Id = "0916",
							Name = "Pharmacy",
						},
						new Isced
						{
							Id = "0915",
							Name = "Therapy and rehabilitation",
						},
						new Isced
						{
							Id = "0988",
							Name = "Inter-disciplinary programmes and qualifications involving health and welfare",
						},
						new Isced
						{
							Id = "1021",
							Name = "Community sanitation",
						},
						new Isced
						{
							Id = "0921",
							Name = "Care of the elderly and of disabled adults",
						},
						new Isced
						{
							Id = "0922",
							Name = "Child care and youth services",
						},
						new Isced
						{
							Id = "0923",
							Name = "Social work and counselling",
						},
						new Isced
						{
							Id = "1013",
							Name = "Hotel, restaurants and catering",
						},
						new Isced
						{
							Id = "1015",
							Name = "Travel, tourism and leisure",
						},
						new Isced
						{
							Id = "1031",
							Name = "Military and defence",
						},
						new Isced
						{
							Id = "1032",
							Name = "Protection of persons and property",
						},
						new Isced
						{
							Id = "1041",
							Name = "Transport services",
						},
						new Isced
						{
							Id = "0388",
							Name = "Inter-disciplinary programmes and qualifications involving social sciences, journalism and information",
						},
					};
				await context.Isceds.AddRangeAsync(isceds);


				var specialtyBases = new List<SpecialtyBase>
{
new SpecialtyBase
{
Id="011",
Name="Educational, pedagogical sciences",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0111"),
}
},
new SpecialtyBase
{
Id="012",
Name="Preschool Education",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0112"),
},
},
new SpecialtyBase
{
Id="013",
Name="Elementary Education",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0113"),
},
},
new SpecialtyBase
{
Id="014",
Name="Secondary education (by subject majors)",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0114"),
},
},
new SpecialtyBase
{
Id="015",
Name="Professional education (by specialization)",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0114"),
},
},
new SpecialtyBase
{
Id="016",
Name="Special Education",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0113"),
},
},
new SpecialtyBase
{
Id="017",
Name="Physical culture and sport",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "1014"),
},
},
new SpecialtyBase
{
Id="021",
Name="Audiovisual Arts and Production",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0211"),
},
},
new SpecialtyBase
{
Id="022",
Name="Design",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0212"),
},
},
new SpecialtyBase
{
Id="023",
Name="Fine art, decorative art, restoration",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0213"),
isceds.FirstOrDefault(x => x.Id == "0214"),
},
},
new SpecialtyBase
{
Id="024",
Name="Choreography",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0215"),
},
},
new SpecialtyBase
{
Id="025",
Name="Music Art",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0215"),
},
},
new SpecialtyBase
{
Id="026",
Name="Performing Arts",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0215"),
},
},
new SpecialtyBase
{
Id="027",
Name="Museum studies, monument studies",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0322"),
},
},
new SpecialtyBase
{
Id="028",
Name="Management of socio-cultural activities",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0413"),
},
},
new SpecialtyBase
{
Id="029",
Name="Information, library and archive business",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0322"),
isceds.FirstOrDefault(x => x.Id == "0415"),
},
},
new SpecialtyBase
{
Id="031",
Name="Religious Studies",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0221"),
},
},
new SpecialtyBase
{
Id="032",
Name="History and Archaeology",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0222"),
},
},
new SpecialtyBase
{
Id="033",
Name="Philosophy",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0223"),
},
},
new SpecialtyBase
{
Id="034",
Name="Culturology",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0314"),
},
},
new SpecialtyBase
{
Id="035",
Name="Philology",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0231"),
isceds.FirstOrDefault(x => x.Id == "0232"),
},
},
new SpecialtyBase
{
Id="041",
Name="Theology",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0221"),
},
},
new SpecialtyBase
{
Id="051",
Name="Economy",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0311"),
},
},
						new SpecialtyBase
{
Id="052",
Name="Political Science",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0312"),
},
},
new SpecialtyBase
{
Id="053",
Name="Psychology",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0313"),
},
},
new SpecialtyBase
{
Id="054",
Name="Sociology",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0314"),
},
},
new SpecialtyBase
{
Id="061",
Name="Journalism",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0321"),
},
},
new SpecialtyBase
{
Id="071",
Name="Accounting and taxation",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0411"),
},
},
new SpecialtyBase
{
Id="072",
Name="Finance, Banking, Insurance and Stock Market",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0412"),
},
},
new SpecialtyBase
{
Id="073",
Name="Management",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0413"),
isceds.FirstOrDefault(x => x.Id == "0415"),
},
},
new SpecialtyBase
{
Id="075",
Name="Marketing",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0414"),
},
},
new SpecialtyBase
{
Id="076",
Name="Entrepreneurship and Trade",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0413"),
isceds.FirstOrDefault(x => x.Id == "0416"),
},
},
new SpecialtyBase
{
Id="081",
Name="Right",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0421"),
},
},
new SpecialtyBase
{
Id="091",
Name="Biology and Biochemistry",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0511"),
isceds.FirstOrDefault(x => x.Id == "0512"),
isceds.FirstOrDefault(x => x.Id == "0522"),
},
},
new SpecialtyBase
{
Id="101",
Name="Ecology",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0521"),
isceds.FirstOrDefault(x => x.Id == "0522"),
},
},
						new SpecialtyBase
{
Id="102",
Name="Chemistry",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0531"),
},
},
new SpecialtyBase
{
Id="103",
Name="Earth Sciences",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0532"),
},
},
new SpecialtyBase
{
Id="104",
Name="Physics and Astronomy",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0533"),
},
},
new SpecialtyBase
{
Id="105",
Name="Applied physics and nanomaterials",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0533"),
isceds.FirstOrDefault(x => x.Id == "0588"),
},
},
new SpecialtyBase
{
Id="106",
Name="Geography",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0314"),
},
},
new SpecialtyBase
{
Id="111",
Name="Mathematics",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0541"),
},
},
new SpecialtyBase
{
Id="112",
Name="Statistics",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0542"),
},
},
new SpecialtyBase
{
Id="113",
Name="Applied Mathematics",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0541"),
isceds.FirstOrDefault(x => x.Id == "0588"),
isceds.FirstOrDefault(x => x.Id == "0613"),
},
},
new SpecialtyBase
{
Id="121",
Name="Software Engineering",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0613"),
},
},
new SpecialtyBase
{
Id="122",
Name="Computer Science",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0613"),
},
},
new SpecialtyBase
{
Id="123",
Name="Computer Engineering",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0612"),
isceds.FirstOrDefault(x => x.Id == "0714"),
},
},
new SpecialtyBase
{
Id="124",
Name="System Analysis",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0688"),
},
},
new SpecialtyBase
{
Id="125",
Name="Cyber security and information protection",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0612"),
isceds.FirstOrDefault(x => x.Id == "0688"),
},
},
new SpecialtyBase
{
Id="126",
Name="Information systems and technologies",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0611"),
isceds.FirstOrDefault(x => x.Id == "0612"),
},
},
new SpecialtyBase
{
Id="131",
Name="Applied Mechanics",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0715"),
},
},
new SpecialtyBase
{
Id="132",
Name="Materials Science",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0588"),
isceds.FirstOrDefault(x => x.Id == "0715"),
isceds.FirstOrDefault(x => x.Id == "0788"),
},
},
new SpecialtyBase
{
Id="133",
Name="Industrial mechanical engineering",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0715"),
isceds.FirstOrDefault(x => x.Id == "0716"),
},
},
new SpecialtyBase
{
Id="134",
Name="Aviation and space rocket technology",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0716"),
},
},
						new SpecialtyBase
{
Id="135",
Name="Shipbuilding",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0716"),
},
},
new SpecialtyBase
{
Id="136",
Name="Metallurgy",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0715"),
},
},
new SpecialtyBase
{
Id="141",
Name="Electric power engineering, electrical engineering and electromechanics",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0713"),
},
},
new SpecialtyBase
{
Id="142",
Name="Energy Engineering",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0713"),
isceds.FirstOrDefault(x => x.Id == "0716"),
},
},
new SpecialtyBase
{
Id="143",
Name="Atomic power",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0713"),
},
},
new SpecialtyBase
{
Id="144",
Name="Heat power",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0713"),
},
},
new SpecialtyBase
{
Id="145",
Name="Renewable energy sources and hydropower",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0713"),
},
},
new SpecialtyBase
{
Id="161",
Name="Chemical technologies and engineering",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0711"),
},
},
new SpecialtyBase
{
Id="162",
Name="Biotechnologies and bioengineering",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0512"),
isceds.FirstOrDefault(x => x.Id == "0711"),
},
},
new SpecialtyBase
{
Id="163",
Name="Biomedical Engineering",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0588"),
isceds.FirstOrDefault(x => x.Id == "0788"),
},
},
new SpecialtyBase
{
Id="171",
Name="Electronics",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0714"),
},
},
new SpecialtyBase
{
Id="172",
Name="Electronic communications and radio engineering",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0714"),
},
},
new SpecialtyBase
{
Id="173",
Name="Avionics",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0714"),
isceds.FirstOrDefault(x => x.Id == "0716"),
},
},
new SpecialtyBase
{

Id="174",
Name="Automation, computer-integrated technologies and robotics",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0714"),
},
},
new SpecialtyBase
{

Id="175",
Name="Information and measurement technologies",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0714"),
isceds.FirstOrDefault(x => x.Id == "0788"),
},
},
new SpecialtyBase
{

Id="176",
Name="Micro- and nanosystem engineering",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0714"),
isceds.FirstOrDefault(x => x.Id == "0788"),
},
},
new SpecialtyBase
{

Id="181",
Name="Food technology",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0721"),
},
},
new SpecialtyBase
{

Id="182",
Name="Technologies of light industry",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0723"),
},
},
new SpecialtyBase
{

Id="183",
Name="Environmental Protection Technologies",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0712"),
},
},
new SpecialtyBase
{

Id="184",
Name="Mining",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0724"),
},
},
new SpecialtyBase
{

Id="185",
Name="Oil and gas engineering and technologies",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0724"),
},
},
						new SpecialtyBase
{

Id="186",
Name="Publishing and printing",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0211"),
isceds.FirstOrDefault(x => x.Id == "0611"),
},
},
new SpecialtyBase
{

Id="187",
Name="Woodworking and furniture technologies",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0722"),
},
},
new SpecialtyBase
{

Id="191",
Name="Architecture and urban planning",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0731"),
},
},
new SpecialtyBase
{

Id="192",
Name="Construction and Civil Engineering",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0732"),
},
},
new SpecialtyBase
{

Id="193",
Name="Geodesy and land management",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0532"),
isceds.FirstOrDefault(x => x.Id == "0731"),
},
},
new SpecialtyBase
{

Id="194",
Name="Hydrotechnical construction, water engineering and water technologies",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0732"),
},
},
new SpecialtyBase
{

Id="201",
Name="Agronomy",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0811"),
},
},
new SpecialtyBase
{

Id="202",
Name="Protection and quarantine of plants",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0811"),
},
},
new SpecialtyBase
{

Id="203",
Name="Horticulture, horticulture and viticulture",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0811"),
isceds.FirstOrDefault(x => x.Id == "0812"),
},
},
new SpecialtyBase
{

Id="204",
Name="Technology of production and processing of livestock products",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0811"),
},
},
new SpecialtyBase
{

Id="206",
Name="Horticulture",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0812"),
},
},
new SpecialtyBase
{

Id="207",
Name="Aquatic bioresources and aquaculture",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0831"),
},
},
new SpecialtyBase
{

Id="208",
Name="Agroengineering",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0716"),
isceds.FirstOrDefault(x => x.Id == "0888"),
},
},
new SpecialtyBase
{

Id="211",
Name="Veterinary Medicine",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0841"),
isceds.FirstOrDefault(x => x.Id == "1022"),
},
},
new SpecialtyBase
{

Id="221",
Name="Dentistry",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0911"),
},
},
new SpecialtyBase
{

Id="222",
Name="Medicine",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0912"),
},
},
new SpecialtyBase
{

Id="223",
Name="Nursing",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0913"),
},
},
new SpecialtyBase
{

Id="224",
Name="Technologies of medical diagnostics and treatment",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0914"),
},
},
new SpecialtyBase
{

Id="225",
Name="Medical Psychology",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0313"),
},
},
new SpecialtyBase
{

Id="226",
Name="Pharmacy, industrial pharmacy",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0588"),
isceds.FirstOrDefault(x => x.Id == "0711"),
isceds.FirstOrDefault(x => x.Id == "0916"),
},
},
new SpecialtyBase
{

Id="227",
Name="Therapy and rehabilitation",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0915"),
},
},
new SpecialtyBase
{

Id="228",
Name="Pediatrics",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0912"),
},
},
						new SpecialtyBase
{

Id="229",
Name="Public Health",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0413"),
isceds.FirstOrDefault(x => x.Id == "0988"),
isceds.FirstOrDefault(x => x.Id == "1021"),
isceds.FirstOrDefault(x => x.Id == "1022"),
},
},
new SpecialtyBase
{

Id="231",
Name="Social Work",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0921"),
isceds.FirstOrDefault(x => x.Id == "0922"),
isceds.FirstOrDefault(x => x.Id == "0923"),
},
},
new SpecialtyBase
{

Id="232",
Name="Social Security",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0413"),
isceds.FirstOrDefault(x => x.Id == "0923"),
},
},
new SpecialtyBase
{

Id="241",
Name="Hotel and restaurant business",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "1013"),
},
},
new SpecialtyBase
{

Id="242",
Name="Tourism and recreation",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "1015"),
},
},
new SpecialtyBase
{

Id="251",
Name="State Security",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "1031"),
},
},
new SpecialtyBase
{

Id="252",
Name="State border security",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "1031"),
},
},
new SpecialtyBase
{

Id="253",
Name="Military administration (by types of armed forces)",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "1031"),
},
},
new SpecialtyBase
{

Id="254",
Name="Provision of troops (forces)",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "1031"),
},
},
new SpecialtyBase
{

Id="255",
Name="Weapons and military equipment",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "1031"),
},
},
new SpecialtyBase
{

Id="256",
Name="National security (by separate areas of support and types of activities)***",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "1031"),
},
},
new SpecialtyBase
{

Id="257",
Name="Information Security Management",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "1031"),
},
},
new SpecialtyBase
{

Id="261",
Name="Fire Safety",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "1032"),
},
},
new SpecialtyBase
{

Id="262",
Name="Law enforcement",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "1032"),
},
},
new SpecialtyBase
{

Id="263",
Name="Civil Security",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "1022"),
isceds.FirstOrDefault(x => x.Id == "1032"),
},
},
						new SpecialtyBase
{

Id="271",
Name="Sea and inland water transport****",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0716"),
isceds.FirstOrDefault(x => x.Id == "1041"),
},
},
new SpecialtyBase
{

Id="272",
Name="Air transport",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0716"),
isceds.FirstOrDefault(x => x.Id == "1041"),
},
},
new SpecialtyBase
{

Id="273",
Name="Rail transport",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0716"),
isceds.FirstOrDefault(x => x.Id == "0732"),
isceds.FirstOrDefault(x => x.Id == "1041"),
},
},
new SpecialtyBase
{

Id="274",
Name="Motor transport",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0716"),
isceds.FirstOrDefault(x => x.Id == "1041"),
},
},
new SpecialtyBase
{

Id="275",
Name="Transport technologies (by types)",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "1041"),
},
},
new SpecialtyBase
{

Id="281",
Name="Public management and administration",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0413"),
},
},
new SpecialtyBase
{

Id="291",
Name="International Relations, Public Communications and Regional Studies",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0312"),
isceds.FirstOrDefault(x => x.Id == "0314"),
isceds.FirstOrDefault(x => x.Id == "0388"),
},
},
new SpecialtyBase
{

Id="292",
Name="International economic relations",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0311"),
isceds.FirstOrDefault(x => x.Id == "0312"),
},
},
new SpecialtyBase
{

Id="293",
Name="International Law",
Isceds = new List<Isced>
{
isceds.FirstOrDefault(x => x.Id == "0421"),
},
},
};
				await context.SpecialtyBases.AddRangeAsync(specialtyBases);

				var knowledgeBranches = new List<KnowledgeBranch>
				{
					new KnowledgeBranch
{
Id = "01",
Name = "Education",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "01").ToList()
},
new KnowledgeBranch
{
Id = "02",
Name = "Culture and Art",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "02").ToList()
},
new KnowledgeBranch
{
Id = "03",
Name = "Humanities",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "03").ToList()
},
new KnowledgeBranch
{
Id = "04",
Name = "Theology",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "04").ToList()
},
new KnowledgeBranch
{
Id = "05",
Name = "Social and Behavioral Sciences",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "05").ToList()
},
new KnowledgeBranch
{
Id = "06",
Name = "Journalism",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "06").ToList()
},
new KnowledgeBranch
{
Id = "07",
Name = "Management and Administration",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "07").ToList()
},
new KnowledgeBranch
{
Id = "08",
Name = "Right",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "08").ToList()
},
new KnowledgeBranch
{
Id = "09",
Name = "Biology",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "09").ToList()
},
new KnowledgeBranch
{
Id = "10",
Name = "Natural Sciences",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "10").ToList()
},
new KnowledgeBranch
{
Id = "11",
Name = "Mathematics and Statistics",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "11").ToList()
},
new KnowledgeBranch
{
Id = "12",
Name = "Information Technology",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "12").ToList()
},
new KnowledgeBranch
{
Id = "13",
Name = "Mechanical Engineering",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "13").ToList()
},
new KnowledgeBranch
{
Id = "14",
Name = "Electrical Engineering",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "14").ToList()
},
new KnowledgeBranch
{
Id = "15",
Name = "Automation and instrumentation",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "15").ToList()
},
new KnowledgeBranch
{
Id = "16",
Name = "Chemical and Bioengineering",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "16").ToList()
},
					new KnowledgeBranch
{
Id = "17",
Name = "Electronics and Telecommunications",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "17").ToList()
},
new KnowledgeBranch
{
Id = "18",
Name = "Production and Technology",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "18").ToList()
},
new KnowledgeBranch
{
Id = "19",
Name = "Architecture and Construction",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "19").ToList()
},
new KnowledgeBranch
{
Id = "20",
Name = "Agrarian sciences and food",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "20").ToList()
},
new KnowledgeBranch
{
Id = "21",
Name = "Veterinary Medicine",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "21").ToList()
},
new KnowledgeBranch
{
Id = "22",
Name = "Health Care",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "22").ToList()
},
new KnowledgeBranch
{
Id = "23",
Name = "Social Work",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "23").ToList()
},
new KnowledgeBranch
{
Id = "24",
Name = "Service Area",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "24").ToList()
},
new KnowledgeBranch
{
Id = "25",
Name = "Military science, national security, state border security",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "25").ToList()
},
new KnowledgeBranch
{
Id = "26",
Name = "Civil Security",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "26").ToList()
},
new KnowledgeBranch
{
Id = "27",
Name = "Transport",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "27").ToList()
},
new KnowledgeBranch
{
Id = "28",
Name = "Public management and administration",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "28").ToList()
},
new KnowledgeBranch
{
Id = "29",
Name = "International Relations",
SpecialtyBases = specialtyBases.Where(x=>x.Id.Substring(0,2) == "29").ToList()
}
};
				await context.KnowledgeBranches.AddRangeAsync(knowledgeBranches);

				await context.SaveChangesAsync();

				var citiesList = await context.Cities.ToListAsync();

				var higherEducationFacilities = new List<HigherEducationFacility>
					{
						new HigherEducationFacility
						{
							Name = "Lviv National Medical University named after Danylo Halytsky",
							Info = "Lviv National Medical University named after Danylo Halytskyi (LNMU; lat. Universitatis Medicinalis Leopoliensis) is one of the largest and oldest medical educational institutions in Ukraine. It prepares specialists in the fields of: medicine, preventive medicine, dentistry and pharmacy. According to the international database Scopus University ranks first among medical universities of Ukraine.",
							Region = regions.FirstOrDefault(x=>x.Name == "Львівська область"),
							City = citiesList.FirstOrDefault(x => x.Name == "Львів"),
							Accreditation = accreditation[3],
							Address = "вул. Пекарська, 69",
							Website = "new.meduniv.lviv.ua",
							Telephone = "0231231028",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "Taras Shevchenko Kyiv National University",
Info = "a state institution of higher education of Ukraine, located in the city of Kyiv. According to the rankings of higher education institutions, for 2020 it took 1st place and is the largest university in terms of the number of students and majors. From 2009 to 2014, it had the status of an autonomous research university",
							Region = regions.FirstOrDefault(x=>x.Name == "м.Київ"),
							City = citiesList.FirstOrDefault(x => x.Name == "Київ"),
							Accreditation = accreditation[3],
							Address = "вул. Володимирська, 60",
							Website = "knu.ua",
							Telephone = "6683328733",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "Bukovyn State Medical University",
Info = "one of the largest institutions of higher education in the city of Chernivtsi. It is a modern multidisciplinary institution of higher medical education, included in the general register of the World Health Organization, the Great Charter of Universities, the European Association of Universities, which trains students of higher education according to the degree system of education .",
							Region = regions.FirstOrDefault(x=>x.Name == "Чернівецька область"),
							City = citiesList.FirstOrDefault(x => x.Name == "Чернівці"),
							Accreditation = accreditation[3],
							Address = "Театральна площа, 2",
							Website = "www.bsmu.edu.ua",
							Telephone = "23474623659",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "Ternopil National Medical University",
Info = "a state institution of higher education of Ukraine, located in the city of Kyiv. According to the rankings of higher education institutions, for 2020 it took 1st place and is the largest university in terms of the number of students and majors. From 2009 to 2014, it had the status of an autonomous research university",
							Region = regions.FirstOrDefault(x=>x.Name == "Тернопільська область"),
							City = citiesList.FirstOrDefault(x => x.Name == "Тернопіль"),
							Accreditation = accreditation[3],
							Address = "Майдан Волі, 1",
							Website = "tdmu.edu.ua",
							Telephone = "023sdads8",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "Lviv Ivan Franko National University",
Info = "one of the oldest universities in Ukraine and Eastern Europe and the most prestigious in Ukraine. It is the heir of the collegium (1608—1661) and the academy (1661—1773) of the Jesuits, the Josephine University (1784—1805), the Lviv Lyceum (1805—1817), the University Franz I (1817—1918), Yan-Kazimir Lviv University (1919—1939), Ivan Franko Lviv State University (1939—1999)",
							Region = regions.FirstOrDefault(x=>x.Name == "Львівська область"),
							City = citiesList.FirstOrDefault(x => x.Name == "Львів"),
							Accreditation = accreditation[3],
							Address = "вул. Університетська, 1",
							Website = "lnu.edu.ua",
							Telephone = "0322 603 402",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "Kyiv-Mohyla Academy National University",
Info = "The National University Kyiv-Mohyla Academy is an institution of higher education in Ukraine. It was founded in 1615. It is located in the buildings of the historical Kyiv-Mohyla Academy, from which it got its name. The university campus is located on Podil in Kyiv, between Contract Square and the embankment Dnipro.",
							Region = regions.FirstOrDefault(x=>x.Name == "м.Київ"),
							City = citiesList.FirstOrDefault(x => x.Name == "Київ"),
							Accreditation = accreditation[3],
							Address = "вулиця Григорія Сковороди, 2",
							Website = "www.ukma.edu.ua",
							Telephone = "044 425 6059",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "State University of Trade and Economics",
Info = "a higher educational institution of the Ministry of Education and Science of Ukraine in Kyiv, Ukraine. Founded as the Kyiv branch of the All-Union Correspondence Institute of Soviet Trade in 1946. It is located in the Desnyan district on the territory of the Forest Massif between Kyoto and Milyutenko streets.",
							Region = regions.FirstOrDefault(x=>x.Name == "м.Київ"),
							City = citiesList.FirstOrDefault(x => x.Name == "Київ"),
							Accreditation = accreditation[3],
							Address = "вулиця Кіото, 19",
							Website = "knute.edu.ua",
							Telephone = "044 513 3348",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "Vasyl Stefanyk Precarpathian National University",
Info = "Vasyl Stefanyk Pre-Carpathian National University is one of the oldest higher educational institutions of the Ivano-Frankivsk region. According to the decree of the President of Ukraine dated August 26, 1992, it was created on the basis of the pedagogical institute founded in 1940.",
							Region = regions.FirstOrDefault(x=>x.Name == "Івано-Франківська область"),
							City = citiesList.FirstOrDefault(x => x.Name == "Івано-Франківськ"),
							Accreditation = accreditation[3],
							Address = "вулиця Шевченка, 57",
							Website = "pnu.edu.ua",
							Telephone = "0342 531 574",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "National Technical University Dniprov Polytechnic",
Info = "Dnipro Polytechnic National Technical University is a state institution of higher education, a multi-disciplinary technical university, the oldest institution of higher education in the city of Dnipro, the first institution of higher mining education in Ukraine. It has national status.",
							Region = regions.FirstOrDefault(x=>x.Name == "Дніпропетровська область"),
							City = citiesList.FirstOrDefault(x => x.Name == "Дніпро"),
							Accreditation = accreditation[3],
							Address = "проспект Дмитра Яворницького, 19",
							Website = "nmu.org.ua",
							Telephone = "056 744 1411",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "Kyiv National University of Technology and Design",
Info = "Kyiv National University of Technology and Design is a higher educational institution in Ukraine of the IV accreditation level, founded in 1930. More than 10,000 students study at the university. Kyiv National University of Technology and Design entered the rating of TOP-100 best design schools in the world and ranked 71 place.",
							Region = regions.FirstOrDefault(x=>x.Name == "м.Київ"),
							City = citiesList.FirstOrDefault(x => x.Name == "Київ"),
							Accreditation = accreditation[3],
							Address = "вулиця Немировича-Данченка, 2",
							Website = "knutd.com.ua",
							Telephone = "044 256 2975",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "Lesia Ukrainka Volyn National University",
Info = "a state higher educational institution of the IV accreditation level in the city of Lutsk, Ukraine. Founded in 1940, throughout history it changed names: Lutsk State Teachers' Institute, Lutsk State Pedagogical Institute; in the status of a university, it had the names of Volyn State, Volyn National and East European National. Since 2020, it has returned its name to Volyn National University. Named in honor of the writer Lesya Ukrainka.",
							Region = regions.FirstOrDefault(x=>x.Name == "Волинська область"),
							City = citiesList.FirstOrDefault(x => x.Name == "Луцьк"),
							Accreditation = accreditation[3],
							Address = "проспект Волі, 13",
							Website = "vnu.edu.ua",
							Telephone = "0332 720 123",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "National University Poltava Polytechnic named after Yury Kondratyuk",
Info = "The university has modern material and technical resources. 9 educational buildings with a total area of 87,000 m², safe and favorable conditions for high-quality education. The library has approximately 500,000 items of literature, 5 reading rooms with 400 seats, 55 educational laboratories and 10 scientific research facilities equipped with stationary equipment, 26 computer classrooms at the disposal of students and teachers.",
							Region = regions.FirstOrDefault(x=>x.Name == "Полтавська область"),
							City = citiesList.FirstOrDefault(x => x.Name == "Полтава"),
							Accreditation = accreditation[3],
							Address = "Першотравневий проспект, 24",
							Website = "nupp.edu.ua",
							Telephone = "05325 61604",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "Dnipropetrovsk State University of Internal Affairs",
Info = "The university was founded on March 16, 1966, as the Dnipropetrovsk Special High School of the Militia of the Ministry of Internal Affairs of the USSR. In 1992, it was reorganized into the Dnipropetrovsk School of Militia of the Ministry of Internal Affairs of Ukraine. On September 1, 1997, the police school was transformed into a higher educational institution - the Dnipropetrovsk Legal Institute of the Ministry of Internal Affairs of Ukraine. 1998 The institution moved from 147 Artem St. to the premises of the former Dnipropetrovsk Military Anti-Aircraft Missile School at 26 Gagarin Ave.",
							Region = regions.FirstOrDefault(x=>x.Name == "Дніпропетровська область"),
							City = citiesList.FirstOrDefault(x => x.Name == "Дніпро"),
							Accreditation = accreditation[3],
							Address = "проспект Гагаріна, 26",
							Website = "dduvs.in.ua",
							Telephone = "Не зазначено",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "Zaporizhia State Medical University",
Info = "Zaporizhsky State Medical University is a higher education institution in Ukraine. Zaporizhia State Medical University is a modern educational center with the highest (IV) degree of accreditation. The university is one of the oldest higher medical educational institutions in Ukraine.",
							Region = regions.FirstOrDefault(x=>x.Name == "Запорізька область"),
							City = citiesList.FirstOrDefault(x => x.Name == "Запоріжжя"),
							Accreditation = accreditation[3],
							Address = "проспект Маяковського, 26",
							Website = "www.zsmu.edu.ua",
							Telephone = "0612 246 469",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "Yuriy Fedkovich Chernivtsi National University",
Info = "Yuriy Fedkovich Chernivtsi National University is a state higher education institution of the 4th level of accreditation in the city of Chernivtsi.",
							Region = regions.FirstOrDefault(x=>x.Name == "Чернівецька область"),
							City = citiesList.FirstOrDefault(x => x.Name == "Чернівці"),
							Accreditation = accreditation[3],
							Address = "вулиця Коцюбинського, 2",
							Website = "www.chnu.edu.ua",
							Telephone = "0372 584 810",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "National University of Bioresources and Nature Management of Ukraine",
Info = "The National University of Bioresources and Nature Management of Ukraine is a leading higher agricultural educational institution of Ukraine. From 2009 to 2014, it had the status of an autonomous research university. Located in the city of Kyiv.",
							Region = regions.FirstOrDefault(x=>x.Name == "м.Київ"),
							City = citiesList.FirstOrDefault(x => x.Name == "Київ"),
							Accreditation = accreditation[3],
							Address = "вулиця Героїв Оборони, 15",
							Website = "www.nubip.edu.ua",
							Telephone = "044 527 8205",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "Western Ukrainian National University",
Info = "Western Ukrainian National University is a higher educational institution of Ukraine of the IV accreditation level in Ternopil. The university trains almost 25,000 students at all levels of higher education. WUNU is a signatory of the Great Charter of Universities and a member of the Association of European Universities.",
							Region = regions.FirstOrDefault(x=>x.Name == "Тернопільська область"),
							City = citiesList.FirstOrDefault(x => x.Name == "Тернопіль"),
							Accreditation = accreditation[3],
							Address = "вулиця Львівська, 11",
							Website = "wunu.edu.ua",
							Telephone = "0352 517 575",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "M. P. Drahomanov National Pedagogical University",
Info = "Since the fall of 1989, the staff of the higher education institution began to actively seek the return to the institute of the name of Mykhailo Petrovich Drahomanov, unfairly selected in the mid-20s. This issue was constantly raised at meetings of teachers and students, meetings of the institute's council and philological, historical, pedagogical and other councils ",
							Region = regions.FirstOrDefault(x=>x.Name == "м.Київ"),
							City = citiesList.FirstOrDefault(x => x.Name == "Київ"),
							Accreditation = accreditation[3],
							Address = "вулиця Пирогова, 9",
							Website = "www.npu.edu.ua",
							Telephone = "044 239 3017",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "Khmelnytskyi National University",
Info = "higher educational institution in Podil, which trains specialists in many fields of knowledge and conducts educational, methodical, scientific and educational work. The university was founded in 1962. It went from the general technical faculty of the Ukrainian Polygraphic Institute to the Khmelnytskyi National University, which has the highest IV level accreditation.",
							Region = regions.FirstOrDefault(x=>x.Name == "Хмельницька область"),
							City = citiesList.FirstOrDefault(x => x.Name == "Хмельницький"),
							Accreditation = accreditation[3],
							Address = "вулиця Інститутська, 11",
							Website = "khnu.km.ua",
							Telephone = "0382 670 276",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "Vinnytsia National Technical University",
Info = "Ukrainian institution of higher education of the fourth level of accreditation, which trains specialists in the engineering and technical profile. The institution is a center of education, science and culture of the Podilsk region.",
							Region = regions.FirstOrDefault(x=>x.Name == "Вінницька область"),
							City = citiesList.FirstOrDefault(x => x.Name == "Вінниця"),
							Accreditation = accreditation[3],
							Address = "Хмельницьке шосе, 95",
							Website = "vntu.edu.ua",
							Telephone = "0432 560 848",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "Zhytomyr Ivan Franko State University",
Info = "the oldest higher educational institution of the Zhytomyr region. Founded in 1919 as the Volyn Pedagogical Institute.",
							Region = regions.FirstOrDefault(x=>x.Name == "Житомирська область"),
							City = citiesList.FirstOrDefault(x => x.Name == "Житомир"),
							Accreditation = accreditation[3],
							Address = "вулиця Велика Бердичівська, 40",
							Website = "zu.edu.ua",
							Telephone = "0412 431 417",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "Kharkiv Polytechnic Institute",
Info = "National Technical University Kharkiv Polytechnic Institute, until 1929 Kharkiv Institute of Technology, since 1975 Order of Lenin Kharkiv Polytechnic Institute named after V. I. Lenin — founded in 1885 in Kharkiv. The second technological institute in the Russian Empire after St. Petersburg. ",
							Region = regions.FirstOrDefault(x=>x.Name == "Харківська область"),
							City = citiesList.FirstOrDefault(x => x.Name == "Харків"),
							Accreditation = accreditation[3],
							Address = "вулиця Кирпичова, 2",
							Website = "kpi.kharkov.ua",
							Telephone = "057 707 6634",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "Kharkiv National Medical University",
Info = "Kharkiv National Medical University, formerly Kharkiv State Medical Institute. A higher educational institution, the purpose of which is the training of medical specialists and advanced training, the formation of a scientific and industrial cluster on the basis of the university.",
							Region = regions.FirstOrDefault(x=>x.Name == "Харківська область"),
							City = citiesList.FirstOrDefault(x => x.Name == "Харків"),
							Accreditation = accreditation[3],
							Address = "проспект Науки, 4",
							Website = "knmu.edu.ua",
							Telephone = "057 707 7380",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "Uzhhorod National University",
Info = "Uzhgorod National University is a member of the Association of Universities of the Carpathian Region (ACRU), which is part of the European University Association (EUA) and is an associate member of the International Association of Universities (IAU). The university cooperates with 125 partners from different countries, including Charles University, Technical University in Prague (Czech Republic), Corwin University, L. Košut University of State and Law (Hungary), P. J. Shafarik University of Košice, J. A. Comenius University (Slovakia) , the University of Oradea, the University of Cluj, Babes-Boai (Romania), the Institute of German Studies at the University of Landau, the University of Regensburg (Germany), the Association of Homeopathic Medicine in Rome (Italy), the University of Zagreb (Croatia), the Slovak Medical University ( Bratislava) and others. In 2020, 7 new international bilateral agreements, 7 agreements on the implementation of international projects and 8 agreements to support Erasmus+ academic mobility were concluded.",
							Region = regions.FirstOrDefault(x=>x.Name == "Закарпатська область"),
							City = citiesList.FirstOrDefault(x => x.Name == "Ужгород"),
							Accreditation = accreditation[3],
							Address = "вулиця Університетська, 14",
							Website = "uzhnu.edu.ua",
							Telephone = "0312 643 084",
							HigherEducationFacilityAdmins = new List<HigherEducationFacilityAdmin>{new HigherEducationFacilityAdmin{AppUser = users[1]}}
						},
						new HigherEducationFacility
						{
							Name = "Lviv Polytechnic National University",
Info = "the oldest technical institution of higher education in Ukraine and Eastern Europe, founded in 1816 as the Real School with the permission of the Austrian Emperor Franz I.",
							Region = regions.FirstOrDefault(x=>x.Name == "Львівська область"),
							City = citiesList.FirstOrDefault(x => x.Name == "Львів"),
							Accreditation = accreditation[3],
							Address = "вул. Степана Бандери, 12",
							Website = "lp.edu.ua",
							Telephone = "0322 582 111"
						},
					};
				await context.HigherEducationFacilities.AddRangeAsync(higherEducationFacilities);

				foreach (var item in higherEducationFacilities)
				{
					var eduComponents = new List<EduComponent>
					{
						new EduComponent
{
Name="Civil Law",
},
new EduComponent
{
Name="Legal Opinions of the Supreme Court",
},
new EduComponent
{
Name="Alternative Dispute Resolution",
},
new EduComponent
{
Name="Notarial process",
},
new EduComponent
{
Name="Comparative Civil Law and Procedure",
},
new EduComponent
{
Name="School of Applied Jurisprudence",
},
new EduComponent
{
Name="Practical training",
},
new EduComponent
{
Name="Discrete Mathematics",
},
new EduComponent
{
Name="Mathematical analysis",
},
new EduComponent
{
Name="Physics",
},
new EduComponent
{
Name="Introduction to Computer Science",
},
new EduComponent
{
Name="Foreign language",
},
new EduComponent
{
Name="Probability theory and mathematical statistics",
},
new EduComponent
{
Name="Computer technologies of data processing and visualization",
},
new EduComponent
{
Name="Algorithmization and programming",
},
new EduComponent
{
Name="Optimization methods and models",
},
new EduComponent
{
Name="Artificial Intelligence",
},
new EduComponent
{
Name="Management of IT projects",
},
new EduComponent
{
Name="Java Technology",
},
new EduComponent
{
Name="Administration of server systems",
},
new EduComponent
{
Name="Web Technologies",
},
new EduComponent
{
Name="Engineering and computer graphics",
},
new EduComponent
{
Name="Technologies of data analysis",
},
new EduComponent
{
Name="Technologies for creating software products",
},
new EduComponent
{
Name="Jurisprudence",
},
new EduComponent
{
Name="Psychology",
},
new EduComponent
{
Name="Oratory",
},
new EduComponent
{
Name="Life Safety",
},
new EduComponent
{
Name="History of Ukrainian culture",
},
new EduComponent
{
Name="Oratory",
},
new EduComponent
{
Name="Management",
},
						new EduComponent
{
Name="Philosophy",
},
new EduComponent
{
Name="Sociology",
},
new EduComponent
{
Name="Logic",
},
new EduComponent
{
Name="Accounting",
},
new EduComponent
{
Name="Organization of databases and knowledge",
},
new EduComponent
{
Name="Architecture of computer systems",
},
new EduComponent
{
Name="Theory of management in information systems",
}
};

					var specialties = new List<Specialty>
{
new Specialty
{
BudgetAllowed = true,
Languages = new List<Language>(languages.Take(new Random().Next(0, 3))),
StudyForms = new List<StudyForm>(studyForms.Take(new Random().Next(0,3))),
SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "122"),
Description = "General education in the field of information technologies, specialization Computer science. Keywords: programming, algorithmization, modeling, computer data processing, computing systems and technologies, fuzzy models, Machine Learning, Big Data Processing, programming on C#, C++, Python, Java, computer networks, distributed server systems, distributed and parallel computing, fuzzy models and networks, methods of computational intelligence.",
Degree = degrees[new Random().Next(0,3)],
PriceUAH = new Random().Next(50000,80000),

EduComponents = new List<EduComponent>(eduComponents.Take(new Random().Next(10,30))),
},
new Specialty
{
BudgetAllowed = true,
Languages = new List<Language>(languages.Take(new Random().Next(0, 3))),
StudyForms = new List<StudyForm>(studyForms.Take(new Random().Next(0,3))),
SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "081"),
Description = "Training of a new generation of lawyers capable of carrying out professional activities in the field of contract, family and inheritance law, protecting the personal property and non-property rights of their clients in the conditions of ever-growing competition on the legal services market.",
Degree = degrees[new Random().Next(0,3)],
PriceUAH = new Random().Next(50000,80000),

EduComponents = new List<EduComponent>(eduComponents.Take(new Random().Next(10,30))),
},
new Specialty
{
BudgetAllowed = false,
Languages = new List<Language>(languages.Take(new Random().Next(0, 3))),
StudyForms = new List<StudyForm>(studyForms.Take(new Random().Next(0,3))),
SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "081"),
Description = "Training of a new generation of lawyers capable of carrying out professional activities in the field of contract, family and inheritance law, protecting the personal property and non-property rights of their clients in the conditions of ever-growing competition on the legal services market.",
Degree = degrees[new Random().Next(0,3)],
PriceUAH = new Random().Next(50000,80000),
								EduComponents = new List<EduComponent>(eduComponents.Take(new Random().Next(10,30))),
},
new Specialty
{
BudgetAllowed = true,
Languages = new List<Language>(languages.Take(new Random().Next(0, 3))),
StudyForms = new List<StudyForm>(studyForms.Take(new Random().Next(0,3))),
SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "125"),
Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
Degree = degrees[new Random().Next(0,3)],
PriceUAH = new Random().Next(50000,80000),
EduComponents = new List<EduComponent>(eduComponents.Take(new Random().Next(10,30))),
},
new Specialty
{
BudgetAllowed = false,
Languages = new List<Language>(languages.Take(new Random().Next(0, 3))),
StudyForms = new List<StudyForm>(studyForms.Take(new Random().Next(0,3))),
SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "121"),
Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
Degree = degrees[new Random().Next(0,3)],
PriceUAH = new Random().Next(50000,80000),
EduComponents = new List<EduComponent>(eduComponents.Take(new Random().Next(10,30))),
},
new Specialty
{
BudgetAllowed = true,
Languages = new List<Language>(languages.Take(new Random().Next(0, 3))),
StudyForms = new List<StudyForm>(studyForms.Take(new Random().Next(0,3))),
SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "123"),
Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
Degree = degrees[new Random().Next(0,3)],
PriceUAH = new Random().Next(50000,80000),

EduComponents = new List<EduComponent>(eduComponents.Take(new Random().Next(10,30))),
},
new Specialty
{
BudgetAllowed = false,
Languages = new List<Language>(languages.Take(new Random().Next(0, 3))),
StudyForms = new List<StudyForm>(studyForms.Take(new Random().Next(0,3))),
SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "124"),
Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
Degree = degrees[new Random().Next(0,3)],
PriceUAH = new Random().Next(50000,80000),
EduComponents = new List<EduComponent>(eduComponents.Take(new Random().Next(10,30))),
},
new Specialty
{
BudgetAllowed = true,
Languages = new List<Language>(languages.Take(new Random().Next(0, 3))),
StudyForms = new List<StudyForm>(studyForms.Take(new Random().Next(0,3))),
SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "112"),
Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
Degree = degrees[new Random().Next(0,3)],
PriceUAH = new Random().Next(50000,80000),
EduComponents = new List<EduComponent>(eduComponents.Take(new Random().Next(10,30))),

},
new Specialty
{
BudgetAllowed = true,
Languages = new List<Language>(languages.Take(new Random().Next(0, 3))),
StudyForms = new List<StudyForm>(studyForms.Take(new Random().Next(0,3))),
SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "111"),
Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
Degree = degrees[new Random().Next(0,3)],
PriceUAH = new Random().Next(50000,80000),
EduComponents = new List<EduComponent>(eduComponents.Take(new Random().Next(10,30))),
},
							new Specialty
{
BudgetAllowed = false,
Languages = new List<Language>(languages.Take(new Random().Next(0, 3))),
StudyForms = new List<StudyForm>(studyForms.Take(new Random().Next(0,3))),
SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "076"),
Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
Degree = degrees[new Random().Next(0,3)],
PriceUAH = new Random().Next(50000,80000),
EduComponents = new List<EduComponent>(eduComponents.Take(new Random().Next(10,30))),
},
new Specialty
{
BudgetAllowed = true,
Languages = new List<Language>(languages.Take(new Random().Next(0, 3))),
StudyForms = new List<StudyForm>(studyForms.Take(new Random().Next(0,3))),
SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "073"),
Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
Degree = degrees[new Random().Next(0,3)],
PriceUAH = new Random().Next(50000,80000),
EduComponents = new List<EduComponent>(eduComponents.Take(new Random().Next(10,30))),
},
new Specialty
{
BudgetAllowed = true,
Languages = new List<Language>(languages.Take(new Random().Next(0, 3))),
StudyForms = new List<StudyForm>(studyForms.Take(new Random().Next(0,3))),
SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "141"),
Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
Degree = degrees[new Random().Next(0,3)],
PriceUAH = new Random().Next(50000,80000),
EduComponents = new List<EduComponent>(eduComponents.Skip(new Random().Next(10,30))),
},
new Specialty
{
BudgetAllowed = false,
Languages = new List<Language>(languages.Take(new Random().Next(0, 3))),
StudyForms = new List<StudyForm>(studyForms.Take(new Random().Next(0,3))),
SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "142"),
Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
Degree = degrees[new Random().Next(0,3)],
PriceUAH = new Random().Next(50000,80000),
EduComponents = new List<EduComponent>(eduComponents.Skip(new Random().Next(10,30))),
},
new Specialty
{
BudgetAllowed = true,
Languages = new List<Language>(languages.Take(new Random().Next(0, 3))),
StudyForms = new List<StudyForm>(studyForms.Take(new Random().Next(0,3))),
SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "143"),
Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
Degree = degrees[new Random().Next(0,3)],
PriceUAH = new Random().Next(50000,80000),
EduComponents = new List<EduComponent>(eduComponents.Skip(new Random().Next(10,30))),
},
new Specialty
{
BudgetAllowed = true,
Languages = new List<Language>(languages.Take(new Random().Next(0, 3))),
StudyForms = new List<StudyForm>(studyForms.Take(new Random().Next(0,3))),
SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "144"),
Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
Degree = degrees[new Random().Next(0,3)],
PriceUAH = new Random().Next(50000,80000),
EduComponents = new List<EduComponent>(eduComponents.Skip(new Random().Next(10,30))),

},
new Specialty
{
BudgetAllowed = false,
Languages = new List<Language>(languages.Take(new Random().Next(0, 3))),
StudyForms = new List<StudyForm>(studyForms.Take(new Random().Next(0,3))),
SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "145"),
Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
Degree = degrees[new Random().Next(0,3)],
PriceUAH = new Random().Next(50000,80000),
EduComponents = new List<EduComponent>(eduComponents.Skip(new Random().Next(10,30)))
},
};

					var faculties = new List<Faculty>
{
new Faculty
{
Name = "Faculty1",
Info = "Info1",
StudentsCount = new Random().Next(5000,20000),
KnowledgeBranches = new List<KnowledgeBranch>{knowledgeBranches[7]},
Specialties = new List<Specialty>(specialties.Where(x=>x.SpecialtyBase.Id.Substring(0,2) == "08"))
},
new Faculty
{
Name = "Faculty2",
Info = "Info2",
StudentsCount = new Random().Next(5000,20000),
KnowledgeBranches = new List<KnowledgeBranch>{knowledgeBranches[11]},
Specialties = new List<Specialty>(specialties.Where(x=>x.SpecialtyBase.Id.Substring(0,2) == "12"))
},
new Faculty
{
Name = "Faculty3",
Info = "Info3",
StudentsCount = new Random().Next(5000,20000),
KnowledgeBranches = new List<KnowledgeBranch>{knowledgeBranches[10]},
Specialties = new List<Specialty>(specialties.Where(x=>x.SpecialtyBase.Id.Substring(0,2) == "11"))
},
new Faculty
{
Name = "Faculty4",
Info = "Info4",
StudentsCount = new Random().Next(5000,20000),
KnowledgeBranches = new List<KnowledgeBranch>{knowledgeBranches[13]},
Specialties = new List<Specialty>(specialties.Where(x=>x.SpecialtyBase.Id.Substring(0,2) == "14"))
},
new Faculty
{
Name = "Faculty5",
Info = "Info5",
StudentsCount = new Random().Next(5000,20000),
KnowledgeBranches = new List<KnowledgeBranch>{knowledgeBranches[6]},
Specialties = new List<Specialty>(specialties.Where(x=>x.SpecialtyBase.Id.Substring(0,2) == "07"))
},
};
					var reviews = new List<Review>
					{
						new Review
						{
							Author = users[0],
							Body = "Test Review message consisting of author, HigherEducationFacility, message, 5 start rating",
							Rating = new Random().Next(1, 6),
						},
						new Review
						{
							Author = users[1],
							Body = "Slightly different test Review message consisting of author, HigherEducationFacility, message, 4 star* rating",
							Rating = new Random().Next(1, 6),
						},
						new Review
						{
							Author = users[2],
							Body = "Another test Review message consisting of author being user3, HigherEducationFacility, message, 1 star rating",
							Rating = new Random().Next(1, 6),
						}
					};

					item.Faculties = faculties.Take(new Random().Next(2, 5)).ToList();
					item.Reviews = reviews;
					context.Users.FirstOrDefault().HigherEducationFacility = item;
				}
				await context.SaveChangesAsync();
			}
		}
	}
}