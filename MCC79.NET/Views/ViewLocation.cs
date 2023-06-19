using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection.Models;

namespace Connection.Views;
public class ViewLocation
{
    public void GetAll (List<Location> locations)
    {
        foreach (Location location in locations)
        {
            Console.WriteLine($"Id : {location.Id}, Street Address : {location.StreetAddress}, Postal Code : {location.PostalCode}, City : {location.City}, Statae Province : {location.StateProvince}, Country Id : {location.CountryId}");
        }
    }
}
