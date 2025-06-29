# write json

```csharp
class Setting
{
    public string? ConnectionString { get; set; }
}

Setting s = new Setting(){
    ConnectionString = "Server=localhost;Database=MyDatabase;User Id=sa;Password=MyPassword;"
};
string json = JsonSerializer.Serialize(s);
File.WriteAllText("settings.json", json);

```

# read json

```csharp
string json = File.ReadAllText("settings.json");
Setting? s = JsonSerializer.Deserialize<Setting>(json);
Console.WriteLine(s?.ConnectionString);
```

# database connection

```csharp
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
```

# read from database

```csharp
SqlConnection conn = new SqlConnection("Server=localhost;Database=aa;User Id=sa;Password=james@2025;TrustServerCertificate=True;");
SqlCommand cmd = new SqlCommand("SELECT * FROM products WHERE price <= 30", conn);

try{
    conn.Open();
    SqlDataReader dr = cmd.ExecuteReader();
    while (dr.Read())
    {
        Console.WriteLine(dr["price"]);
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

# write to databasae

```csharp
SqlConnection conn = new SqlConnection("Server=localhost;Database=aa;User Id=sa;Password=james@2025;TrustServerCertificate=True;");
SqlCommand cmd = new SqlCommand("AddProducts", conn);
cmd.CommandType = System.Data.CommandType.StoredProcedure;
try{
    conn.Open();
    cmd.Parameters.AddWithValue("@price", 100);
    cmd.ExecuteNonQuery();
    Console.WriteLine("Data written successfully.");
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
```
