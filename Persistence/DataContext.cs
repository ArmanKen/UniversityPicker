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
	public DbSet<JunBachelorSpecialty> JunBachelorSpecialties { get; set; }
	public DbSet<BachelorSpecilaty> BachelorSpecilaties { get; set; }
	public DbSet<MagisterSpecialty> MagisterSpecialties { get; set; }
	public DbSet<Specialty> Specialties { get; set; }
	public DbSet<SpecialtyBase> SpecialtyBases { get; set; }
	public DbSet<SpecialtyDiscipline> SpecialtyDisciplines { get; set; }
	public DbSet<Region> Region { get; set; }
	public DbSet<City> City { get; set; }
	public DbSet<Discipline> Discipline { get; set; }
	public DbSet<Photo> Photo { get; set; }
	public DbSet<Comment> Comment { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.Entity<JunBachelorSpecialty>(k => k.HasKey(x => new { x.SpecialtyId, x.UniversityId }));
		builder.Entity<JunBachelorSpecialty>().HasOne(x => x.Specilaty).WithOne(x => x.JunBachelor);
		builder.Entity<JunBachelorSpecialty>().HasOne(x => x.University).WithMany(x => x.JunBachelorSpecialties).HasForeignKey(x => x.UniversityId);

		builder.Entity<BachelorSpecilaty>(k => k.HasKey(x => new { x.SpecialtyId, x.UniversityId }));
		builder.Entity<BachelorSpecilaty>().HasOne(x => x.Specilaty).WithOne(x => x.Bachelor);
		builder.Entity<BachelorSpecilaty>().HasOne(x => x.University).WithMany(x => x.BachelorSpecialties).HasForeignKey(x => x.UniversityId);

		builder.Entity<MagisterSpecialty>(k => k.HasKey(x => new { x.SpecialtyId, x.UniversityId }));
		builder.Entity<MagisterSpecialty>().HasOne(x => x.Specilaty).WithOne(x => x.Magister);
		builder.Entity<MagisterSpecialty>().HasOne(x => x.University).WithMany(x => x.MagisterSpecialties).HasForeignKey(x => x.UniversityId);

		builder.Entity<UniversityAdministrator>(k => k.HasKey(x => new { x.AppUserId, x.UniversityId }));
		builder.Entity<UniversityAdministrator>().HasOne(x => x.AppUser).WithMany(x => x.UniversityAdministration).HasForeignKey(x => x.AppUserId);
		builder.Entity<UniversityAdministrator>().HasOne(u => u.University).WithMany(x => x.UniversityAdministrators).HasForeignKey(u => u.UniversityId);

		builder.Entity<SpecialtyDiscipline>(k => k.HasKey(x => new { x.SpecialtyId, x.DisciplineId }));
		builder.Entity<SpecialtyDiscipline>().HasOne(x => x.Discipline).WithMany(x => x.Specialties).HasForeignKey(x => x.DisciplineId);
		builder.Entity<SpecialtyDiscipline>().HasOne(u => u.Specialty).WithMany(x => x.Disciplines).HasForeignKey(u => u.SpecialtyId);

		builder.Entity<Comment>().HasOne(a => a.University).WithMany(c => c.Comments).OnDelete(DeleteBehavior.Cascade);

		builder.Entity<SelectedUniversity>(b =>
			{
				b.HasKey(k => new { k.AppUserId, k.UniversityId });
				b.HasOne(o => o.AppUser).WithMany(f => f.SelectedUniversities).HasForeignKey(o => o.AppUserId).OnDelete(DeleteBehavior.Cascade);
				b.HasOne(o => o.University).WithMany(f => f.AppUserSelected).HasForeignKey(o => o.UniversityId).OnDelete(DeleteBehavior.Cascade);
			});
	}
}
