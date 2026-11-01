using EFCore.HrModels;
using Microsoft.EntityFrameworkCore.Diagnostics;

Console.WriteLine("Hello, World!");

var hrDB = new HrSqliteContext();

var numOfEmps = hrDB.Employees.Count();
var numOfDepts = hrDB.Departments.Count();

System.Console.WriteLine($"Number of Emps: {numOfEmps}");
System.Console.WriteLine($"Number of Depts: {numOfDepts}");
