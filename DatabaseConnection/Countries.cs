using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Connection
{
    public class Countries
    {

        public string connectionString = "Data Source=GILANG_AKRAM;Database=db_hr;Integrated Security=True;Connect Timeout=30;";

        public SqlConnection connection;

        public List<Countries> GetAllCountries()
        {
            var countries = new List<Countries>();

            try
            {
                connection = new SqlConnection(connectionString);
                //Membuat Instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_countries";


                //Membuka koneksi
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var cou = new Countries();
                        cou.Id = reader.GetString(0);
                        cou.Name = reader.GetString(1);
                        cou.RegionId = reader.GetInt32(2);

                        countries.Add(cou);
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


            return countries;

        }
        public List<Countries> GetAllById(string id)
        {

            var countries = new List<Countries>();
            /*connection = new SqlConnection(connectionString);*/
            try
            {

                //Membuat Instance untuk command
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_countries WHERE id = @country_id ";
                connection.Open();

                //Membuat Parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@country_id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.VarChar;
                //Menambahkan Parameter Ke Command
                command.Parameters.Add(pId);
                //Menjalankan COmmand
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var cou = new Countries();
                        cou.Id = reader.IsDBNull(0) ? "null" : reader.GetString(0);
                        cou.Name = reader.IsDBNull(1) ? "null" : reader.GetString(1);
                        cou.RegionId = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);

                        countries.Add(cou);
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
            return countries;
        }
        public int InsertCountries(string id, string name, int reg_id)
        {
            int result = 0;
            connection = new SqlConnection(connectionString);

            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                //Membuat Instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Insert Into tb_m_countries (id, name, region_id) VALUES (@country_id, @country_name, @country_region_id)";
                command.Transaction = transaction;

                //Membuat Paramaeter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@country_id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.VarChar;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@country_name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;

                SqlParameter pRid = new SqlParameter();
                pRid.ParameterName = "@country_region_id";
                pRid.Value = reg_id;
                pRid.SqlDbType = SqlDbType.Int;
                //Menambahkan paramater ke command

                command.Parameters.Add(pId);
                command.Parameters.Add(pName);
                command.Parameters.Add(pRid);
                //Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            connection.Close();
            return result;


        }
        public int UpdateCountries(string id, string name, int reg_id)
        {
            int result = 0;
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                /* connection.Open();
                 //Instance Command
                 connection = new SqlConnection(connectionString);*/
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE tb_m_countries SET name = @country_name, region_id = @country_reg_id WHERE id = @Country_id ";
                command.Transaction = transaction;

                //Membuat Parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@country_id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.VarChar;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@country_name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;

                SqlParameter pRid = new SqlParameter();
                pRid.ParameterName = "@country_reg_id";
                pRid.Value = reg_id;
                pRid.SqlDbType = SqlDbType.Int;
                /*
                                SqlParameter pRid = new SqlParameter();
                                pRid.ParameterName = "@regions_id";
                                pRid.Value = region_id;
                                pRid.SqlDbType = SqlDbType.Int;
                */
                //Menambah parameter ke command
                command.Parameters.Add(pId);
                command.Parameters.Add(pName);
                command.Parameters.Add(pRid);
                //Menjalankan Command
                result = command.ExecuteNonQuery();
                transaction.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            connection.Close();
            return result;
        }
        public int DeleteCountries(string id)
        {
            int result = 0;
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE from tb_m_countries where id = @country_id ";
                command.Transaction = transaction;

                //Membuat Parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@country_id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.VarChar;
                /*
                                SqlParameter pRid = new SqlParameter();
                                pRid.ParameterName = "@regions_id";
                                pRid.Value = region_id;
                                pRid.SqlDbType = SqlDbType.Int;
                */
                //Menambah parameter ke command
                command.Parameters.Add(pId);
                /*     command.Parameters.Add(pRid);*/

                //Menjalankan Command
                result = command.ExecuteNonQuery();
                transaction.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }




            return result;
        }

        public void MenuCountries()
        {


            connection = new SqlConnection(connectionString);
            //GetAll
            List<Countries> country = GetAllCountries();
            foreach (Countries countries in country)
            {
                Console.WriteLine("Id : " + countries.Id + ", Name " + countries.Name + ", Region Id " + countries.RegionId);
            }


            /*        Console.WriteLine("INPUT DATA : ");*/
            /*
                        string InputRegion = Console.ReadLine();
                        InsertToRegion(InputRegion);

                        regions = GetAllRegions();
                        foreach (var region in regions)
                        {
                            Console.WriteLine("Id : " + region.Id + ", Name " + region.Name);
                        }*/

            Console.WriteLine("\n");
            Console.WriteLine("1.GetById");
            Console.WriteLine("2.Insert");
            Console.WriteLine("3.Update");
            Console.WriteLine("4.Delete");

            try
            {
                Console.Write("Pilih Menu : ");
                int InputPilihan = int.Parse(Console.ReadLine());
                switch (InputPilihan)
                {
                    case 1:
                        MenuGetId();
                        break;
                    case 2:
                        MenuInsert();
                        break;
                    case 3:
                        MenuUpdate();
                        break;
                    case 4:
                        MenuDelete();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void MenuGetId()
        {
            connection = new SqlConnection(connectionString);
            List<Countries> country = GetAllCountries();
            Console.WriteLine("GET ALL BY ID");
            Console.Write("Masukkan ID Region : ");
            string id = Console.ReadLine();
            country = GetAllById(id);
            foreach (Countries countries in country)
            {
                Console.WriteLine("Id : " + countries.Id + ", Name : " + countries.Name + ", Region Id : " + countries.RegionId);
                Console.ReadKey();
                MenuCountries();
            }
        }
        public void MenuInsert()
        {
            connection = new SqlConnection(connectionString);
            Console.WriteLine("INSERT");
            Console.Write("Masukkan ID Countries : ");
            string id = Console.ReadLine();
            Console.Write("Masukkan Nama Countries : ");
            string name = Console.ReadLine();
            Console.Write("Masukkan region_id Countries : ");
            int reg_id = int.Parse(Console.ReadLine());
            int isInsertSuccessfull = InsertCountries(id, name, reg_id);
            if (isInsertSuccessfull > 0)
            {
                Console.WriteLine("Data Berhasil Ditambahkan !");
                Console.ReadKey();
                MenuCountries();
            }
            else
            {
                Console.WriteLine("Data Gagal Ditambahkan");
                MenuCountries();
            }
        }
        public void MenuUpdate()
        {
            connection = new SqlConnection(connectionString);
            Console.WriteLine("UPATE");
            Console.Write("Masukkan ID : ");
            string id = Console.ReadLine();
            Console.Write("Masukkan Nama Yang Ingin Di Update : ");
            string newName = Console.ReadLine();
            Console.Write("Masukkan Id Region Yang Ingin Di Update : ");
            int reg_id = int.Parse(Console.ReadLine());
            /*  Console.WriteLine("Enter ID");
              int new_id = int.Parse(Console.ReadLine());
  */
            int update = UpdateCountries(id, newName, reg_id);
            if (update > 0)
            {
                Console.WriteLine("Data Berhasil Di Update");
                Console.ReadKey();
                MenuCountries();
            }
            else
            {
                Console.WriteLine("Data Gagal Di Update");
                Console.ReadKey();
                MenuCountries();
            }
        }
        public void MenuDelete()
        {
            connection = new SqlConnection(connectionString);
            Console.WriteLine("Delete");
            Console.Write("Masukkan ID Yang Ingin Di DELETE : ");
            string reg_id = Console.ReadLine();
            /*  Console.WriteLine("Enter ID");
              int new_id = int.Parse(Console.ReadLine());
  */
            int delete = DeleteCountries(reg_id);
            if (delete > 0)
            {
                Console.WriteLine("Data Berhasil Di Didelete");
                Console.ReadKey();
                MenuCountries();
            }
            else
            {
                Console.WriteLine("Data Gagal Di Delete");
                Console.ReadKey();
                MenuCountries();
            }
        }


        public string Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }


    }

}