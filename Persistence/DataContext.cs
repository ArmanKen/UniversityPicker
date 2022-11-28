using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class DataContext : DbContext
{
	public DataContext(DbContextOptions options) : base(options)
	{
	}

	public DbSet<University> Universities { get; set; } = null!;
	public DbSet<BranchOfKnowledge> BranchesOfKnowledge { get; set; } = null!;
	public DbSet<Specialty> Specialties { get; set; } = null!;
	public DbSet<Discipline> Disciplines { get; set; } = null!;
	public DbSet<UniversitySpecialties> UniversitieSpecialties { get; set; } = null!;
	public DbSet<BranchOfKnowledgeSpecialties> BranchOfKnowledgeSpecialties { get; set; } = null!;
	public DbSet<SpecialtieDisciplines> SpecialtieDisciplines { get; set; } = null!;

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

		builder.Entity<BranchOfKnowledgeSpecialties>(x => x.HasKey(bocs => new { bocs.BranchOfKnowledgeId, bocs.SpecialtyId }));
		builder.Entity<BranchOfKnowledgeSpecialties>()
			.HasOne(boc => boc.BranchOfKnowledge)
			.WithMany(s => s.Specialties)
			.HasForeignKey(bocs => bocs.BranchOfKnowledgeId);
		builder.Entity<BranchOfKnowledgeSpecialties>()
			.HasOne(s => s.Specialty)
			.WithOne(boc => boc.BranchOfKnowledge)
			.HasForeignKey<BranchOfKnowledgeSpecialties>(bocs => bocs.SpecialtyId);

		builder.Entity<SpecialtieDisciplines>(x => x.HasKey(sd => new { sd.SpecialtyId, sd.DisciplineId }));
		builder.Entity<SpecialtieDisciplines>()
			.HasOne(s => s.Specialty)
			.WithMany(d => d.Disciplines)
			.HasForeignKey(sd => sd.SpecialtyId);
		builder.Entity<SpecialtieDisciplines>()
			.HasOne(d => d.Discipline)
			.WithMany(s => s.Specialties)
			.HasForeignKey(sd => sd.DisciplineId);
	}
}
