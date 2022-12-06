using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class DataContext : DbContext
{
	public DataContext(DbContextOptions options) : base(options)
	{
	}

	public DbSet<University> Universities { get; set; } = null!;
	public DbSet<Specialty> Specialties { get; set; } = null!;
	public DbSet<Discipline> Disciplines { get; set; } = null!;
	public DbSet<UniversitySpecialties> UniversitySpecialties { get; set; } = null!;
	public DbSet<SpecialtyDisciplines> SpecialtyDisciplines { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.Entity<UniversitySpecialties>(x => x.HasKey(us => new { us.UniversityId, us.SpecialtyId }));
		builder.Entity<UniversitySpecialties>()
			.HasOne(u => u.University)
			.WithMany(s => s.Specialties)
			.HasForeignKey(us => us.UniversityId);
		builder.Entity<UniversitySpecialties>()
			.HasOne(s => s.Specialty)
			.WithOne(u => u.University)
			.HasForeignKey<UniversitySpecialties>(us => us.SpecialtyId);

		builder.Entity<SpecialtyDisciplines>(x => x.HasKey(sd => new { sd.SpecialtyId, sd.DisciplineId }));
		builder.Entity<SpecialtyDisciplines>()
			.HasOne(s => s.Specialty)
			.WithMany(d => d.Disciplines)
			.HasForeignKey(sd => sd.SpecialtyId);
		builder.Entity<SpecialtyDisciplines>()
			.HasOne(d => d.Discipline)
			.WithMany(s => s.Specialties)
			.HasForeignKey(sd => sd.DisciplineId);
	}
}
