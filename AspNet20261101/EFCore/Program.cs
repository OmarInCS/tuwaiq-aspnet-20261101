using EFCore.ClinicModels;
using EFCore.HrModels;
using Microsoft.EntityFrameworkCore.Diagnostics;

Console.WriteLine("Hello, World!");

var hrDB = new HrSqliteContext();

var numOfEmps = hrDB.Employees.Count();
var numOfDepts = hrDB.Departments.Count();

System.Console.WriteLine($"Number of Emps: {numOfEmps}");
System.Console.WriteLine($"Number of Depts: {numOfDepts}");

var doc = new Doctor
{
    Name = "Wael",
    Salary = 20000,
    HireDate = DateTime.Now
};

var clinicDB = new ClinicContext();

clinicDB.Doctors.Add(doc);
clinicDB.SaveChanges();

var numOfDocs = clinicDB.Doctors.Count();

System.Console.WriteLine($"Number of Docs: {numOfDocs}");
