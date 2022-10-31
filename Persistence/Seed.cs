using Domain;

namespace Persistence
{
	public class Seed
	{
		public static async Task SeedData(DataContext context)
		{
			if (context.Disciplines.Any()) return;
			var disciplines = new List<Disciplines>
			{
				new Disciplines
				{
					Name = "Інженерія програмного забезпечення"
				},
				new Disciplines
				{
					Name = "Філософія"
				},
				new Disciplines
				{
					Name = "Правознавство"
				},
				new Disciplines
				{
					Name = "Операційні системи"
				}
			};
			await context.Disciplines.AddRangeAsync(disciplines);
			await context.SaveChangesAsync();
		}
	}
}