using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApp.ViewModels;

public class DoctorQueryVM
{
    public string? Name { get; set; }

    public int? Id { get; set; }

    [Display(Name = "Hire Date Start")]
    public DateTime? HireDateStart { get; set; }

    [Display(Name = "Hire Date End")]
    public DateTime? HireDateEnd { get; set; }
}
