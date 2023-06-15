using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public class Departments
    {
        static string connectionString = "Data Source=GILANG_AKRAM;Database=db_hr;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;

        public List<Departments> GettAllDep()
        {
            var deps = new List<Departments>();
            try
            {
                connection = new SqlConnection(connectionString);
                //Membuat Instance Untuk Command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_departments";
                //Membuka Koneksi
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var dep = new Departments();
                        dep.id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        dep.name = reader.IsDBNull(1) ? "null" : reader.GetString(1);
                        dep.location_id = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        dep.manager_id = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

                        deps.Add(dep);
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
            return deps;
        }
        public void MenuDep()
        {
            connection = new SqlConnection(connectionString);
            List<Departments> deps = GettAllDep();
            foreach (Departments dep in deps)
            {
                Console.WriteLine(" Id : " + dep.id + " NAME : " + dep.name + " LOCATION ID : " + dep.location_id+ " MANAGER ID : " + dep.manager_id);
            }
        }
        public int id { get; set; }
        public string name { get; set; }
        public int location_id { get; set; }
        public int manager_id { get; set; }
    }
}