using Connection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Views;
public class ViewJobs
{
    public void GetAll(List<Jobs> jobs)
    {       
        foreach (Jobs job in jobs)
        {
            Console.WriteLine($"Id : {job.Id}, Title : {job.Title}, Max Salary : {job.MaxSalary}, Min Salary : {job.MinSalary}");
        }
    }   
}
