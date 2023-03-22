using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class DataContext : IdentityDbContext<AppUser>
{
	public DataContext(DbContextOptions options) : base(options)
	{
	}

	public DbSet<Institution> Institutions { get; set; }
	public DbSet<InstitutionAdmin> InstitutionsAdmins { get; set; }
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
	public DbSet<InstitutionType> InstitutionTypes { get; set; }
	public DbSet<FavoriteList> FavoriteLists { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.Entity<InstitutionAdmin>(b =>
		{
			b.HasKey(x => new { x.AppUserId, x.InstitutionId });
			b.HasOne(x => x.AppUser).WithMany(x => x.InstitutionsAdmin).HasForeignKey(x => x.AppUserId);
			b.HasOne(u => u.Institution).WithMany(x => x.InstitutionAdmins).HasForeignKey(u => u.InstitutionId);
		});
		builder.Entity<FavoriteList>(b =>
		{
			b.HasKey(x => new { x.AppUserId, x.InstitutionId });
			b.HasOne(x => x.AppUser).WithMany(x => x.FavoriteList).HasForeignKey(x => x.AppUserId);
			b.HasOne(x => x.Institution).WithMany(x => x.FavoriteList).HasForeignKey(x => x.InstitutionId);
		});
		builder.Entity<Review>().HasOne(a => a.Institution).WithMany(c => c.Reviews).OnDelete(DeleteBehavior.Cascade);
	}
}
