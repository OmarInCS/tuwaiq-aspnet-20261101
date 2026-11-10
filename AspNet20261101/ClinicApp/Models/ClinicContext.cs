using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Models;

public class ClinicContext : IdentityDbContext
{

    public DbSet<Doctor> Doctors { get; set; }

    public DbSet<Speciality> Specialities { get; set; }

    public DbSet<Appointment> Appointments { get; set; }

    public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
    {
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>()
                    .Property(d => d.HireDate)
                    .HasDefaultValueSql("date('now', 'localtime')");

        modelBuilder.Entity<Doctor>()
                    .HasOne(d => d.Speciality)
                    .WithMany(s => s.Doctors)
                    .HasForeignKey(d => d.SpecialityCode)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Speciality>()
                    .HasData([
                        new Speciality { Id = 1, Name = "ENT"},
                        new Speciality { Id = 2, Name = "Surgery"},
                        new Speciality { Id = 3, Name = "Pediatric"},
                    ]);

        // modelBuilder.Entity<Doctor>()
        //             .HasMany(d => d.Appointments)
        //             .WithOne(a => a.Doctor)
        //             .HasForeignKey(a => a.DoctorId);

        modelBuilder.Entity<IdentityUser>().ToTable("Users");
        modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
    }
}
