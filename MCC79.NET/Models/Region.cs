using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Channels;
using Connection.Contexts;
using Connection.Views;

namespace Connection.Models;
public class Region
{
    public int Id { get; set; }
    public string Name { get; set; }

    private ViewGeneric _viewgeneric = new ViewGeneric();
    public List<Region> GetAllRegion()
    {
        var connection = Koneksi.Get();
        connection.Open();
        var regions = new List<Region>();
        try
        {
            // instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_regions";

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var reg = new Region();
                    reg.Id = reader.GetInt32(0);
                    reg.Name = reader.GetString(1);

                    regions.Add(reg);
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
        return regions;
    }
    public Region GetByIdRegion(int id)
    {
        var connection = Koneksi.Get();
        connection.Open();
        var regiongetbyid = new Region();
        try
        {                          
            // instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_regions WHERE id = @Id";
            command.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                regiongetbyid.Id = reader.GetInt32(0);
                regiongetbyid.Name = reader.GetString(1);
                     
            }
            else
            {
                regiongetbyid = new Region();
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        connection.Close();
        return regiongetbyid;
    }
    public int InsertRegion(string nama)
    {
        var connection = Koneksi.Get();
        connection.Open();
        int result = 0;
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Insert Into tb_m_regions (nama) VALUES (@region_nama)";
            command.Transaction = transaction;

            SqlParameter pNama = new SqlParameter();
            pNama.ParameterName = "@region_nama";
            pNama.Value = nama;
            pNama.SqlDbType = SqlDbType.VarChar;

            command.Parameters.Add(pNama);
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
    public int UpdateRegion(int id, string nama)
    {
        var connection = Koneksi.Get();
        connection.Open();
        int result = 0;
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE tb_m_regions SET nama = @regionname WHERE id = @regionid";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@regionid";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pId);

            SqlParameter pNama = new SqlParameter();
            pNama.ParameterName = "@regionname";
            pNama.Value = nama;
            pNama.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pNama);

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
    public int DeleteRegion(int id)
    {
        var connection = Koneksi.Get();
        connection.Open();
        int result = 0;
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "DELETE FROM tb_m_regions WHERE id = @id";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.Int;
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
