using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection.Models;

namespace Connection.Views;
public class ViewEmployee
{
    public void GetAll(List<Employee> employees)
    {
        foreach (Employee employee in employees)
        {
            Console.WriteLine($"Id : {employee.Id}, First Name : {employee.FirstName}, Last Name : {employee.LastName}, Email : {employee.Email}, Phone Number : {employee.PhoneNumber}, Hire Date : {employee.HireDate}, Salary : {employee.Salary}, Commision : {employee.Commision}, Manager Id : {employee.ManagerId}, Job Id : {employee.JobId}, Department Id : {employee.DepartmentId}");
        }
    }
}
