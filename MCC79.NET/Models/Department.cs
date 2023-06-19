using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection.Contexts;

namespace Connection.Models;
public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LocationId { get; set; }
    public int ManagerId { get; set; }

    public List<Department> GetAllDepartment()
    {
        var connection = Koneksi.Get();
        connection.Open();
        List<Department> departments = new List<Department>();
        //var departments = new List<Department>();
        try
        {

            // instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_departments";

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var department = new Department();
                    department.Id = reader.GetInt32(0);
                    department.Name = reader.GetString(1);
                    department.LocationId = reader.GetInt32(2);
                    department.ManagerId = reader.GetInt32(3);

                    departments.Add(department);
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
        return departments;
    }
}
