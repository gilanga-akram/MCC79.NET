using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection.Models;

namespace Connection.Views;
public class ViewCountry
{
    public void Menu()
    {
        Console.Clear();
        Console.WriteLine("       Menu Of Country      ");
        Console.WriteLine("============================");
        Console.WriteLine("1. Get All Data of Country");
        Console.WriteLine("2. Get Data By id in Country");
        Console.WriteLine("3. Insert Data to Country");
        Console.WriteLine("4. Update Data in Country");
        Console.WriteLine("5. Delete Data in Country");
        Console.WriteLine("6. Exit");
        Console.WriteLine("============================");
        Console.Write("Pilih : ");
    }
    public void CountryTitle()
    {
        Console.WriteLine("=====\t\t\t   Get All Countries\t\t\t\t=====");
    }
    public void GetAll(List<Country> countrys)
    {
        foreach (Country country in countrys)
        {
            Console.WriteLine($"id : {country.Id}, nama : {country.Name},\t region_id : {country.RegionId}");
        }
    }
    public void CountryTitleByid()
    {
        Console.WriteLine("=====\t\t\t   Get By Id Countries \t\t\t\t=====");
        Console.Write("Masukan Id Yang Ingin Didapatkan Dari Data Tabel Country : ");
    }
    public void GetByid(Country country)
    {
        Console.WriteLine("id : " + country.Id + ", nama : " + country.Name + ", region_id : " + country.RegionId);
    }
    public void Insert()
    {
        Console.WriteLine("=====\t\t\t   Insert Data To Countries\t\t\t\t=====");
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
