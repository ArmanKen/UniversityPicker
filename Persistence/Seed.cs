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
			await context.Disciplines.AddRangeAsync(disciplines);
			await context.SaveChangesAsync();
		}
	}
}