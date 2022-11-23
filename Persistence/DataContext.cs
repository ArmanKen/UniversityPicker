using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class DataContext : DbContext
{
	public DataContext(DbContextOptions options) : base(options)
	{
	}

	public DbSet<Discipline> Disciplines { get; set; } = null!;
	public DbSet<Specialtie> Specialties { get; set; } = null!;
	public DbSet<BranchOfKnowledge> BranchesOfKnowledge { get; set; } = null!;
}
