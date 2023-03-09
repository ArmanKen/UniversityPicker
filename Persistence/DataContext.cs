using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class DataContext : IdentityDbContext<AppUser>
{
	public DataContext(DbContextOptions options) : base(options)
	{
	}

	public DbSet<University> Universities { get; set; }
	public DbSet<UniversityAdministrator> UniversityAdministrators { get; set; }
	public DbSet<SelectedUniversity> SelectedUniversities { get; set; }
	public DbSet<Specialty> Specialties { get; set; }
	public DbSet<SpecialtyBase> SpecialtyBases { get; set; }
	public DbSet<SpecialtyDiscipline> SpecialtyDisciplines { get; set; }
	public DbSet<Region> Regions { get; set; }
	public DbSet<City> Cities { get; set; }
	public DbSet<Discipline> Disciplines { get; set; }
	public DbSet<Photo> Photos { get; set; }
	public DbSet<Comment> Comments { get; set; }
	public DbSet<Isced> Isceds { get; set; }
	public DbSet<Degree> Degrees { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.Entity<UniversityAdministrator>(b =>
		{
			b.HasKey(x => new { x.AppUserId, x.UniversityId });
			b.HasOne(x => x.AppUser).WithMany(x => x.UniversityAdministration).HasForeignKey(x => x.AppUserId);
			b.HasOne(u => u.University).WithMany(x => x.UniversityAdministrators).HasForeignKey(u => u.UniversityId);
		});
		builder.Entity<SpecialtyDiscipline>(b =>
		{
			b.HasKey(x => new { x.SpecialtyId, x.DisciplineId });
			b.HasOne(x => x.Discipline).WithMany(x => x.Specialties).HasForeignKey(x => x.DisciplineId);
			b.HasOne(u => u.Specialty).WithMany(x => x.Disciplines).HasForeignKey(u => u.SpecialtyId);
		});
		builder.Entity<SelectedUniversity>(b =>
		{
			b.HasKey(k => new { k.AppUserId, k.UniversityId });
			b.HasOne(o => o.AppUser).WithMany(f => f.SelectedUniversities).HasForeignKey(o => o.AppUserId).OnDelete(DeleteBehavior.Cascade);
			b.HasOne(o => o.University).WithMany(f => f.AppUserSelected).HasForeignKey(o => o.UniversityId).OnDelete(DeleteBehavior.Cascade);
		});
		builder.Entity<Comment>().HasOne(a => a.University).WithMany(c => c.Comments).OnDelete(DeleteBehavior.Cascade);
	}
}
