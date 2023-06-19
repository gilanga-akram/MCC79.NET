using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Connection.Contexts;
using Connection.Models;
using Connection.Views;

namespace Connection.Controllers;
public class MenuRegion
{
    private Region _region = new Region();
    private ViewRegion _viewregion = new ViewRegion();
    private ViewGeneric _viewgeneric = new ViewGeneric();
    public void Menu()
    {
        bool isFinish = true;
        do
        {
            _viewregion.Menu();
            int menu = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (menu)
                {
                    case 1:
                        _viewregion.RegionTitle();
                        var regions = _region.GetAllRegion();
                        _viewregion.GetAll(regions);
                        Console.ReadKey();
                        break;
                    case 2:
                        _viewregion.RegionTitleByid();
                        int id = int.Parse(Console.ReadLine());
                        var region =_region.GetByIdRegion(id);
                        if(region == null)
                        {
                            _viewgeneric.DataNotFound();
                        }
                        else
                        {
                            _viewregion.GetById(region);
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        _viewregion.Insert();
                        string insertnamaIR = Console.ReadLine();
                        int insertsucces = _region.InsertRegion(insertnamaIR);
                        _viewregion.ResultInsert(insertsucces);
                        Console.ReadKey();
                        break;
                    case 4:                            
                        _viewregion.Update();
                        Console.Write("Masukan Nama: ");
                        string insertnamaUR = Console.ReadLine();
                        Console.Write("Masukan Id: ");
                        int insertidUR = Convert.ToInt32(Console.ReadLine());
                        int updatesucces = _region.UpdateRegion(insertidUR, insertnamaUR);
                        _viewregion.ResultUpdate(updatesucces);
                        Console.ReadKey();
                        break;
                    case 5:
                        _viewregion.Delete();
                        int insertidDR = Convert.ToInt32(Console.ReadLine());
                        int deletesucces = _region.DeleteRegion(insertidDR);
                        _viewregion.ResultDelete(deletesucces);                            
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
