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
	public DbSet<UniversityBranchesOfKnowledge> UniversityBranchesOfKnowledge { get; set; } = null!;
	public DbSet<BranchOfKnowledgeSpecialties> BranchOfKnowledgeSpecialties { get; set; } = null!;
	public DbSet<SpecialtyDisciplines> SpecialtyDisciplines { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.Entity<UniversityBranchesOfKnowledge>(x => x.HasKey(ubok => new { ubok.UniversityId, ubok.BranchOfKnowledgeId }));
		builder.Entity<UniversityBranchesOfKnowledge>()
			.HasOne(u => u.University)
			.WithMany(bok => bok.BranchesOfKnowledge)
			.HasForeignKey(ubok => ubok.UniversityId);
		builder.Entity<UniversityBranchesOfKnowledge>()
			.HasOne(bok => bok.BranchOfKnowledge)
			.WithOne(u => u.University)
			.HasForeignKey<UniversityBranchesOfKnowledge>(ubok => ubok.BranchOfKnowledgeId);

		builder.Entity<BranchOfKnowledgeSpecialties>(x => x.HasKey(bocs => new { bocs.BranchOfKnowledgeId, bocs.SpecialtyId }));
		builder.Entity<BranchOfKnowledgeSpecialties>()
			.HasOne(boc => boc.BranchOfKnowledge)
			.WithMany(s => s.Specialties)
			.HasForeignKey(bocs => bocs.BranchOfKnowledgeId);
		builder.Entity<BranchOfKnowledgeSpecialties>()
			.HasOne(s => s.Specialty)
			.WithOne(boc => boc.BranchOfKnowledge)
			.HasForeignKey<BranchOfKnowledgeSpecialties>(bocs => bocs.SpecialtyId);

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
