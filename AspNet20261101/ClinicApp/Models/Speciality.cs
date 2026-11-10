using System;
using ClinicApp.ViewModels;

namespace ClinicApp.Models;

public class Speciality
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public List<Doctor> Doctors { get; set; } = new();

    public SpecialityReadVM ToReadVM()
    {
        return new SpecialityReadVM
        {
            Id = Id,
            Name = Name
        };
    }
}
