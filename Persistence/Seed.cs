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
					new Degree{Name="Молодший Бакалавр"},
					new Degree{Name="Бакалавр"},
					new Degree{Name="Магістр"}
				};
				await context.Degrees.AddRangeAsync(degrees);
				var users = new List<AppUser>
				{
					new AppUser
					{
						DisplayName = "GlobalAdmin",
						UserName = "GlobalAdmin1",
						Email = "GlobalAdmin@test.com",
						Bio="GlobalAdmin!",
						Photo = new Photo{Id = "1",Url = ""},
						IsGlobalAdmin = true
					},
					new AppUser
					{
						DisplayName = "LocalAdmin",
						UserName = "LocalAdmin1",
						Email = "LocalAdmin@test.com",
						Photo = new Photo{Id = "2",Url = ""},
						Bio="LocalAdmin!"
					},
					new AppUser
					{
						DisplayName = "User",
						UserName = "User1",
						Email = "User@test.com",
						Photo = new Photo{Id = "3",Url = ""},
						Bio="User!"
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
				await context.SaveChangesAsync();
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
				var disciplines = new List<Discipline>
				{
					new Discipline
					{
						Name="Цивільне право",
					},
					new Discipline
					{
						Name="Правові висновки Верховного Cуду",
					},
					new Discipline
					{
						Name="Альтернативні способи вирішення суперечок",
					},
					new Discipline
					{
						Name="Нотаріальний процес",
					},
					new Discipline
					{
						Name="Порівняльне цивільне право і процес",
					},
					new Discipline
					{
						Name="Школа прикладної юриспруденції",
					},
					new Discipline
					{
						Name="Практична підготовка",
					},
					new Discipline
					{
						Name="Дискретна математика",
					},
					new Discipline
					{
						Name="Математичний аналіз",
					},
					new Discipline
					{
						Name="Фізика",
					},
					new Discipline
					{
						Name="Вступ до комп'ютерних наук",
					},
					new Discipline
					{
						Name="Іноземна мова",
					},
					new Discipline
					{
						Name="Теорія ймовірностей та математична статистика",
					},
					new Discipline
					{
						Name="Комп'ютерні технології обробки та візуалізації даних",
					},
					new Discipline
					{
						Name="Алгоритмізація та програмування",
					},
					new Discipline
					{
						Name="Оптимізаційні методи та моделі",
					},
					new Discipline
					{
						Name="Штучний інтелект",
					},
					new Discipline
					{
						Name="Управління ІТ-проектами",
					},
					new Discipline
					{
						Name="Технологія Java",
					},
					new Discipline
					{
						Name="Адміністрування серверних систем",
					},
					new Discipline
					{
						Name="Web-технології",
					},
					new Discipline
					{
						Name="Інженерна та комп'ютерна графіка",
					},
					new Discipline
					{
						Name="Технології аналізу даних",
					},
					new Discipline
					{
						Name="Технології створення програмних продуктів",
					},
					new Discipline
					{
						Name="Правознавство",
					},
					new Discipline
					{
						Name="Психологія",
					},
					new Discipline
					{
						Name="Ораторське мистецтво",
					},
					new Discipline
					{
						Name="Безпека життя",
					},
					new Discipline
					{
						Name="Історія української культури",
					},
					new Discipline
					{
						Name="Ораторське мистецтво",
					},
					new Discipline
					{
						Name="Менеджмент",
					},
					new Discipline
					{
						Name="Філософія",
					},
					new Discipline
					{
						Name="Соціологія",
					},
					new Discipline
					{
						Name="Логіка",
					},
					new Discipline
					{
						Name="Бухгалтерський облік",
					},
					new Discipline
					{
						Name="Організація баз даних та знань",
					},
					new Discipline
					{
						Name="Архітектура обчислювальних систем",
					},
					new Discipline
					{
						Name="Теорія управління в інформаційних системах",
					},
				};
				await context.Disciplines.AddRangeAsync(disciplines);
				var specialtyBases = new List<SpecialtyBase>
				{
					new SpecialtyBase
					{
						Id="011",
						Name="Освітні, педагогічні науки",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0111"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="012",
						Name="Дошкільна освіта",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0112"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="013",
						Name="Початкова освіта",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0113"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="014",
						Name="Середня освіта (за предметними спеціальностями)",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0114"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="015",
						Name="Професійна освіта (за спеціалізаціями)",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0114"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="016",
						Name="Спеціальна освіта",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0113"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="017",
						Name="Фізична культура і спорт",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "1014"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="021",
						Name="Аудіовізуальне мистецтво та виробництво",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0211"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="022",
						Name="Дизайн",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0212"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="023",
						Name="Образотворче мистецтво, декоративне мистецтво, реставрація",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0213"),
							isceds.FirstOrDefault(x => x.Id == "0214"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="024",
						Name="Хореографія",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0215"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="025",
						Name="Музичне мистецтво",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0215"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="026",
						Name="Сценічне мистецтво",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0215"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="027",
						Name="Музеєзнавство, пам’яткознавство",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0322"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="028",
						Name="Менеджмент соціокультурної діяльності",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0413"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="029",
						Name="Інформаційна, бібліотечна та архівна справа",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0322"),
							isceds.FirstOrDefault(x => x.Id == "0415"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="031",
						Name="Релігієзнавство",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0221"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="032",
						Name="Історія та археологія",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0222"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="033",
						Name="Філософія",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0223"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="034",
						Name="Культурологія",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0314"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="035",
						Name="Філологія",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0231"),
							isceds.FirstOrDefault(x => x.Id == "0232"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="041",
						Name="Богослов’я",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0221"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="051",
						Name="Економіка",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0311"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="052",
						Name="Політологія",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0312"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="053",
						Name="Психологія",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0313"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="054",
						Name="Соціологія",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0314"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="061",
						Name="Журналістика",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0321"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="071",
						Name="Облік і оподаткування",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0411"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="072",
						Name="Фінанси, банківська справа, страхування та фондовий ринок",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0412"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="073",
						Name="Менеджмент",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0413"),
							isceds.FirstOrDefault(x => x.Id == "0415"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="075",
						Name="Маркетинг",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0414"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="076",
						Name="Підприємництво та торгівля",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0413"),
							isceds.FirstOrDefault(x => x.Id == "0416"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="081",
						Name="Право",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0421"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="091",
						Name="Біологія та біохімія",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0511"),
							isceds.FirstOrDefault(x => x.Id == "0512"),
							isceds.FirstOrDefault(x => x.Id == "0522"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="101",
						Name="Екологія",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0521"),
							isceds.FirstOrDefault(x => x.Id == "0522"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="102",
						Name="Хімія",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0531"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="103",
						Name="Науки про Землю",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0532"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="104",
						Name="Фізика та астрономія",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0533"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="105",
						Name="Прикладна фізика та наноматеріали",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0533"),
							isceds.FirstOrDefault(x => x.Id == "0588"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="106",
						Name="Географія",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0314"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="111",
						Name="Математика",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0541"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="112",
						Name="Статистика",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0542"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="113",
						Name="Прикладна математика",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0541"),
							isceds.FirstOrDefault(x => x.Id == "0588"),
							isceds.FirstOrDefault(x => x.Id == "0613"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="121",
						Name="Інженерія програмного забезпечення",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0613"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="122",
						Name="Комп’ютерні науки",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0613"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="123",
						Name="Комп’ютерна інженерія",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0612"),
							isceds.FirstOrDefault(x => x.Id == "0714"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="124",
						Name="Системний аналіз",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0688"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="125",
						Name="Кібербезпека та захист інформації",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0612"),
							isceds.FirstOrDefault(x => x.Id == "0688"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="126",
						Name="Інформаційні системи та технології",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0611"),
							isceds.FirstOrDefault(x => x.Id == "0612"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="131",
						Name="Прикладна механіка",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0715"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="132",
						Name="Матеріалознавство",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0588"),
							isceds.FirstOrDefault(x => x.Id == "0715"),
							isceds.FirstOrDefault(x => x.Id == "0788"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="133",
						Name="Галузеве машинобудування",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0715"),
							isceds.FirstOrDefault(x => x.Id == "0716"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="134",
						Name="Авіаційна та ракетно-космічна техніка",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0716"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="135",
						Name="Суднобудування",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0716"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="136",
						Name="Металургія",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0715"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="141",
						Name="Електроенергетика, електротехніка та електромеханіка",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0713"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="142",
						Name="Енергетичне машинобудування",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0713"),
							isceds.FirstOrDefault(x => x.Id == "0716"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="143",
						Name="Атомна енергетика",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0713"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="144",
						Name="Теплоенергетика",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0713"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="145",
						Name="Відновлювані джерела енергії та гідроенергетика",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0713"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="161",
						Name="Хімічні технології та інженерія",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0711"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="162",
						Name="Біотехнології та біоінженерія",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0512"),
							isceds.FirstOrDefault(x => x.Id == "0711"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="163",
						Name="Біомедична інженерія",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0588"),
							isceds.FirstOrDefault(x => x.Id == "0788"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="171",
						Name="Електроніка",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0714"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="172",
						Name="Електронні комунікації та радіотехніка",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0714"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{
						Id="173",
						Name="Авіоніка",
					Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0714"),
							isceds.FirstOrDefault(x => x.Id == "0716"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="174",
						Name="Автоматизація, комп’ютерно-інтегровані технології та робототехніка",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0714"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="175",
						Name="Інформаційно-вимірювальні технології",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0714"),
							isceds.FirstOrDefault(x => x.Id == "0788"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="176",
						Name="Мікро- та наносистемна техніка",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0714"),
							isceds.FirstOrDefault(x => x.Id == "0788"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="181",
						Name="Харчові технології",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0721"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="182",
						Name="Технології легкої промисловості",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0723"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="183",
						Name="Технології захисту навколишнього середовища",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0712"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="184",
						Name="Гірництво",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0724"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="185",
						Name="Нафтогазова інженерія та технології",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0724"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="186",
						Name="Видавництво та поліграфія",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0211"),
							isceds.FirstOrDefault(x => x.Id == "0611"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="187",
						Name="Деревообробні та меблеві технології",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0722"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="191",
						Name="Архітектура та містобудування",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0731"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="192",
						Name="Будівництво та цивільна інженерія",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0732"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="193",
						Name="Геодезія та землеустрій",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0532"),
							isceds.FirstOrDefault(x => x.Id == "0731"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="194",
						Name="Гідротехнічне будівництво, водна інженерія та водні технології",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0732"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="201",
						Name="Агрономія",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0811"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="202",
						Name="Захист і карантин рослин",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0811"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="203",
						Name="Садівництво, плодоовочівництво та виноградарство",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0811"),
							isceds.FirstOrDefault(x => x.Id == "0812"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="204",
						Name="Технологія виробництва і переробки продукції тваринництва",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0811"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="206",
						Name="Садово-паркове господарство",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0812"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="207",
						Name="Водні біоресурси та аквакультура",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0831"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="208",
						Name="Агроінженерія",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0716"),
							isceds.FirstOrDefault(x => x.Id == "0888"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="211",
						Name="Ветеринарна медицина",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0841"),
							isceds.FirstOrDefault(x => x.Id == "1022"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="221",
						Name="Стоматологія",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0911"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="222",
						Name="Медицина",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0912"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="223",
						Name="Медсестринство",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0913"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="224",
						Name="Технології медичної діагностики та лікування",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0914"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="225",
						Name="Медична психологія",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0313"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="226",
						Name="Фармація, промислова фармація",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0588"),
							isceds.FirstOrDefault(x => x.Id == "0711"),
							isceds.FirstOrDefault(x => x.Id == "0916"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="227",
						Name="Терапія та реабілітація",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0915"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="228",
						Name="Педіатрія",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0912"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="229",
						Name="Громадське здоров’я",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0413"),
							isceds.FirstOrDefault(x => x.Id == "0988"),
							isceds.FirstOrDefault(x => x.Id == "1021"),
							isceds.FirstOrDefault(x => x.Id == "1022"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="231",
						Name="Соціальна робота",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0921"),
							isceds.FirstOrDefault(x => x.Id == "0922"),
							isceds.FirstOrDefault(x => x.Id == "0923"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="232",
						Name="Соціальне забезпечення",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0413"),
							isceds.FirstOrDefault(x => x.Id == "0923"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="241",
						Name="Готельно-ресторанна справа",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "1013"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="242",
						Name="Туризм і рекреація",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "1015"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="251",
						Name="Державна безпека",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "1031"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="252",
						Name="Безпека державного кордону",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "1031"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="253",
						Name="Військове управління (за видами збройних сил)",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "1031"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="254",
						Name="Забезпечення військ (сил)",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "1031"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="255",
						Name="Озброєння та військова техніка",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "1031"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="256",
						Name="Національна безпека (за окремими сферами забезпечення і видами діяльності)***",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "1031"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="257",
						Name="Управління інформаційною безпекою",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "1031"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="261",
						Name="Пожежна безпека",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "1032"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="262",
						Name="Правоохоронна діяльність",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "1032"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="263",
						Name="Цивільна безпека",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "1022"),
							isceds.FirstOrDefault(x => x.Id == "1032"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="271",
						Name="Морський та внутрішній водний транспорт****",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0716"),
							isceds.FirstOrDefault(x => x.Id == "1041"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="272",
						Name="Авіаційний транспорт",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0716"),
							isceds.FirstOrDefault(x => x.Id == "1041"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="273",
						Name="Залізничний транспорт",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0716"),
							isceds.FirstOrDefault(x => x.Id == "0732"),
							isceds.FirstOrDefault(x => x.Id == "1041"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="274",
						Name="Автомобільний транспорт",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0716"),
							isceds.FirstOrDefault(x => x.Id == "1041"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="275",
						Name="Транспортні технології (за видами)",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "1041"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="281",
						Name="Публічне управління та адміністрування",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0413"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="291",
						Name="Міжнародні відносини, суспільні комунікації та регіональні студії",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0312"),
							isceds.FirstOrDefault(x => x.Id == "0314"),
							isceds.FirstOrDefault(x => x.Id == "0388"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="292",
						Name="Міжнародні економічні відносини",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0311"),
							isceds.FirstOrDefault(x => x.Id == "0312"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
					new SpecialtyBase
					{

						Id="293",
						Name="Міжнародне право",
						Isceds = new List<Isced>
						{
							isceds.FirstOrDefault(x => x.Id == "0421"),
						},
						AllDisciplines = new List<Discipline>(disciplines)
					},
				};
				await context.SpecialtyBases.AddRangeAsync(specialtyBases);
				var citiesList = await context.Cities.ToListAsync();
				var universities = new List<University>
				{
					new University
					{
						Name = "Львівський національний медичний університет імені Данила Галицького",
						Info = "Львівський національний медичний університет імені Данила Галицького (ЛНМУ; лат. Universitatis Medicinalis Leopoliensis) — один з найбільших та найстаріших медичних навчальних закладів України. Готує спеціалістів за напрямами: медицина, медико-профілактична справа, стоматологія та фармація. За даними міжнародної бази Scopus університет посідає перше місце серед медичних вишів України",
						City = citiesList.FirstOrDefault(x => x.Name == "Львів"),
						StudentsCount = 5150,
						Address = "вул. Пекарська, 69",
						Website = "new.meduniv.lviv.ua",
						Telephone = "0231231028",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Київський національний університет імені Тараса Шевченка",
						Info = "державний заклад вищої освіти України, розташований у місті Києві. За рейтингами ВНЗ, на 2020 рік посідав 1 місце і є найбільшим університетом за кількістю студентів і спеціальностей. З 2009 до 2014 року мав статус автономного дослідницького університету",
						City = citiesList.FirstOrDefault(x => x.Name == "Київ"),
						StudentsCount = 32000,
						Address = "вул. Володимирська, 60",
						Website = "knu.ua",
						Telephone = "6683328733",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Буковинський державний медичний університет",
						Info = "один із найбільших закладів вищої освіти м. Чернівці. Це сучасний багатопрофільний заклад вищої медичної освіти, включений до загального реєстру Всесвітньої організації охорони здоров'я, Великої Хартії університетів, Європейської асоціації університету, що здійснює підготовку здобувачів вищої освіти за ступеневою системою освіти. ",
						City = citiesList.FirstOrDefault(x => x.Name == "Чернівці"),
						StudentsCount = 5284,
						Address = "Театральна площа, 2",
						Website = "www.bsmu.edu.ua",
						Telephone = "23474623659",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Тернопільський національний медичний університет",
						Info = "державний заклад вищої освіти України, розташований у місті Києві. За рейтингами ВНЗ, на 2020 рік посідав 1 місце і є найбільшим університетом за кількістю студентів і спеціальностей. З 2009 до 2014 року мав статус автономного дослідницького університету",
						City = citiesList.FirstOrDefault(x => x.Name == "Тернопіль"),
						StudentsCount = 6530,
						Address = "Майдан Волі, 1",
						Website = "tdmu.edu.ua",
						Telephone = "023sdads8",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Львівський національний університет імені Івана Франка",
						Info = "один із найстаріших університетів України й Східної Європи та найпрестижніших в Україні. Є спадкоємцем колегіуму (1608—1661) та академії (1661—1773) єзуїтів, Йосифинського університету (1784—1805), Львівського ліцею (1805—1817), Університету Франца I (1817—1918), Львівського університету Яна-Казимира (1919—1939), Львівського державного університету імені Івана Франка (1939—1999).",
						City = citiesList.FirstOrDefault(x => x.Name == "Львів"),
						StudentsCount = 25000,
						Address = "вул. Університетська, 1",
						Website = "lnu.edu.ua",
						Telephone = "0322 603 402",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Національний університет «Києво-Могилянська академія»",
						Info = "Національний університет «Києво-Могилянська академія» це заклад вищої освіти в Україні. Заснований 1615 року. Розміщується в корпусах історичної Києво-Могилянської академії, від якої отримав свою назву. Університетське містечко розташоване на Подолі в Києві, між Контрактовою площею та набережною Дніпра. ",
						City = citiesList.FirstOrDefault(x => x.Name == "Київ"),
						StudentsCount = 4422,
						Address = "вулиця Григорія Сковороди, 2",
						Website = "www.ukma.edu.ua",
						Telephone = "044 425 6059",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Державний торговельно-економічний університет",
						Info = "вищий навчальний заклад Міністерства освіти і науки України в Києві, Україна. Заснований як Київський філіал Всесоюзного заочного інституту радянської торгівлі в 1946 році. Знаходиться у Деснянському районі на території Лісового масиву між вулицями Кіото і Мілютенка.",
						City = citiesList.FirstOrDefault(x => x.Name == "Київ"),
						StudentsCount = 36600,
						Address = "вулиця Кіото, 19",
						Website = "knute.edu.ua",
						Telephone = "044 513 3348",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Прикарпатський національний університет імені Василя Стефаника",
						Info = "Прикарпатський національний університет імені Василя Стефаника є одним з найстаріших вищих навчальних закладів Івано-Франківської області. Згідно з указом Президента України від 26 серпня 1992 р. його створено на базі педагогічного інституту, заснованого 1940 р. ",
						City = citiesList.FirstOrDefault(x => x.Name == "Івано-Франківськ"),
						StudentsCount = 18000,
						Address = "вулиця Шевченка, 57",
						Website = "pnu.edu.ua",
						Telephone = "0342 531 574",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Національний технічний університет «Дніпровська політехніка»",
						Info = "Національний технічний університет «Дніпро́вська політе́хніка» — державний заклад вищої освіти, багатогалузевий технічний університет, найстаріший заклад вищої освіти в м. Дніпро, перший заклад вищої гірничої освіти України. Має статус національного.",
						City = citiesList.FirstOrDefault(x => x.Name == "Дніпро"),
						StudentsCount = 8260,
						Address = "проспект Дмитра Яворницького, 19",
						Website = "nmu.org.ua",
						Telephone = "056 744 1411",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Київський національний університет технологій та дизайну",
						Info = "Ки́ївський націона́льний університе́т техноло́гій та диза́йну — вищий навчальний заклад в Україні IV рівня акредитації, заснований 1930 року. В університеті навчається більше 10 тис. Київський національний університет технологій та дизайну увійшов у рейтинг «ТОР-100 кращих дизайнерських шкіл світу» і посів 71 місце.",
						City = citiesList.FirstOrDefault(x => x.Name == "Київ"),
						StudentsCount = 15000,
						Address = "вулиця Немировича-Данченка, 2",
						Website = "knutd.com.ua",
						Telephone = "044 256 2975",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Волинський національний університет імені Лесі Українки",
						Info = "державний вищий навчальний заклад IV рівня акредитації у місті Луцьк, Україна. Заснований у 1940 році, впродовж історії змінював назви: Луцький державний учительський інститут, Луцький державний педагогічний інститут; у статусі університету мав назви Волинського державного, Волинського національного і Східноєвропейського національного. З 2020 року повернув назву Волинський національний університет. Названий на честь письменниці Лесі Українки.",
						City = citiesList.FirstOrDefault(x => x.Name == "Луцьк"),
						StudentsCount = 12369,
						Address = "проспект Волі, 13",
						Website = "vnu.edu.ua",
						Telephone = "0332 720 123",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Національний університет «Полтавська політехніка імені Юрія Кондратюка»",
						Info = "Університет володіє сучасними матеріально-технічними ресурсами. 9 навчальних корпусів із загальною площею 87 000 м², безпечні сприятливі умови для високоякісного навчання. Бібліотека налічує приблизно 500 тисяч одиниць літератури, 5 читальних залів з 400 місцями, 55 навчальних лабораторій та 10 науково-дослідницьких, споряджених стаціонарним обладнанням, 26 комп'ютерних класів у розпорядженні студентів і викладачів. ",
						City = citiesList.FirstOrDefault(x => x.Name == "Полтава"),
						StudentsCount = 10000,
						Address = "Першотравневий проспект, 24",
						Website = "nupp.edu.ua",
						Telephone = "05325 61604",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Дніпропетровський державний університет внутрішніх справ",
						Info = "Університет заснований 16 березня 1966, як Дніпропетровська спеціальна середня школа міліції МВС СРСР. В 1992 вона була реорганізована в Дніпропетровське училище міліції МВС України. 1 вересня 1997 училище міліції було перетворено у вищий навчальний заклад — Дніпропетровський юридичний інститут МВС України. 1998 р. заклад з вул. Артема, 147 переїхав до приміщень колишнього Дніпропетровського військового зенітно-ракетного училища за адресою просп. Гагарина, 26. ",
						City = citiesList.FirstOrDefault(x => x.Name == "Дніпро"),
						StudentsCount = 0,
						Address = "проспект Гагаріна, 26",
						Website = "dduvs.in.ua",
						Telephone = "Не зазначено",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Запорізький державний медичний університет",
						Info = "Запорізький державний медичний університет — заклад вищої освіти в Україні. Запорізький державний медичний університет — це сучасний навчальний центр, що має вищий (IV) ступінь акредитації. Університет — один з найстаріших вищих медичних навчальних закладів України.",
						City = citiesList.FirstOrDefault(x => x.Name == "Запоріжжя"),
						StudentsCount = 8879,
						Address = "проспект Маяковського, 26",
						Website = "www.zsmu.edu.ua",
						Telephone = "0612 246 469",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Чернівецький національний університет імені Юрія Федьковича",
						Info = "Чернівецький національний університет імені Юрія Федьковича — державний вищий заклад освіти 4-го рівня акредитації у місті Чернівці.",
						City = citiesList.FirstOrDefault(x => x.Name == "Чернівці"),
						StudentsCount = 19227,
						Address = "вулиця Коцюбинського, 2",
						Website = "www.chnu.edu.ua",
						Telephone = "0372 584 810",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Національний університет біоресурсів і природокористування України",
						Info = "Націона́льний університе́т біоресу́рсів і природокористува́ння Украї́ни, є провідним вищим аграрним закладом освіти України. З 2009 до 2014 року мав статус автономного дослідницького університету. Розташований у місті Києві. ",
						City = citiesList.FirstOrDefault(x => x.Name == "Київ"),
						StudentsCount = 0,
						Address = "вулиця Героїв Оборони, 15",
						Website = "www.nubip.edu.ua",
						Telephone = "044 527 8205",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Західноукраїнський національний універиситет",
						Info = "Західноукраїнський національний університет — вищий навчальний заклад України IV-го рівня акредитації в м. Тернополі. Університет здійснює підготовку майже 25 тисяч студентів на всіх рівнях вищої освіти. ЗУНУ є підписантом Великої хартії університетів та членом Асоціації європейських університетів.",
						City = citiesList.FirstOrDefault(x => x.Name == "Тернопіль"),
						StudentsCount = 14963,
						Address = "вулиця Львівська, 11",
						Website = "wunu.edu.ua",
						Telephone = "0352 517 575",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Національний педагогічний університет імені М. П. Драгоманова",
						Info = "З осені 1989 року колектив вишу став активно домагатися повернення інститутові несправедливо відібраного в середині 20-х років імені Михайла Петровича Драгоманова. Це питання постійно стало порушуватися на зборах викладачів і студентів, засіданнях ради інституту і рад філологічного, історичного, педагогічного та інших факультетів й у статтях в періодичній пресі. Усі ці вимоги й акції завершилися перемогою справедливості: в 1993 році інститутові було повернуто ім'я видатного українського вченого-енциклопедиста, борця за вільну українську школу М. П. Драгоманова. ",
						City = citiesList.FirstOrDefault(x => x.Name == "Київ"),
						StudentsCount = 36000,
						Address = "вулиця Пирогова, 9",
						Website = "www.npu.edu.ua",
						Telephone = "044 239 3017",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Хмельницький національний університет",
						Info = "вищий навчальний заклад на Поділлі, який готує спеціалістів із багатьох галузей знань і проводить навчальну, методичну, наукову та виховну роботу. Університет засновано 1962 року. Пройшов шлях від загальнотехнічного факультету Українського поліграфічного інституту до Хмельницького національного університету, який має найвищий IV рівень акредитації. ",
						City = citiesList.FirstOrDefault(x => x.Name == "Хмельницький"),
						StudentsCount = 9759,
						Address = "вулиця Інститутська, 11",
						Website = "khnu.km.ua",
						Telephone = "0382 670 276",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Вінницький національний технічний університет",
						Info = "український заклад вищої освіти четвертого рівня акредитації, який здійснює підготовку фахівців інженерно-технічного профілю. Заклад є центром освіти, науки та культури Подільського регіону. ",
						City = citiesList.FirstOrDefault(x => x.Name == "Вінниця"),
						StudentsCount = 6000,
						Address = "Хмельницьке шосе, 95",
						Website = "vntu.edu.ua",
						Telephone = "0432 560 848",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Житомирський державний університет імені Івана Франка",
						Info = "найстаріший вищий навчальний заклад Житомирщини. Заснований у 1919 році як «Волинський педагогічний інститут».",
						City = citiesList.FirstOrDefault(x => x.Name == "Житомир"),
						StudentsCount = 4456,
						Address = "вулиця Велика Бердичівська, 40",
						Website = "zu.edu.ua",
						Telephone = "0412 431 417",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Харківський політехнічний інститут",
						Info = "Національний технічний університет «Харківський політехнічний інститут», до 1929 Харківський технологічний інститут, з 1975 Харківський ордена Леніна політехнічний інститут імені В. І. Леніна — заснований в 1885 році в Харкові. Другий технологічний інститут в Російській імперії після санкт-петербурзького.",
						City = citiesList.FirstOrDefault(x => x.Name == "Харків"),
						StudentsCount = 12000,
						Address = "вулиця Кирпичова, 2",
						Website = "kpi.kharkov.ua",
						Telephone = "057 707 6634",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Харківський національний медичний університет",
						Info = "Ха́рківський націона́льний меди́чний університе́т, раніше Харківський державний медичний інститут. Вищий навчальний заклад, метою якого є підготовка медичних фахівців та підвищення кваліфікації, формування на базі університету науково-виробничого кластеру.",
						City = citiesList.FirstOrDefault(x => x.Name == "Харків"),
						StudentsCount = 6167,
						Address = "проспект Науки, 4",
						Website = "knmu.edu.ua",
						Telephone = "057 707 7380",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Ужгородський національний університет",
						Info = "Ужгородський національний університет є членом Асоціації університетів Карпатського регіону (ACRU), яка входить до Асоціації європейських університетів (EUA) та є асоційованим членом Міжнародної асоціації університетів (IAU). Виш співпрацює зі 125 партнерами з різних країн, зокрема з такими, як Карлів університет, Технічний університет у м. Прага (Чехія), Університет Корвіна, Університет держави і права ім. Л.Кошута (Угорщина), Кошицький університет ім. П. Й. Шафарика, Університет ім. Я. А. Коменського (Словаччина), Університет м. Орадеа, Клузький університет м. Бабеш-Бояї (Румунія), Інститут германістики Університету м. Ландау, Університет Регенсбургу (Німеччина), Асоціація гомеопатичної медицини м. Рим (Італія), Загребський університет (Хорватія), Словацьким медичним університетом (Братислава) та іншими. У 2020 році укладено 7 нових міжнародних білатеральних угод, 7 угод з реалізації міжнародних проєктів та 8 угод з метою супроводу академічної мобільності Erasmus+.",
						City = citiesList.FirstOrDefault(x => x.Name == "Ужгород"),
						StudentsCount = 14460,
						Address = "вулиця Університетська, 14",
						Website = "uzhnu.edu.ua",
						Telephone = "0312 643 084",
						UniversityAdministrators = new List<UniversityAdministrator>{new UniversityAdministrator{AppUser = users[1]}}
					},
					new University
					{
						Name = "Національний університет «Львівська Політехніка»",
						Info = "найстаріший технічний заклад вищої освіти України та Східної Європи, заснований у 1816 році як Реальна школа з дозволу австрійського імператора Франца І.",
						City = citiesList.FirstOrDefault(x => x.Name == "Львів"),
						StudentsCount = 35000,
						Address = "вул. Степана Бандери, 12",
						Website = "lp.edu.ua",
						Telephone = "0322 582 111"
					},
				};
				await context.Universities.AddRangeAsync(universities);
				foreach (var item in universities)
				{
					var specialties = new List<Specialty>
					{
						new Specialty
						{
							SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "122"),
							Description = "Загальна освіта в галузі інформаційних технологій, спеціалізація «Комп’ютерні науки».Ключові слова: програмування, алгоритмізація, моделювання,комп’ютерна обробка даних, обчислювальні системи та технології,нечіткі моделі, Machine Learning, Big Data Processing, програмування на C#, C++, Python, Java, комп’ютерні мережі, розподілені серверні системи, розподілені та паралельні обчислення, нечіткі моделі та мережі, методи обчислювального інтелекту.",
							EctsCredits = 240,
							Degree = degrees[new Random().Next(0,3)],
							PriceUAH = 80000,
							StartYear = 2020,
							EndYear = 2024,
							University = item,
						},
						new Specialty
						{
							SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "081"),
							Description = "Підготовка нового покоління юристів, здатних здійснювати професійну діяльність у сфері  договірного, сімейного і спадкового права, захищати особисті майнові та немайнові права своїх клієнтів в умовах постійно зростаючої конкуренції на ринку юридичних послуг.",
							EctsCredits = 60,
							Degree = degrees[new Random().Next(0,3)],
							PriceUAH = 40001,
							StartYear = 2020,
							EndYear = 2024,
							University = item,
						},
						new Specialty
						{
							SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "081"),
							Description = "Підготовка нового покоління юристів, здатних здійснювати професійну діяльність у сфері  договірного, сімейного і спадкового права, захищати особисті майнові та немайнові права своїх клієнтів в умовах постійно зростаючої конкуренції на ринку юридичних послуг.",
							EctsCredits = 240,
							Degree = degrees[new Random().Next(0,3)],
							PriceUAH = 100001,
							StartYear = 2020,
							EndYear = 2024,
							University = item,
						},
						new Specialty
						{
							SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "125"),
							Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
							EctsCredits = 180,
							Degree = degrees[new Random().Next(0,3)],
							PriceUAH = 45021,
							StartYear = 2020,
							EndYear = 2024,
							University = item,
						},
						new Specialty
						{
							SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "121"),
							Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
							EctsCredits = 240,
							Degree = degrees[new Random().Next(0,3)],
							PriceUAH = 75021,
							StartYear = 2020,
							EndYear = 2024,
							University = item,
						},
						new Specialty
						{
							SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "123"),
							Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
							EctsCredits = 240,
							Degree = degrees[new Random().Next(0,3)],
							PriceUAH = 85021,
							StartYear = 2020,
							EndYear = 2024,
							University = item,
						},
						new Specialty
						{
							SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "124"),
							Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
							EctsCredits = 240,
							Degree = degrees[new Random().Next(0,3)],
							PriceUAH = 95021,
							StartYear = 2020,
							EndYear = 2024,
							University = item,
						},
						new Specialty
						{
							SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "112"),
							Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
							EctsCredits = 240,
							Degree = degrees[new Random().Next(0,3)],
							PriceUAH = 76021,
							StartYear = 2020,
							EndYear = 2024,
							BudgetAllowed = true,
							University = item,
						},
						new Specialty
						{
							SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "111"),
							Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
							EctsCredits = 240,
							Degree = degrees[new Random().Next(0,3)],
							PriceUAH = 52331,
							StartYear = 2020,
							EndYear = 2024,
							University = item,
						},
						new Specialty
						{
							SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "076"),
							Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
							EctsCredits = 240,
							Degree = degrees[new Random().Next(0,3)],
							PriceUAH = 88754,
							StartYear = 2020,
							EndYear = 2024,
							University = item,
						},
						new Specialty
						{
							SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "073"),
							Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
							EctsCredits = 240,
							Degree = degrees[new Random().Next(0,3)],
							PriceUAH = 87213,
							StartYear = 2020,
							EndYear = 2024,
							University = item,
						},
						new Specialty
						{
							SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "141"),
							Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
							EctsCredits = 240,
							Degree = degrees[new Random().Next(0,3)],
							PriceUAH = 85021,
							StartYear = 2020,
							EndYear = 2024,
							University = item,
						},
						new Specialty
						{
							SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "142"),
							Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
							EctsCredits = 240,
							Degree = degrees[new Random().Next(0,3)],
							PriceUAH = 85021,
							StartYear = 2020,
							EndYear = 2024,
							University = item,
						},
						new Specialty
						{
							SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "143"),
							Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
							EctsCredits = 240,
							Degree = degrees[new Random().Next(0,3)],
							PriceUAH = 85021,
							StartYear = 2020,
							EndYear = 2024,
							University = item,
						},
						new Specialty
						{
							SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "144"),
							Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
							EctsCredits = 240,
							Degree = degrees[new Random().Next(0,3)],
							PriceUAH = 85021,
							StartYear = 2020,
							EndYear = 2024,
							BudgetAllowed = true,
							University = item,
						},
						new Specialty
						{
							SpecialtyBase = specialtyBases.FirstOrDefault(x => x.Id == "145"),
							Description = "Specialty test description specifying main field of study, career perspective, roadmap, study environment, collective.",
							EctsCredits = 240,
							Degree = degrees[new Random().Next(0,3)],
							PriceUAH = 85021,
							StartYear = 2020,
							EndYear = 2024,
							University = item
						},
					};
					var comments = new List<Comment>
					{
						new Comment
						{
							University = item,
							Author = users[0],
							Body = "Test Comment message consisting of author, University, message, 5 start rating",
							Rating=new Random().Next(1, 6),
						},
						new Comment
						{
							University = item,
							Author = users[1],
							Body = "Slightly different test Comment message consisting of author, University, message, 4 star* rating",
							Rating=new Random().Next(1, 6),
						},
						new Comment
						{
							University = item,
							Author = users[2],
							Body = "Another test Comment message consisting of author being user3, University, message, 1 star rating",
							Rating=new Random().Next(1, 6),
						},
						new Comment
						{
							University = item,
							Author = users[2],
							Body = "Another one Comment message consisting of author being user4, University, message, 5 star rating",
							Rating=new Random().Next(1, 6),
						},
						new Comment
						{
							University = item,
							Author = users[1],
							Body = "Test Comment message consisting of author being user5, University, message, 3 start rating",
							Rating=new Random().Next(1, 6),
						},
						new Comment
						{
							University = item,
							Author = users[0],
							Body = "Test Comment message consisting of author, University, message, 5 start rating",
							Rating=new Random().Next(1, 6),
						},
					};
					await context.Comments.AddRangeAsync(comments);
					await context.Specialties.AddRangeAsync(specialties.Skip(new Random().Next(0, 8)).Skip(new Random().Next(0, 8)));

				}
				await context.SaveChangesAsync();
				foreach (var item in context.Specialties)
				{
					var specialtyDisciplinesLaw = new List<SpecialtyDiscipline>
					{
						new SpecialtyDiscipline
						{
							Discipline = disciplines.FirstOrDefault(x => x.Name == "Цивільне право"),
							EctsCredits=12,
							IsOptional=false,
							Specialty=item,
						},
						new SpecialtyDiscipline
						{
							Discipline= disciplines.FirstOrDefault(x => x.Name == "Правові висновки Верховного Cуду"),
							EctsCredits=6,
							IsOptional=false,
							Specialty=item,
						},
						new SpecialtyDiscipline
						{
							Discipline=disciplines.FirstOrDefault(x => x.Name == "Альтернативні способи вирішення суперечок"),
							EctsCredits=6,
							IsOptional=false,
							Specialty=item,
						},
						new SpecialtyDiscipline
						{
							Discipline=disciplines.FirstOrDefault(x => x.Name == "Нотаріальний процес"),
							EctsCredits=6,
							IsOptional=false,
							Specialty=item,
						},
						new SpecialtyDiscipline
						{
							Discipline=disciplines.FirstOrDefault(x => x.Name == "Порівняльне цивільне право і процес"),
							EctsCredits=6,
							IsOptional=false,
							Specialty=item,
						},
						new SpecialtyDiscipline
						{
							Discipline=disciplines.FirstOrDefault(x => x.Name == "Школа прикладної юриспруденції"),
							EctsCredits=18,
							IsOptional=false,
							Specialty=item,
						},
						new SpecialtyDiscipline
						{
							Discipline=disciplines.FirstOrDefault(x => x.Name == "Практична підготовка"),
							EctsCredits=12,
							IsOptional=false,
							Specialty=item,
						},
					};
					var specialtyDisciplineCyber = new List<SpecialtyDiscipline>
					{
						new SpecialtyDiscipline
						{
							Discipline = disciplines.FirstOrDefault(x => x.Name == "Вступ до комп'ютерних наук"),
							EctsCredits=12,
							IsOptional=false,
							Specialty=item,
						},
						new SpecialtyDiscipline
						{
							Discipline= disciplines.FirstOrDefault(x => x.Name == "Дискретна математика"),
							EctsCredits=6,
							IsOptional=false,
							Specialty=item,
						},
						new SpecialtyDiscipline
						{
							Discipline=disciplines.FirstOrDefault(x => x.Name == "Фізика"),
							EctsCredits=6,
							IsOptional=false,
							Specialty=item,
						},
						new SpecialtyDiscipline
						{
							Discipline=disciplines.FirstOrDefault(x => x.Name == "Математичний аналіз"),
							EctsCredits=6,
							IsOptional=false,
							Specialty=item,
						},
						new SpecialtyDiscipline
						{
							Discipline=disciplines.FirstOrDefault(x => x.Name == "Комп'ютерні технології обробки та візуалізації даних"),
							EctsCredits=6,
							IsOptional=false,
							Specialty=item,
						},
						new SpecialtyDiscipline
						{
							Discipline=disciplines.FirstOrDefault(x => x.Name == "Алгоритмізація та програмування"),
							EctsCredits=18,
							IsOptional=false,
							Specialty=item,
						},
						new SpecialtyDiscipline
						{
							Discipline=disciplines.FirstOrDefault(x => x.Name == "Оптимізаційні методи та моделі"),
							EctsCredits=12,
							IsOptional=false,
							Specialty=item,
						},
						new SpecialtyDiscipline
						{
							Discipline=disciplines.FirstOrDefault(x => x.Name == "Філософія"),
							EctsCredits=6,
							IsOptional=true,
							Specialty=item
						},
						new SpecialtyDiscipline
						{
							Discipline=disciplines.FirstOrDefault(x => x.Name == "Адміністрування серверних систем"),
							EctsCredits=6,
							IsOptional=true,
							Specialty=item
						},
						new SpecialtyDiscipline
						{
							Discipline=disciplines.FirstOrDefault(x => x.Name == "Організація баз даних та знань"),
							EctsCredits=6,
							IsOptional=true,
							Specialty=item
						},
						new SpecialtyDiscipline
						{
							Discipline=disciplines.FirstOrDefault(x => x.Name == "Архітектура обчислювальних систем"),
							EctsCredits=6,
							IsOptional=true,
							Specialty=item
						},
						new SpecialtyDiscipline
						{
							Discipline=disciplines.FirstOrDefault(x => x.Name == "Web-технології"),
							EctsCredits=6,
							IsOptional=true,
							Specialty=item
						},
						new SpecialtyDiscipline
						{
							Discipline=disciplines.FirstOrDefault(x => x.Name == "Теорія управління в інформаційних системах"),
							EctsCredits=12,
							IsOptional=false,
							Specialty=item,
						},
						new SpecialtyDiscipline
						{
							Discipline=disciplines.FirstOrDefault(x => x.Name == "Технології аналізу даних"),
							EctsCredits=12,
							IsOptional=false,
							Specialty=item,
						},
						new SpecialtyDiscipline
						{
							Discipline=disciplines.FirstOrDefault(x => x.Name == "Безпека життя"),
							EctsCredits=12,
							IsOptional=false,
							Specialty=item,
						},
					};
					await context.SpecialtyDisciplines.AddRangeAsync(specialtyDisciplineCyber);
					await context.SpecialtyDisciplines.AddRangeAsync(specialtyDisciplinesLaw);
				}
				await context.SaveChangesAsync();
			}
		}
	}
}