using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class DataContext : DbContext
{
	public DataContext(DbContextOptions options) : base(options)
	{
	}

	public DbSet<Disciplines> Disciplines { get; set; } = null!;
	public DbSet<Specialties> Specialties { get; set; } = null!;
	public DbSet<BranchesOfKnowledges> BranchesOfKnowledges { get; set; } = null!;
}
