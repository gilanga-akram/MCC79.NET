using Connection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Views;
public class ViewDepartment
{
    public void GetAll(List<Department> departments)
    {       
        foreach (Department department in departments)
        {
            Console.WriteLine($"Id : {department.Id}, Nama : {department.Name}, Location Id : {department.LocationId}, Manager Id : {department.ManagerId}");
        }
    }
}
