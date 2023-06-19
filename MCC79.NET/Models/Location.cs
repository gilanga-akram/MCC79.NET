using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection.Contexts;

namespace Connection.Models;
public class Location
{
    public int Id { get; set; }
    public string StreetAddress { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string CountryId { get; set; }

    public List<Location> GetAllLocation()
    {
        var connection = Koneksi.Get();
        connection.Open();
        List<Location> locations = new List<Location>();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_locations";

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var location = new Location();
                    location.Id = reader.GetInt32(0);
                    location.StreetAddress = reader.GetString(1);
                    location.PostalCode = reader.GetString(2);
                    location.City = reader.GetString(3);
                    location.StateProvince = reader.GetString(4);
                    location.CountryId = reader.GetString(5);

                    locations.Add(location);
                }
            }
            else
            {
                Console.WriteLine("Data Not Found");
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        connection.Close();
        return locations;
    }
}
