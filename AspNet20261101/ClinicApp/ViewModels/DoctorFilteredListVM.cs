using System;

namespace ClinicApp.ViewModels;

public class DoctorFilteredListVM
{
    public DoctorQueryVM Query { get; set; } = new();

    public List<DoctorReadVM> Doctors { get; set; } = new();
}
