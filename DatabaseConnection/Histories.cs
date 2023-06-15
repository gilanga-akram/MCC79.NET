using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Connection
{
    public class Histories
    {
        public string connectionString = "Data Source=GILANG_AKRAM;Database=db_hr;Integrated Security=True;Connect Timeout=30;";

        public SqlConnection connection;

        public List<Histories> GettAllHist()
        {
            var hist = new List<Histories>();
            try
            {
                connection = new SqlConnection(connectionString);
                //Membuat Instance Untuk Command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_tr_histories";
                //Membuka Koneksi
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var his = new Histories();
                        his.start_date = reader.GetDateTime(0);
                        his.employee_id = reader.GetInt32(1);
                        if (reader.IsDBNull(2))
                        {
                            his.end_date = null; // Atur sebagai null jika nilainya null
                        }
                        else
                        {
                            his.end_date = reader.GetDateTime(2);
                        }

                        his.department_id = reader.GetInt32(3);
                        his.job_id = reader.GetString(4);

                        hist.Add(his);
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
            return hist;
        }
        public void MenuHist()
        {
            connection = new SqlConnection(connectionString);
            List<Histories> hist = GettAllHist();
            foreach (Histories his in hist)
            {
                Console.WriteLine("Start DATE : " + his.start_date + " EMPLOYEE ID : " + his.employee_id + " END DATE : " + his.end_date + " Department ID :  " + his.department_id + " JOB ID : " + his.job_id);
            }
        }
        public DateTime start_date { get; set; }
        public int employee_id { get; set; }
        public DateTime? end_date { get; set; }
        public int department_id { get; set; }
        public string job_id { get; set; }
    }


}