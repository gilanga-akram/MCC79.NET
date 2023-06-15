using Connection;
using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Connection
{
    public class Menu
    {
        Regions reg = new Regions();
        Countries cou = new Countries();
        Locations loc = new Locations();
        Jobs job = new Jobs();
        Departments dep = new Departments();
        Employees emp = new Employees();
        Histories his = new Histories();
        static string connectionString = "Data Source=GILANG_AKRAM;Database=db_hr;Integrated Security=True;Connect Timeout=30;";

       /*atic SqlConnection connection;
        public void MenuDb()
        {
            Console.WriteLine("1.Countries");
            Console.WriteLine("2.Regions");
            Console.WriteLine("3.Locations");
            Console.WriteLine("4.Jobs");
            Console.WriteLine("5.Departments");
            Console.WriteLine("6.Employees");
            Console.WriteLine("7.Histories");
          

            try
            {
                Console.Write("Pilih Tabel : ");
                int InputPilihan = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (InputPilihan)
                {
                    case 1:
                        cou.MenuCountries();
                        break;
                    case 2:
                        reg.MenuRegion();
                        break;
                    case 3:
                        loc.MenuLocations();
                        break;
                    case 4:
                        job.MenuJobs();
                        break;
                    case 5:
                        dep.MenuDep();
                        break;
                    case 6:
                        emp.MenuEmp();
                        break;
                    case 7:
                        his.MenuHist();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }*/


    }
}