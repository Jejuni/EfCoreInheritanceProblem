using Microsoft.EntityFrameworkCore;

namespace EfCoreInheritanceProblem;

public class MyDbContext : DbContext
{
    public DbSet<Parent> Parents => Set<Parent>();
    public DbSet<ChildOne> ChildOnes => Set<ChildOne>();
    public DbSet<ChildTwo> ChildTwos => Set<ChildTwo>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=localhost,5433;Initial Catalog=EfCoreInheritanceProblem;User Id=sa;Password=Pass@word;TrustServerCertificate=true");

        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Parent>(b =>
        {
            b.HasDiscriminator<string>("Discriminator")
                .HasValue<ChildOne>("one")
                .HasValue<ChildTwo>("two");
        });

        modelBuilder.Entity<ChildTwo>(b =>
        {
            b.OwnsOne(x => x.Name, nameBuilder =>
            {
                nameBuilder.Property(x => x.FirstName);
                nameBuilder.Property(x => x.LastName);
            });
        });
    }
}