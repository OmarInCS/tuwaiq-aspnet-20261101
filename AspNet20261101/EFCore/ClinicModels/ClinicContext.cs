using System;
using Microsoft.EntityFrameworkCore;

namespace EFCore.ClinicModels;

public class ClinicContext : DbContext
{

    public DbSet<Doctor> Doctors { get; set; }

    public DbSet<Speciality> Specialities { get; set; }

    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlite("Data Source=D:\\clinic.db");
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
    }
}
