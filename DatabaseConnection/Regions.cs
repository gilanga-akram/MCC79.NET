using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Connection
{

    public class Regions
    {
        public string connectionString = "Data Source=GILANG_AKRAM;Database=db_hr;Integrated Security=True;Connect Timeout=30;";

        public SqlConnection connection;
        public List<Regions> GetAllRegions()

        {

            var region = new List<Regions>();

            try
            {
                connection = new SqlConnection(connectionString);
                //Membuat Instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_regions";


                //Membuka koneksi
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var reg = new Regions();
                        reg.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        reg.Name = reader.IsDBNull(1) ? "null" : reader.GetString(1);

                        region.Add(reg);
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
            return region;

        }

        public List<Regions> GetAllById(int id)
        {

            var region = new List<Regions>();
            /*connection = new SqlConnection(connectionString);*/
            try
            {

                //Membuat Instance untuk command
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_regions WHERE id = @region_id ";
                connection.Open();

                //Membuat Parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@region_id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                //Menambahkan Parameter Ke Command
                command.Parameters.Add(pId);
                //Menjalankan COmmand
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var reg = new Regions();
                        reg.Id = reader.GetInt32(0);
                        reg.Name = reader.GetString(1);

                        region.Add(reg);
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
            return region;
        }
        public int UpdateRegion(string name, int id)
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
                /*SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE tb_m_regions SET name = @regions_name WHERE id = @id ";
                command.Transaction = transaction;

                //Membuat Parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@regions_name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                /*
                                SqlParameter pRid = new SqlParameter();
                                pRid.ParameterName = "@regions_id";
                                pRid.Value = region_id;
                                pRid.SqlDbType = SqlDbType.Int;
                
                //Menambah parameter ke command
                command.Parameters.Add(pName);
                command.Parameters.Add(pId);
                   command.Parameters.Add(pRid);

                //Menjalankan Command
                result = command.ExecuteNonQuery();
                transaction.Commit();*/

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
        public int DeleteRegion(int id)
        {
            int result = 0;
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE from tb_m_regions where id = @id ";
                command.Transaction = transaction;

                //Membuat Parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
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

        public int InsertToRegion(string name)
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
                command.CommandText = "Insert Into tb_m_regions (name) VALUES (@region_name)";
                command.Transaction = transaction;

                //Membuat Paramaeter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@region_name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;

                //Menambahkan paramater ke command
                command.Parameters.Add(pName);

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

        public void MenuRegion()
        {

            Console.Clear();
            connection = new SqlConnection(connectionString);
            //GetAll
            List<Regions> regions = GetAllRegions();
            foreach (Regions region in regions)
            {
                Console.WriteLine("Id : " + region.Id + ", Name " + region.Name);
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
            List<Regions> regions = GetAllRegions();
            Console.WriteLine("GET ALL BY ID");
            Console.Write("Masukkan ID Region : ");
            int id = Convert.ToInt32(Console.ReadLine());
            regions = GetAllById(id);
            foreach (Regions region in regions)
            {
                Console.WriteLine("Id : " + region.Id + ", Name " + region.Name);
                Console.ReadKey();
                MenuRegion();
            }
        }
        public void MenuUpdate()
        {
            connection = new SqlConnection(connectionString);
            Console.WriteLine("UPATE");
            Console.Write("Masukkan ID :");
            int reg_id = int.Parse(Console.ReadLine());
            Console.WriteLine("Masukkan Nama Yang Ingin Di Update : ");
            string newName = Console.ReadLine();
            /*  Console.WriteLine("Enter ID");
              int new_id = int.Parse(Console.ReadLine());
  */
            int update = UpdateRegion(newName, reg_id);
            if (update > 0)
            {
                Console.WriteLine("Data Berhasil Di Update");
                Console.ReadKey();
                MenuRegion();
            }
            else
            {
                Console.WriteLine("Data Gagal Di Update");
                Console.ReadKey();
                MenuRegion();
            }
        }
        public void MenuDelete()
        {
            connection = new SqlConnection(connectionString);
            Console.WriteLine("Delete");
            Console.Write("Masukkan ID Yang Ingin Di DELETE : ");
            int reg_id = int.Parse(Console.ReadLine());
            /*  Console.WriteLine("Enter ID");
              int new_id = int.Parse(Console.ReadLine());
  */
            int delete = DeleteRegion(reg_id);
            if (delete > 0)
            {
                Console.WriteLine("Data Berhasil Di Didelete");
                Console.ReadKey();
                MenuRegion();
            }
            else
            {
                Console.WriteLine("Data Gagal Di Delete");
                Console.ReadKey();
                MenuRegion();
            }
        }
        public void MenuInsert()
        {
            connection = new SqlConnection(connectionString);
            Console.WriteLine("INSERT");
            Console.Write("Masukkan Nama Region :");
            string name = Console.ReadLine();
            int isInsertSuccessfull = InsertToRegion(name);
            if (isInsertSuccessfull > 0)
            {
                Console.WriteLine("Data Berhasil Ditambahkan !");
                Console.ReadKey();
                MenuRegion();
            }
            else
            {
                Console.WriteLine("Data Gagal Ditambahkan");
                MenuRegion();
            }
        }
        /* public void MenuInsertRegion()
         {
             Console.WriteLine("INPUT DATA : ");
             *//*
                         string InputRegion = Console.ReadLine();
                         InsertToRegion(InputRegion);

                         regions = GetAllRegions();
                         foreach (var region in regions)
                         {
                             Console.WriteLine("Id : " + region.Id + ", Name " + region.Name);
                         }*//*

             Console.WriteLine("INSERT");S
             Console.Write("Masukkan Nama Region :");
             string name = Console.ReadLine();
             int isInsertSuccessfull = reg.InsertToRegion(name);
             if (isInsertSuccessfull > 0)
             {
                 Console.WriteLine("Data Berhasil Ditambahkan !");
             }
             else
             {
                 Console.WriteLine("Data Gagal Ditambahkan");
             }
         }*/

        public int Id { get; set; }
        public string Name { get; set; }



    }
}