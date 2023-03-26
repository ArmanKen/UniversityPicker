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
	public DbSet<UniversityAdmin> UniversitiesAdmins { get; set; }
	public DbSet<Specialty> Specialties { get; set; }
	public DbSet<SpecialtyBase> SpecialtyBases { get; set; }
	public DbSet<Region> Regions { get; set; }
	public DbSet<City> Cities { get; set; }
	public DbSet<EduComponent> EduComponents { get; set; }
	public DbSet<Photo> Photos { get; set; }
	public DbSet<Review> Reviews { get; set; }
	public DbSet<Isced> Isceds { get; set; }
	public DbSet<Degree> Degrees { get; set; }
	public DbSet<CurrentStatus> CurrentStatuses { get; set; }
	public DbSet<Faculty> Faculties { get; set; }
	public DbSet<KnowledgeBranch> KnowledgeBranches { get; set; }
	public DbSet<Language> Languages { get; set; }
	public DbSet<Location> Locations { get; set; }
	public DbSet<StudyForm> StudyForms { get; set; }
	public DbSet<FavoriteList> FavoriteLists { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.Entity<UniversityAdmin>(b =>
		{
			b.HasKey(x => new { x.AppUserId, x.UniversityId });
			b.HasOne(x => x.AppUser).WithMany(x => x.UniversitiesAdmin).HasForeignKey(x => x.AppUserId);
			b.HasOne(u => u.University).WithMany(x => x.UniversityAdmins).HasForeignKey(u => u.UniversityId);
		});
		builder.Entity<FavoriteList>(b =>
		{
			b.HasKey(x => new { x.AppUserId, x.UniversityId });
			b.HasOne(x => x.AppUser).WithMany(x => x.FavoriteList).HasForeignKey(x => x.AppUserId);
			b.HasOne(x => x.University).WithMany(x => x.FavoriteList).HasForeignKey(x => x.UniversityId);
		});
		builder.Entity<Review>().HasOne(a => a.University).WithMany(c => c.Reviews).OnDelete(DeleteBehavior.Cascade);
	}
}
