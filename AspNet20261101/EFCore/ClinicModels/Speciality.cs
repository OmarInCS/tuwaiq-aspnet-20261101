using System;

namespace EFCore.ClinicModels;

public class Speciality
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public List<Doctor> Doctors { get; set; } = new();
}
