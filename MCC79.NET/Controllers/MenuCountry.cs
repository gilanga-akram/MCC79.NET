using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Connection.Contexts;
using Connection.Models;
using Connection.Views;

namespace Connection.Controllers;
public class MenuCountry
{
    private Country _country = new Country();
    private ViewCountry _viewcountry = new ViewCountry();
    private ViewGeneric _viewgeneric = new ViewGeneric();
    public void Menu()
    {
        bool isFinish = true;
        do
        {
            _viewcountry.Menu();
            int menu = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (menu)
                {
                    case 1:
                        _viewcountry.CountryTitle();
                        var countrys = _country.GetAllCountry();
                        _viewcountry.GetAll(countrys);
                        Console.ReadKey();
                        break;
                    case 2:
                        _viewcountry.CountryTitleByid();
                        int id = int.Parse(Console.ReadLine());
                        var country = _country.GetByIdCountry(id);
                        if (country == null)
                        {
                            _viewgeneric.DataNotFound();
                        }
                        else
                        {
                            _viewcountry.GetByid(country);
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        _viewcountry.Insert();
                        Console.Write("Masukan id: ");
                        string insertidIC = Console.ReadLine();
                        Console.Write("Masukan Nama: ");
                        string insertnamaIC = Console.ReadLine();
                        Console.Write("Masukan RegId: ");
                        int insertregidIC = Convert.ToInt32(Console.ReadLine());
                        int insertsucces = _country.InsertCountry(insertidIC, insertnamaIC, insertregidIC);
                        _viewcountry.ResultInsert(insertsucces);
                        Console.ReadKey();
                        break;
                    case 4:
                        _viewcountry.Update();
                        Console.Write("Masukan Update Nama: ");
                        string insertnamaUC = Console.ReadLine();
                        Console.Write("Masukan Update RegId: ");
                        int insertregidUC = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Masukan Id Yang Ingin Dirubah : ");
                        string insertidUC = Console.ReadLine();
                        int updatesucces = _country.UpdateCountry(insertidUC, insertnamaUC, insertregidUC);
                        _viewcountry.ResultUpdate(updatesucces);
                        Console.ReadKey();
                        break;
                    case 5:
                        _viewcountry.Delete();
                        Console.Write("Masukan Id Yang Ingin Dihapus: ");
                        string insertidDC = Console.ReadLine();
                        int deletesucces = _country.DeleteCountry(insertidDC);
                        _viewcountry.ResultDelete(deletesucces);
                        Console.ReadKey();
                        break;
                    case 6:
                        isFinish = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } while (isFinish);            
    }
}
