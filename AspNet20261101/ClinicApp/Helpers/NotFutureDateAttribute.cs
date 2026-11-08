using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApp.Helpers;

public class NotFutureDateAttribute : ValidationAttribute
{

    public override bool IsValid(object? value)
    {
        if (value == null || value is not DateTime)
        {
            return false;
        }

        var dateValue = (DateTime) value;

        if (dateValue > DateTime.Today)
        {
            return false;
        }

        return true;
    }

}
