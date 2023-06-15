using System.Data.SqlClient;

namespace Connection
{
    class Connection
    {
        public static string connectionString = "Data Source=GILANG_AKRAM;Database=db_hr;Integrated Security=True;Connect Timeout=30;";
        public static SqlConnection connection = new SqlConnection(connectionString);

    }
}
