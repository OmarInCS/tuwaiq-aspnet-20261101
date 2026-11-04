using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Models;

public class Doctor
{
    public int Id { get; set; }

    [MaxLength(150)]
    [RegularExpression("[a-zA-Z]{3,}", ErrorMessage = "Name must be 3 letters or more")]
    public string Name { get; set; } = null!;

    // [Precision(8, 2)] 
    [Range(1000, 100_000)]
    public double Salary { get; set; }

    [Display(Name = "Hire Date")]
    public DateTime HireDate { get; set; }

    public int? SpecialityCode { get; set; }

    [ForeignKey(nameof(SpecialityCode))]
    public Speciality? Speciality { get; set; }

    public List<Appointment> Appointments { get; set; } = new();
}
