using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class DataContext : IdentityDbContext<AppUser>
{
	public DataContext(DbContextOptions options) : base(options)
	{
	}

	public DbSet<HigherEducationFacility> HigherEducationFacilities { get; set; }
	public DbSet<HigherEducationFacilityAdmin> HigherEducationFacilitiesAdmins { get; set; }
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
	public DbSet<Accreditation> Accreditations { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.Entity<HigherEducationFacilityAdmin>(b =>
		{
			b.HasKey(x => new { x.AppUserId, x.HigherEducationFacilityId });
			b.HasOne(x => x.AppUser).WithMany(x => x.HigherEducationFacilitiesAdmin).HasForeignKey(x => x.AppUserId);
			b.HasOne(u => u.HigherEducationFacility).WithMany(x => x.HigherEducationFacilityAdmins).HasForeignKey(u => u.HigherEducationFacilityId);
		});
		builder.Entity<FavoriteList>(b =>
		{
			b.HasKey(x => new { x.AppUserId, x.HigherEducationFacilityId });
			b.HasOne(x => x.AppUser).WithMany(x => x.FavoriteList).HasForeignKey(x => x.AppUserId);
			b.HasOne(x => x.HigherEducationFacility).WithMany(x => x.FavoriteList).HasForeignKey(x => x.HigherEducationFacilityId);
		});
		builder.Entity<Review>().HasOne(a => a.HigherEducationFacility).WithMany(c => c.Reviews).OnDelete(DeleteBehavior.Cascade);
	}
}
