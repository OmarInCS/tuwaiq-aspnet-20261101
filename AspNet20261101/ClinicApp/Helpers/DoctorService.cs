using System;

namespace ClinicApp.Helpers;

public class DoctorService
{
    public static int Count { get; set; }

    public DoctorService(OtherService otherService)
    {
        Count++;
        System.Console.WriteLine($"DoctorService {Count}");
    }
}
