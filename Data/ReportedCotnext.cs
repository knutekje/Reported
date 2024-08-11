using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Reported.Model.Report;

namespace Reported.Data;
public class ReportedContext : IdentityDbContext<IdentityUser>
 {
     public ReportedContext(DbContextOptions<ReportedContext> options) :
        base(options)
    { }


    public DbSet<Report> Reports { get; set; } 
    public DbSet<VerifiedReport> VerifiedReports { get; set; }
    public DbSet<Item> Items { get; set; }
   


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
     

        modelBuilder.Entity<VerifiedReport> ()
            .HasOne(vr => vr.Item)
            .WithOne(i => i.VerifiedReport)
            .HasForeignKey<VerifiedReport>(vr => vr.ItemId);


        base.OnModelCreating(modelBuilder);
    }

 }



