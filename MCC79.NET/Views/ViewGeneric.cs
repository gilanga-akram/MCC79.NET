using Connection.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Views;
public class ViewGeneric
{
    public void DataNotFound()
    {
        Console.WriteLine("Data Not Found");
    }
    public void Menu()
    {
        Console.Clear();
        new Koneksi().TesConnection();
        Console.WriteLine("============Wellcome To Database db_hr==========");
        Console.WriteLine("================================================");
        Console.WriteLine("                   PILIH MENU                   ");
        Console.WriteLine("1.  Regions");
        Console.WriteLine("2.  Countries");
        Console.WriteLine("3.  Locations");
        Console.WriteLine("4.  Employees");
        Console.WriteLine("5.  Departments");
        Console.WriteLine("6.  Jobs");
        Console.WriteLine("7.  Histories");
        Console.WriteLine("8.  LINQ");
        Console.WriteLine("9.  LINQ2");
        Console.WriteLine("10. EXIT");
        Console.WriteLine("================================================");
        Console.Write("Silahkan Pilih Menu: ");
    }
    public void Location()
    {
        Console.WriteLine("=====\t\t\t   Get All Locations\t\t\t\t=====");
    }
    public void Employee()
    {
        Console.WriteLine("=====\t\t\t   Get All Employees\t\t\t\t=====");
    }
    public void Department()
    {
        Console.WriteLine("=====\t\t\t   Get All Departments\t\t\t\t=====");
    }
    public void Jobs()
    {
        Console.WriteLine("=====\t\t\t   Get All Jobs\t\t\t\t=====");
    }
    public void Histories()
    {
        Console.WriteLine("=====\t\t\t   Get All Histories\t\t\t\t=====");
    }
    public void Linq1()
    {
        Console.WriteLine("LINQ 1");
    }
    public void Linq2()
    {
        Console.WriteLine("LINQ 2");
    }
}
