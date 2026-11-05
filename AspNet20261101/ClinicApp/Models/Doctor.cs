using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClinicApp.ViewModels;
// using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Models;

public class Doctor
{
    public int Id { get; set; }

    [MaxLength(150)]
    public string Name { get; set; } = null!;

    // [Precision(8, 2)] 
    public double Salary { get; set; }

    public DateTime HireDate { get; set; }

    public int? SpecialityCode { get; set; }

    [ForeignKey(nameof(SpecialityCode))]
    public Speciality? Speciality { get; set; }

    public List<Appointment> Appointments { get; set; } = new();


    public DoctorReadVM ToReadVM()
    {
        return new DoctorReadVM
        {
            Id = Id,
            Name = Name,
            Salary = Salary,
            HireDate = HireDate
        };
    }

    public DoctorUpdateVM ToUpdateVM()
    {
        return new DoctorUpdateVM
        {
            Name = Name,
            Salary = Salary,
            HireDate = HireDate
        };
    }
}
