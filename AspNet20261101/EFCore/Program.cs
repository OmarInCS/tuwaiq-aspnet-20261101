using EFCore.ClinicModels;
using EFCore.HrModels;
using Microsoft.EntityFrameworkCore.Diagnostics;

Console.WriteLine("Hello, World!");

var hrDB = new HrSqliteContext();

var numOfEmps = hrDB.Employees.Count();
var numOfDepts = hrDB.Departments.Count();

System.Console.WriteLine($"Number of Emps: {numOfEmps}");
System.Console.WriteLine($"Number of Depts: {numOfDepts}");

var clinicDB = new ClinicContext();

var doc = new Doctor
{
    Name = "Wael",
    Salary = 20000,
    HireDate = DateTime.Today
};

var spec = clinicDB.Specialities.Single(s => s.Name == "ENT");
doc.Speciality = spec;

clinicDB.Doctors.Add(doc);
clinicDB.SaveChanges();