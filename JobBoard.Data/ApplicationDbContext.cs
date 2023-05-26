using JobBoard.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<ApplicationEntity> JobApps { get; set; }
        public DbSet<JobEntity> Jobs { get; set; }
        public DbSet<ApplicationEntity> Applications { get; set; }
        public DbSet<ResponseEntity> Responses { get; set; }
        public DbSet<ApplicationUser> Users
        { get; set; }
        public DbSet<ApplicationRole> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<ApplicationEntity>().HasOne(a => a.Job).WithMany(j => j.JobApps).HasForeignKey(a => a.JobId).OnDelete(DeleteBehavior.Restrict); modelBuilder.Entity<ApplicationEntity>().HasOne(a => a.Applicant).WithMany().HasForeignKey(a => a.ApplicantFKey).OnDelete(DeleteBehavior.Restrict); // or Dele
        }
    }
}
