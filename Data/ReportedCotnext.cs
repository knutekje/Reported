using Microsoft.EntityFrameworkCore;
using Reported.Model.Report;

public class ReportedContext : DbContext
 {
    public ReportedContext(DbContextOptions<ReportedContext> options)
        : base(options){}
    public DbSet<Report> Reports { get; set; } 
    public DbSet<VerifiedReport> VerifiedReports { get; set; }
    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Report>().ToTable("Reports");
        modelBuilder.Entity<VerifiedReport>().ToTable("VerifiedReports");
        modelBuilder.Entity<Item>().ToTable("Items");

        modelBuilder.Entity<VerifiedReport> ()
            .HasOne(vr => vr.Item)
            .WithOne(i => i.VerifiedReport)
            .HasForeignKey<VerifiedReport>(vr => vr.ItemId);


        base.OnModelCreating(modelBuilder);
    }

 }



