using System;

namespace EFCore.ClinicModels;

public class Appointment
{
    public int Id { get; set; }

    public int DoctorId { get; set; }

    public DateTime AllocationDate { get; set; }

    public string PatientName { get; set; } = null!;

    public Doctor Doctor { get; set; } = null!;
}
