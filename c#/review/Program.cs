using System.Text.Json;
using Microsoft.Data.SqlClient;
internal class Program
{
    class Setting
    {
        public string? ConnectionString { get; set; }
    }
    private static void WriteJson()
    {
        Setting s = new Setting()
        {
            ConnectionString = "Server=localhost;Database=MyDatabase;User Id=sa;Password=MyPassword;"
        };
        string json = JsonSerializer.Serialize(s);
        File.WriteAllText("settings.json", json);
    }
    private static void ReadJson()
    {
        string json = File.ReadAllText("settings.json");
        Setting? s = JsonSerializer.Deserialize<Setting>(json);
        Console.WriteLine(s?.ConnectionString);
    }
    private static void ConnectDatabase()
    {
        string cnnStr = "Server=localhost;Database=aa;User Id=sa;Password=james@2025;TrustServerCertificate=True;";
        SqlConnection conn = new SqlConnection(cnnStr);
        try
        {
            conn.Open();
            Console.WriteLine("Database connection successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private static void ReadFromDatabase()
    {
        SqlConnection conn = new SqlConnection("Server=localhost;Database=aa;User Id=sa;Password=james@2025;TrustServerCertificate=True;");
        SqlCommand cmd = new SqlCommand("SELECT * FROM products WHERE price <= 30", conn);

        try
        {
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr["price"]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private static void WriteToDatabase()
    {
        SqlConnection conn = new SqlConnection("Server=tcp:localhost;Database=aa;User Id=sa;Password=james@2025;TrustServerCertificate=True;");
        SqlCommand cmd = new SqlCommand("AddProducts", conn);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        try
        {
            conn.Open();
            cmd.Parameters.AddWithValue("@price", 100);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data written successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    /*
    SELECT
        session_id,
        net_transport,
        client_net_address,
        local_net_address
    FROM
        sys.dm_exec_connections
    WHERE
        session_id = @@SPID;

    */
    private static void Test()
    {
        SqlConnection conn = new SqlConnection("Server=tcp:localhost;Database=aa;User Id=sa;Password=james@2025;TrustServerCertificate=True;");
        var cmd = new SqlCommand(@"
                      SELECT net_transport
                      FROM sys.dm_exec_connections
                      WHERE session_id = @@SPID", conn);
        try
        {
            conn.Open();
            string protocol = (string)cmd.ExecuteScalar();
            Console.WriteLine("Protocol used: " + protocol);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private static void Main(string[] args)
    {
        // WriteJson();
        // ReadJson();
        // ConnectDatabase();
        // ReadFromDatabase();
        // WriteToDatabase();
        Test();
    }
}
