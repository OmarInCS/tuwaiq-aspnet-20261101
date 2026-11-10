using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClinicApp.Helpers;
using ClinicApp.Models;

namespace ClinicApp.ViewModels;

public class DoctorUpdateVM
{
    [RegularExpression("[a-zA-Z\\s]{3,150}", ErrorMessage = "Name must be 3-150 letters")]
    public string Name { get; set; } = null!;

    [Range(1000, 100_000)]
    public double Salary { get; set; }

    [Display(Name = "Hire Date")]
    [NotFutureDate(ErrorMessage = "Can't be a future date")]
    public DateTime HireDate { get; set; }

    [Display(Name = "Speciality")]
    public int? SpecialityId { get; set; }

    public List<SpecialityReadVM> AllSpecialities { get; set; } = new();


    public void ToModel(Doctor doc)
    {
        doc.Name = Name;
        doc.Salary = Salary;
        doc.HireDate = HireDate;
        doc.SpecialityCode = SpecialityId;
    }
}
