using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection.Contexts;
#nullable enable
namespace Connection.Models;
public class Histories
{
    public DateTime MulaiDate { get; set; }
    public int EmployeeId { get; set; }
    public DateTime? EndDate { get; set; }
    public int DepartmentId { get; set; }
    public string JobId { get; set; }

    public List<Histories> GetAllHistories()
    {
        var connection = Koneksi.Get();
        connection.Open();
        List<Histories> histories = new List<Histories>();
        //var histories = new List<Histories>();
        try
        {
            // instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_tr_histories";

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var historie = new Histories();
                    historie.MulaiDate = reader.GetDateTime(0);
                    historie.EmployeeId = reader.GetInt32(1);
                    //historie.EndDate = reader.GetDateTime(2);
                    if (reader.IsDBNull(2))
                    {
                        historie.EndDate = null; // Atur sebagai null jika nilainya null
                    }
                    else
                    {
                        historie.EndDate = reader.GetDateTime(2);
                    }
                    historie.DepartmentId = reader.GetInt32(3);
                    historie.JobId = reader.GetString(4);

                    histories.Add(historie);
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
        return histories;
    }
}

