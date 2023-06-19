using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection.Models;
using Connection.Views;

namespace Connection.Controllers;
public class MenuUtama
{
    private ViewGeneric _viewgeneric = new ViewGeneric();
    private ViewLocation _viewlocation = new ViewLocation();
    private ViewEmployee _viewemployee = new ViewEmployee();
    private ViewDepartment _viewdepartment = new ViewDepartment();
    private ViewJobs _viewjobs = new ViewJobs();
    private ViewHistories _viewhistories = new ViewHistories();
    private Location _location = new Location();
    private Department _department = new Department();
    private Employee _employee = new Employee();
    private Jobs _jobs = new Jobs();
    private Histories _histories = new Histories();
    public  void FirstMenu()
    {
        bool isFinish = true;
        do
        {
            _viewgeneric.Menu();
            int menu = Convert.ToInt32(Console.ReadLine());
            switch (menu)
            {
                case 1:
                    new MenuRegion().Menu();
                    break;
                case 2:
                    new MenuCountry().Menu();
                    break;
                case 3:
                    _viewgeneric.Location();
                    var locations = _location.GetAllLocation();
                    _viewlocation.GetAll(locations);
                    Console.ReadKey();
                    break;
                case 4:
                    _viewgeneric.Employee();
                    var employees = _employee.GetAllEmployee();
                    _viewemployee.GetAll(employees);
                    Console.ReadKey();
                    break;
                case 5:
                    _viewgeneric.Department();
                    var departments = _department.GetAllDepartment();
                    _viewdepartment.GetAll(departments);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 6:
                    _viewgeneric.Jobs();
                    var jobs = _jobs.GetAllJob();
                    _viewjobs.GetAll(jobs);
                    Console.ReadKey();
                    break;
                case 7:
                    _viewgeneric.Histories();
                    var histories = _histories.GetAllHistories();
                    _viewhistories.GetAll(histories);
                    Console.ReadKey();
                    break;
                case 8:
                    _viewgeneric.Linq1();
                    new Linq().GetJoin(5);
                    Console.ReadKey();
                    break;
                case 9:
                    _viewgeneric.Linq2();
                    new Linq().GetDepartments();
                    Console.Clear();
                    break;
                case 10:
                    isFinish = false;
                    break;
                default:
                    isFinish = true;
                    break;
            }
        } while (isFinish);
    }
}
