using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Connection.Models;

namespace Connection.Views;
public class ViewRegion
{
    public void Menu()
    {
        Console.Clear();
        Console.WriteLine("       Menu Of Regions      ");
        Console.WriteLine("============================");
        Console.WriteLine("1. Get All Data of Regions");
        Console.WriteLine("2. Get Data By id in Regions");
        Console.WriteLine("3. Insert Data to Regions");
        Console.WriteLine("4. Update Data in Regions");
        Console.WriteLine("5. Delete Data in Regions");
        Console.WriteLine("6. Exit");
        Console.WriteLine("============================");
        Console.Write("Pilih : ");
    }
    public void RegionTitle()
    {
        Console.WriteLine("=====\t\t\t    Get All Regions\t\t\t\t=====");
    }
    public void GetAll(List<Region> regions)
    {
        foreach (Region region in regions)
        {
            Console.WriteLine($"id : {region.Id}, nama : {region.Name}");
        }
    }
    public void RegionTitleByid()
    {
        Console.WriteLine("=====\t\t\t   Get By Id Regions\t\t\t\t=====");
        Console.Write("Masukan Id Yang Ingin Didapatkan Dari Data Tabel Region : ");
    }
    public void GetById(Region region)
    { 
         Console.WriteLine("id : " + region.Id + ", nama : " + region.Name);
    }
    public void Insert()
    {
        Console.WriteLine("=====\t\t\t   Insert Data To Regions\t\t\t\t=====");
        Console.Write("Masukan Nama: ");
    }
    public void ResultInsert(int insertsucces)
    {
        if (insertsucces > 0)
        {
            Console.WriteLine("Data Sudah Ditambahkan");
        }
        else
        {
            Console.WriteLine("Data Gagal Ditambahkan");
        }
    }
    public void Update()
    {
        Console.WriteLine("=====\t\t\t   Update Data In Regions\t\t\t\t=====");       
    }
    public void ResultUpdate(int updatesucces)
    {
        if (updatesucces > 0)
        {
            Console.WriteLine("Data Sudah Diupdate");
        }
        else
        {
            Console.WriteLine("Data Gagal Diupdate");
        }
    }
    public void Delete()
    {
        Console.WriteLine("=====\t\t\t   Delete Data In Regions\t\t\t\t=====");
        Console.Write("Masukan Id Yang Ingin Dihapus: ");
    }
    public void ResultDelete(int deletesucces)
    {
        if (deletesucces > 0)
        {
            Console.WriteLine("Data Sudah Dihapus");
        }
        else
        {
            Console.WriteLine("Data Gagal Dihapus");
        }
    }
}
