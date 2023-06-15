using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public class Locations
    {
        static string connectionString = "Data Source=GILANG_AKRAM;Database=db_hr;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;

        public List<Locations> GettAllLoc()
        {
            var locations = new List<Locations>();
            try
            {
                connection = new SqlConnection(connectionString);
                //Membuat Instance Untuk Command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_locations";
                //Membuka Koneksi
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var loc = new Locations();
                        loc.id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        loc.street = reader.IsDBNull(1) ? "null" : reader.GetString(1);
                        loc.post = reader.IsDBNull(2) ? "null" : reader.GetString(2);
                        loc.city = reader.IsDBNull(3) ? "null" : reader.GetString(3);
                        loc.state = reader.IsDBNull(4) ? "null" : reader.GetString(4);
                        loc.co_id = reader.IsDBNull(5) ? "null" : reader.GetString(5);

                        locations.Add(loc);
                    }
                }
                else
                {
                    Console.WriteLine("Data Not Found!");
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
        public void MenuLocations()
        {
            connection = new SqlConnection(connectionString);
            List<Locations> locations = GettAllLoc();
            foreach (Locations location in locations)
            {
                Console.WriteLine("Id : " + location.id + " Street : " + location.street + " Postal Code : " + location.post + " City : " + location.city + " State Province : " + location.state + " Country Id : " + location.co_id);
            }
        }
        public int id { get; set; }
        public string street { get; set; }
        public string post { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string co_id { get; set; }

    }

}