using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Connection
{
    public class Employees
    {
        static string connectionString = "Data Source=GILANG_AKRAM;Database=db_hr;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;

        public List<Employees> GettAllEmp()
        {
            var emp = new List<Employees>();
            try
            {
                connection = new SqlConnection(connectionString);
                //Membuat Instance Untuk Command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_employees";
                //Membuka Koneksi
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var emps = new Employees();
                        emps.id = reader.IsDBNull(0) ? 0 :reader.GetInt32(0);
                        emps.first_name = reader.IsDBNull(1) ? "null" :reader.GetString(1);
                        emps.last_name = reader.IsDBNull(2) ? "null" : reader.GetString(2);
                        emps.email = reader.IsDBNull(3) ? "null" : reader.GetString(3);
                        emps.phone_number = reader.IsDBNull(4) ? "null" : reader.GetString(4);
                        emps.hire_date = reader.GetDateTime(5);
                        emps.salary = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                        if (reader.IsDBNull(7))
                        {
                            emps.comission_pct = null;
                        }
                        else
                        {
                            emps.comission_pct = reader.GetDecimal(7);
                        }
                        emps.manager_id = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                        emps.job_id = reader.GetString(9);
                        emps.department_id = reader.GetInt32(10);

                        emp.Add(emps);
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
            return emp;
        }
        public void MenuEmp()
        {
            connection = new SqlConnection(connectionString);
            List<Employees> emps = GettAllEmp();
            foreach (Employees emp in emps)
            {
                Console.WriteLine("Id : " + emp.id + " FIRST NAME : " + emp.first_name + " LAST NAME : " + emp.last_name + " EMAIL : " + emp.email + " PHONE NUMBER : " + emp.phone_number + " HIRE DATE : " + emp.hire_date + " SALARY : " + emp.salary + " COMISSION PCT : " + emp.comission_pct + " MANAGER ID : " + emp.manager_id + " JOB ID : " + emp.job_id + " DEPARTMENT ID : " + emp.department_id);
            }
        }
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public DateTime hire_date { get; set; }
        public int salary { get; set; }
        public Decimal? comission_pct { get; set; }
        public int manager_id { get; set; }
        public string job_id { get; set; }
        public int department_id { get; set; }
    }
}
