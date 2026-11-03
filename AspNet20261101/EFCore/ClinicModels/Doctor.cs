using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCore.ClinicModels;

public class Doctor
{
    public int Id { get; set; }

    [MaxLength(150)]
    public string Name { get; set; } = null!;

    [Precision(8, 2)] 
    public double Salary { get; set; }

    public DateTime HireDate { get; set; }

    public int? SpecialityCode { get; set; }

    [ForeignKey(nameof(SpecialityCode))]
    public Speciality? Speciality { get; set; }

    public List<Appointment> Appointments { get; set; } = new();
}
