using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public class Jobs
    {
        static string connectionString = "Data Source=GILANG_AKRAM;Database=db_hr;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;

        public List<Jobs> GettAllJob()
        {
            var jobs = new List<Jobs>();
            try
            {
                connection = new SqlConnection(connectionString);
                //Membuat Instance Untuk Command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_jobs";
                //Membuka Koneksi
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var job = new Jobs();
                        job.id = reader.IsDBNull(0) ? "null" : reader.GetString(0);
                        job.tittle = reader.IsDBNull(1)  ? "null" : reader.GetString(1);
                        job.min_salary = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        job.max_salary = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

                        jobs.Add(job);
                    }
                }
                else
                {
                    Console.WriteLine("Data Not Found!!!");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return jobs;
        }
        public void MenuJobs()
        {
            connection = new SqlConnection(connectionString);
            List<Jobs> jobs = GettAllJob();
            foreach (Jobs job in jobs)
            {
                Console.WriteLine("Id : " + job.id + " Tittle : " + job.tittle + " Min Salary : " + job.min_salary + " Max Salary : " + job.max_salary);
                Console.ReadKey();
            }
        }
        public string id { get; set; }
        public string tittle { get; set; }
        public int min_salary { get; set; }
        public int max_salary { get; set; }
    }
}