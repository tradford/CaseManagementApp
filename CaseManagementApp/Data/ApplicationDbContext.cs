using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CaseManagementApp.Models;

namespace CaseManagementApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
      

        public DbSet<Client> Clients { get; set; }
        public DbSet<BrownsteinCase> BrownsteinCases { get; set; }

        public DbSet<Attorney> Attorneys { get; set; }

        public DbSet<CaseNote> CaseNotes { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BrownsteinCase>()
                .HasOne(bc => bc.Client)
                .WithMany(c => c.BrownsteinCases)
                .HasForeignKey(bc => bc.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BrownsteinCase>()
             .HasOne(c => c.Attorney)
             .WithMany()
             .HasForeignKey(c => c.AttorneyId);

            modelBuilder.Entity<CaseNote>()
                .HasOne(cn => cn.BrownsteinCase)
                .WithMany(bc => bc.CaseNotes)
                .HasForeignKey(cn => cn.BrownsteinCaseId)
                .OnDelete(DeleteBehavior.Cascade); // ✅ Keep cascade from Case → Notes

            modelBuilder.Entity<CaseNote>()
                .HasOne(cn => cn.Attorney)
                .WithMany()
                .HasForeignKey(cn => cn.AttorneyId)
                .OnDelete(DeleteBehavior.Restrict); // 🚫 Prevent cascade from Attorney → Notes
        }
    }
}
