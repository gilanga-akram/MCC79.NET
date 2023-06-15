using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{

    public class Linq
    {
        Jobs jobs = new Jobs();
        Employees employees = new Employees(); // Populate with employee data
        Departments departments = new Departments(); // Populate with department data
        Locations locations = new Locations(); // Populate with location data
        Countries countries = new Countries(); // Populate with country data
        Regions regions = new Regions(); // Populate with region data
        public void GetDepartments()
        {
            var employee = (from e in employees.GettAllEmp()
                             join d in departments.GettAllDep() on e.department_id equals d.id
                             group e by new { d.name, e.department_id }
                into g
                             where g.Count() > 3
                             select new
                             {
                                 DepartmentName = g.Key.name,
                                 TotalEmployee = g.Count(),
                                 MinSalary = g.Min(e => e.salary),
                                 MaxSalary = g.Max(e => e.salary),
                                 AverageSalary = g.Average(e => e.salary)
                             }).ToList();

            foreach (var emp in employee)
            {
                Console.WriteLine($"Department Name: {emp.DepartmentName}");
                Console.WriteLine($"Total Employee: {emp.TotalEmployee}");
                Console.WriteLine($"Min Salary: {emp.MinSalary}");
                Console.WriteLine($"Max Salary: {emp.MaxSalary}");
                Console.WriteLine($"Average Salary: {emp.AverageSalary}");
                Console.WriteLine();
            }
        }
        public void Menulinq()
            {
                

                var soal1 = (from e in employees.GettAllEmp()
                             join j in jobs.GettAllJob() on e.job_id equals j.id
                             join d in departments.GettAllDep() on e.department_id equals d.id
                             join l in locations.GettAllLoc() on d.location_id equals l.id
                             join c in countries.GetAllCountries() on l.co_id equals c.Id
                             join r in regions.GetAllRegions() on c.RegionId equals r.Id
                             select new UserSoal1
                             {
                                 Id = e.id,
                                 FullName = e.first_name + " " + e.last_name,
                                 Email = e.email,
                                 PhoneNumber = e.phone_number,
                                 Salary = (int)e.salary,
                                 DepartmentName = d.name,
                                 Location = l.street,
                                 CountryName = c.Name,
                                 RegionName = r.Name
                             }).Take(5).ToList();

                foreach (var user in soal1)
                {
                    Console.WriteLine($"ID: {user.Id}");
                    Console.WriteLine($"FullName: {user.FullName}");
                    Console.WriteLine($"Email: {user.Email}");
                    Console.WriteLine($"PhoneNumber: {user.PhoneNumber}");
                    Console.WriteLine($"Salary: {user.Salary}");
                    Console.WriteLine($"DepartmentName: {user.DepartmentName}");
                    Console.WriteLine($"Location: {user.Location}");
                    Console.WriteLine($"CountryName: {user.CountryName}");
                    Console.WriteLine($"RegionName: {user.RegionName}");
                    Console.WriteLine();
                }
            
        }


    }
    public class UserSoal1
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Salary { get; set; }
        public string DepartmentName { get; set; }
        public string Location { get; set; }
        public string CountryName { get; set; }
        public string RegionName { get; set; }
    }
}
