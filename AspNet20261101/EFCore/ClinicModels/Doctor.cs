using System;

namespace EFCore.ClinicModels;

public class Doctor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Salary { get; set; }

    public DateTime HireDate { get; set; }
}
