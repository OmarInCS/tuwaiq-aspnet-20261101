using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClinicApp.Helpers;
using ClinicApp.Models;

namespace ClinicApp.ViewModels;

public class DoctorCreateVM
{
    [RegularExpression("[a-zA-Z\\s]{3,150}", ErrorMessage = "Name must be 3-150 letters")]
    public string Name { get; set; } = null!;

    [Range(1000, 100_000)]
    public double Salary { get; set; }

    [Display(Name = "Hire Date")]
    [NotFutureDate(ErrorMessage = "Can't be a future date")]
    public DateTime HireDate { get; set; }


    public Doctor ToModel()
    {
        return new Doctor
        {
            Name = Name,
            Salary = Salary,
            HireDate = HireDate
        };
    }
}
