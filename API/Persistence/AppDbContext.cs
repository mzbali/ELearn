using ELearn.Core.Domain;
using Microsoft.EntityFrameworkCore;
namespace ELearn.Persistence;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasOne(c => c.Author)
                .WithMany(a => a.Courses)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(c => c.Cover)
                .WithOne(c => c.Course)
                .HasForeignKey<Cover>(c => c.CourseId);

            entity.HasMany(c => c.Tags)
                .WithMany(t => t.Courses)
                .UsingEntity(j => j.ToTable("CourseTags"));
        });
    }
}