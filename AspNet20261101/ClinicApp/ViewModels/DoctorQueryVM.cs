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


    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 3;

    public int TotalRows { get; set; }

    public int TotalPages => (int) Math.Ceiling((double) TotalRows / PageSize);

    public int PreviousRows => (Page - 1) * PageSize;

    public int PreviousPage => Math.Max(1, Page - 1);

    public int NexPage => Math.Min(TotalPages, Page + 1);
}
