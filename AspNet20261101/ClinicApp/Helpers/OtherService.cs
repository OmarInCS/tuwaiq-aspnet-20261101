using System;

namespace ClinicApp.Helpers;

public class OtherService
{
    public static int Count { get; set; }

    public OtherService()
    {
        Count++;
        System.Console.WriteLine($"OtherService {Count}");
    }
}
