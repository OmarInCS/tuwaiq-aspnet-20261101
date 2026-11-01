using System;
using Microsoft.EntityFrameworkCore;

namespace EFCore.ClinicModels;

public class ClinicContext : DbContext
{

    public DbSet<Doctor> Doctors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlite("Data Source=D:\\clinic.db");
    }
}
