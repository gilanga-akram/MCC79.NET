using Connection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Views;
public class ViewHistories
{
    public void GetAll(List<Histories> histories)
    {       
        foreach (Histories historie in histories)
        {
            Console.WriteLine($"Mulai Date : {historie.MulaiDate}, Employee Id : {historie.EmployeeId}, End Date  : {(historie.EndDate.HasValue ? historie.EndDate.Value.ToString() : "NULL")}, Department Id : {historie.DepartmentId}, Job Id : {historie.JobId}");
        }
    }
}
