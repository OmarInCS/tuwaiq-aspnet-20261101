using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCore.HrModels;

public partial class HrSqliteContext : DbContext
{
    public HrSqliteContext()
    {
    }

    public HrSqliteContext(DbContextOptions<HrSqliteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Dependent> Dependents { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=D:\\hr_sqlite.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("countries");

            entity.Property(e => e.CountryId)
                .HasColumnType("CHAR (2)")
                .HasColumnName("country_id");
            entity.Property(e => e.CountryName)
                .HasDefaultValueSql("NULL")
                .HasColumnType("VARCHAR (40)")
                .HasColumnName("country_name");
            entity.Property(e => e.RegionId)
                .HasColumnType("INT")
                .HasColumnName("region_id");

            entity.HasOne(d => d.Region).WithMany(p => p.Countries).HasForeignKey(d => d.RegionId);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("departments");

            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.DepartmentName)
                .HasColumnType("VARCHAR (30)")
                .HasColumnName("department_name");
            entity.Property(e => e.LocationId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("location_id");
            entity.Property(e => e.ManagerId)
                .HasColumnType("INT")
                .HasColumnName("manager_id");

            entity.HasOne(d => d.Location).WithMany(p => p.Departments)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Manager).WithMany(p => p.Departments).HasForeignKey(d => d.ManagerId);
        });

        modelBuilder.Entity<Dependent>(entity =>
        {
            entity.ToTable("dependents");

            entity.Property(e => e.DependentId).HasColumnName("dependent_id");
            entity.Property(e => e.EmployeeId)
                .HasColumnType("INT")
                .HasColumnName("employee_id");
            entity.Property(e => e.FirstName)
                .HasColumnType("VARCHAR (50)")
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasColumnType("VARCHAR (50)")
                .HasColumnName("last_name");
            entity.Property(e => e.Relationship)
                .HasColumnType("VARCHAR (25)")
                .HasColumnName("relationship");

            entity.HasOne(d => d.Employee).WithMany(p => p.Dependents).HasForeignKey(d => d.EmployeeId);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("employees");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.CommissionPct)
                .HasColumnType("DECIMAL(2,2)")
                .HasColumnName("commission_pct");
            entity.Property(e => e.DepartmentId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("department_id");
            entity.Property(e => e.Email)
                .HasColumnType("VARCHAR (100)")
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasDefaultValueSql("NULL")
                .HasColumnType("VARCHAR (20)")
                .HasColumnName("first_name");
            entity.Property(e => e.HireDate)
                .HasColumnType("DATE")
                .HasColumnName("hire_date");
            entity.Property(e => e.JobId)
                .HasColumnType("VARCHAR (10)")
                .HasColumnName("job_id");
            entity.Property(e => e.LastName)
                .HasColumnType("VARCHAR (25)")
                .HasColumnName("last_name");
            entity.Property(e => e.ManagerId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("manager_id");
            entity.Property(e => e.PhoneNumber)
                .HasDefaultValueSql("NULL")
                .HasColumnType("VARCHAR (20)")
                .HasColumnName("phone_number");
            entity.Property(e => e.Salary)
                .HasColumnType("DECIMAL (8, 2)")
                .HasColumnName("salary");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Job).WithMany(p => p.Employees).HasForeignKey(d => d.JobId);

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager).HasForeignKey(d => d.ManagerId);
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.ToTable("jobs");

            entity.Property(e => e.JobId)
                .HasColumnType("VARCHAR (10)")
                .HasColumnName("job_id");
            entity.Property(e => e.JobTitle)
                .HasColumnType("VARCHAR (35)")
                .HasColumnName("job_title");
            entity.Property(e => e.MaxSalary)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DECIMAL (8, 2)")
                .HasColumnName("max_salary");
            entity.Property(e => e.MinSalary)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DECIMAL (8, 2)")
                .HasColumnName("min_salary");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("locations");

            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.City)
                .HasColumnType("VARCHAR (30)")
                .HasColumnName("city");
            entity.Property(e => e.CountryId)
                .HasColumnType("CHAR (2)")
                .HasColumnName("country_id");
            entity.Property(e => e.PostalCode)
                .HasDefaultValueSql("NULL")
                .HasColumnType("VARCHAR (12)")
                .HasColumnName("postal_code");
            entity.Property(e => e.StateProvince)
                .HasDefaultValueSql("NULL")
                .HasColumnType("VARCHAR (25)")
                .HasColumnName("state_province");
            entity.Property(e => e.StreetAddress)
                .HasDefaultValueSql("NULL")
                .HasColumnType("VARCHAR (40)")
                .HasColumnName("street_address");

            entity.HasOne(d => d.Country).WithMany(p => p.Locations).HasForeignKey(d => d.CountryId);
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.ToTable("regions");

            entity.Property(e => e.RegionId).HasColumnName("region_id");
            entity.Property(e => e.RegionName)
                .HasDefaultValueSql("NULL")
                .HasColumnType("VARCHAR (25)")
                .HasColumnName("region_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
