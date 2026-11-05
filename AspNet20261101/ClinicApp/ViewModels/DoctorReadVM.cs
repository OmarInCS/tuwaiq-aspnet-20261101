using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// using Microsoft.EntityFrameworkCore;

namespace ClinicApp.ViewModels;

public class DoctorReadVM
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Salary { get; set; }

    public DateTime HireDate { get; set; }

    public int YearsInService => (int) ((DateTime.Now - HireDate).TotalDays / 365);

    public string FormattedHireDate => HireDate.ToString("dd-MMM-yyyy");

}
