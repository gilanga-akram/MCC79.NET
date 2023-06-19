using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Connection.Contexts;
using Connection.Views;

namespace Connection.Models;
public class Country
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int RegionId { get; set; }

    private ViewGeneric _viewgeneric = new ViewGeneric();

    public List<Country> GetAllCountry()
    {
        var connection = Koneksi.Get();
        connection.Open();
        List<Country> countrys = new List<Country>();
        try
        {                
            // instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_countries";

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var countrie = new Country();
                    countrie.Id = reader.GetString(0);
                    countrie.Name = reader.GetString(1);
                    countrie.RegionId = reader.GetInt32(2);

                    countrys.Add(countrie);
                }
            }
            else
            {
                _viewgeneric.DataNotFound();
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        connection.Close();
        return countrys;
    }

    public Country GetByIdCountry(int id)
    {
        var connection = Koneksi.Get();
        connection.Open();
        var countrygetbyid = new Country();
        try
        {                     
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_countries WHERE id = @id";
            command.Parameters.AddWithValue("@id", id);

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                countrygetbyid.Id = reader.GetString(0);
                countrygetbyid.Name = reader.GetString(1);
                countrygetbyid.RegionId = reader.GetInt32(2);
            }
            else
            {
                countrygetbyid = new Country();
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        connection.Close();
        return countrygetbyid;
    }

    public int InsertCountry(string id, string nama, int regionid)
    {
        var connection = Koneksi.Get();
        connection.Open();
        int result = 0;
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO tb_m_countries (id, nama, region_id) VALUES (@id, @nama, @region_id)";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter("@id", SqlDbType.VarChar);
            pId.Value = id;
            command.Parameters.Add(pId);

            SqlParameter pNama = new SqlParameter("@nama", SqlDbType.VarChar);
            pNama.Value = nama;
            command.Parameters.Add(pNama);

            SqlParameter pManId = new SqlParameter("@region_id", SqlDbType.Int);
            pManId.Value = regionid;
            command.Parameters.Add(pManId);

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

    public int UpdateCountry(string id, string nama, int regionid)
    {
        var connection = Koneksi.Get();
        connection.Open();
        int result = 0;
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE tb_m_countries SET nama = @namaU, region_id = @region_idU WHERE id = @idU";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter("@idU", SqlDbType.VarChar);
            pId.Value = id;
            command.Parameters.Add(pId);

            SqlParameter pNama = new SqlParameter("@namaU", SqlDbType.VarChar);
            pNama.Value = nama;
            command.Parameters.Add(pNama);

            SqlParameter pManId = new SqlParameter("@region_idU", SqlDbType.Int);
            pManId.Value = regionid;
            command.Parameters.Add(pManId);

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

    public int DeleteCountry(string id)
    {
        var connection = Koneksi.Get();
        connection.Open();
        int result = 0;
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "DELETE FROM tb_m_countries WHERE id = @idD";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@idD";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.Char;
            command.Parameters.Add(pId);

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
}
