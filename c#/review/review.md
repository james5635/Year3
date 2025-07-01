# File Operations
## Checking if a file exists
```csharp
string filePath = "test.txt";
if (File.Exists(filePath))
{
    Console.WriteLine("File exists.");
}
else
{
    Console.WriteLine("File does not exist.");
}
```
## Creating a new file
```csharp
string filePath = "example.txt";
File.Create(filePath).Close();
Console.WriteLine("File created successfully.");
```
## Deleting an existing file
```csharp
if (File.Exists(filePath))
{
    File.Delete(filePath);
    Console.WriteLine("File deleted successfully.");
}
```
## Creating a new directory
```csharp
string path = "MyFolder";
if (!Directory.Exists(path))
{
    Directory.CreateDirectory(path);
    Console.WriteLine($"Directory '{path}' created successfully.");
}
else
{
    Console.WriteLine("Directory already exists.");
}
```
## Checking an existing directory
```csharp
if (Directory.Exists("MyFolder"))
{
    Console.WriteLine("Directory exists.");
}
else
{
    Console.WriteLine("Directory does not exist.");
}
```
## Moving an existing directory
```csharp
string sourcePath = "MyFolder";
string destPath = "NewFolder";
if (Directory.Exists(sourcePath))
{
    Directory.Move(sourcePath, destPath);
    Console.WriteLine("Directory moved successfully.");
}
```
## Listing all subdirectories
```csharp
string dirPath = "MyFolder";
string[] subDirs = Directory.GetDirectories(dirPath);
foreach (string dir in subDirs)
{
    Console.WriteLine(dir);
}
```
## Getting and setting the current directory
```csharp
string currentDirectory = Directory.GetCurrentDirectory();
Console.WriteLine($"Current Directory: {currentDirectory}");
Directory.SetCurrentDirectory("C:\\Users\\Public");
Console.WriteLine("Current directory changed.");
```
## Getting a parent directory
```csharp
string path = "C:\\Users\\Public";
string parentDir = Directory.GetParent(path).FullName;
Console.WriteLine($"Parent Directory: {parentDir}");
```
## Deleting an existing directory
```csharp
string dirPath = "DelForlder";
if (Directory.Exists(dirPath))
{
    Directory.Delete(dirPath, true); // true removes all contents
    Console.WriteLine("Directory deleted.");
}
```
## Writing a text to file
```csharp
string filePath = "textfile.txt";
string text = "Hello, C# File Handling!";
File.WriteAllText(filePath, text);
Console.WriteLine("Text written successfully.");
```
## Reading text from a file
```csharp
string filePath = "textfile.txt";
if (File.Exists(filePath))
{
    string content = File.ReadAllText("textfile.txt");
    Console.WriteLine("File Content: " + content);
}
```
## Appending text to file
```csharp
string filePath = "textfile.txt";
File.AppendAllText(filePath, "\nAppending more text.");
Console.WriteLine("Text appended successfully.");
```
## Reading a file line by line
```csharp
string filePath = "textfile.txt";
foreach (string line in File.ReadLines(filePath))
{
    Console.WriteLine(line);
}
```
## Writing Binary Data to a File:
```csharp
string filePath = "binaryfile.bin";
byte[] data = { 0x10, 0x20, 0x30, 0x40 };
File.WriteAllBytes(filePath, data);
Console.WriteLine("Binary data written successfully.");
```
## Converting data to byte array and then writing to file
```csharp
string filePath = "data.bin";
string name = "sok dara";
int age = 35;
byte[] nameBytes = Encoding.UTF8.GetBytes(name);
byte[] ageBytes = BitConverter.GetBytes(age);
byte[] nameLengthBytes = BitConverter.GetBytes(nameBytes.Length);
byte[] binaryData = new byte[nameLengthBytes.Length + nameBytes.Length + ageBytes.Length];
Buffer.BlockCopy(nameLengthBytes, 0, binaryData, 0, nameLengthBytes.Length);
Buffer.BlockCopy(nameBytes, 0, binaryData, nameLengthBytes.Length, nameBytes.Length);
Buffer.BlockCopy(ageBytes, 0, binaryData, nameLengthBytes.Length + nameBytes.Length, ageBytes.Length);
File.WriteAllBytes(filePath, binaryData);
```
## Reading byte array from file
```csharp
string filePath = "data.bin";
if (File.Exists(filePath))
{
    byte[] binaryData = File.ReadAllBytes(filePath);
    int offset = 0;
    int nameLength = BitConverter.ToInt32(binaryData, offset);
    offset += sizeof(int);
    string name = Encoding.UTF8.GetString(binaryData, offset, nameLength);
    offset += nameLength;
    int age = BitConverter.ToInt32(binaryData, offset);
    Console.WriteLine($"Name: {name}");
    Console.WriteLine($"Age: {age}");
}
```
## Using BinaryWriter to write data file
```csharp
string filePath = "data.bin";
string name = "sok dara";
int age = 35;
BinaryWriter bw = new BinaryWriter(File.Create(filePath));
bw.Write(name);
bw.Write(age);
bw.Close();
```
## Using BinaryReader to read data from file
```csharp
string filePath = "data.bin";
string name = "";
int age = 0; // Initialize age to a default value
BinaryReader br = new BinaryReader(File.OpenRead(filePath));
name = br.ReadString();
age = br.ReadInt32();
br.Close();
Console.WriteLine($"Name: {name}, Age: {age}"); // Added Console.WriteLine to show results
```
## Writing to file a JSON data representing an anonymous object
```csharp
using System.Text.Json;
// ...
var person = new { Name = "Heng Dara", Age = 30 };
string json = JsonSerializer.Serialize(person);
File.WriteAllText("data.json", json);
Console.WriteLine("JSON data written successfully.");
```
## Reading from file in JSON data and converting to a dictionary
```csharp
using System.Text.Json;
// ...
if (File.Exists("data.json"))
{
    string jsonData = File.ReadAllText("data.json");
    var person = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonData);
    Console.WriteLine("Name: " + person!["Name"]);
    Console.WriteLine("Age: " + person!["Age"]);
}
```
## Using classes for JSON serialization
```csharp
using System.Text.Json;
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
// ...
var personObject = new Person { Name = "Heng Dara", Age = 30 };
string jsonString = JsonSerializer.Serialize(personObject);
File.WriteAllText("person.json", jsonString);
Console.WriteLine("Person data saved as JSON.");
```
## Using classes for JSON deserialization
```csharp
using System.Text.Json;
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
// ...
if (File.Exists("person.json"))
{
    string jsonContent = File.ReadAllText("person.json");
    Person person = JsonSerializer.Deserialize<Person>(jsonContent);
    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
}
```

# Database Access
## Introduction to ADO.NET
ADO.NET provides classes to interact with data sources in .NET.  
Providers contain: Connections, Commands, Parameters, DataAdapters, and DataReaders
```sql
-- Sample Table: students
CREATE TABLE students (
  id VARCHAR(36) PRIMARY KEY,
  firstname NVARCHAR(30),
  lastname NVARCHAR(30),
  gender INT NULL,
  age TINYINT
);

```
## Connecting to Database
### SQL Authentication:
```csharp
string connStr = "data source=.; initial catalog=enrolldb; user id=sa; password=123456; encrypt=false";
SqlConnection conn = new SqlConnection(connStr);
conn.Open();

```
### Windows Authentication:
```csharp
string connStr = "data source=.; initial catalog=enrolldb; trusted_connection=true; encrypt=false";
SqlConnection conn = new SqlConnection(connStr);
conn.Open();

```
## Creating Database & Tables
```csharp
var conn = new SqlConnection("server=localhost; trusted_connection=true; encrypt=false");
conn.Open();

// Create database
var cmd = new SqlCommand("create database enrolldb", conn);
cmd.ExecuteNonQuery();

conn.ChangeDatabase("enrolldb");

// Create table
cmd.CommandText = @"create table courses(
    id varchar(36) primary key,
    code varchar(20) unique not null,
    name nvarchar(30) not null)";
cmd.ExecuteNonQuery();

```
## CRUD Operations
### Create
```csharp
cmd.CommandText = "insert into students values('stu001','nary','heng',0,23)";
cmd.ExecuteNonQuery();

```
### Read
```csharp
cmd.CommandText = "select * from students";
var reader = cmd.ExecuteReader();
while (reader.Read()) {
    Console.WriteLine(reader.GetString(1)); // firstname
}
reader.Close();

```
### Update
```csharp
cmd.CommandText = "update students set firstname='narom' where id='stu001'";
cmd.ExecuteNonQuery();

```
### Delete
```csharp
cmd.CommandText = "delete students where id='stu001'";
cmd.ExecuteNonQuery();

```

## Parameterized Commands
### With Parameters:
```csharp
cmd.CommandText = "select * from students where id=@id";
cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar, 36) {
    Value = "stu001"
});
```
### Stored Procedure:
```sql
CREATE PROCEDURE InsertStudent
  @id varchar(36), @firstname nvarchar(30), @lastname nvarchar(30),
  @gender int, @age tinyint
AS
BEGIN
  INSERT INTO students VALUES(@id, @firstname, @lastname, @gender, @age)
END
```
## DataSet, DataTable, DataColumn, DataRow
```csharp
DataSet ds = new DataSet("dataset1");
SqlDataAdapter da = new SqlDataAdapter("select * from students", conn);
da.Fill(ds);

// DataTable and DataRow
DataTable table = ds.Tables["students"];
DataRow dr = table.NewRow();
dr["id"] = "stu002";
dr["firstname"] = "Sokha";
dr["lastname"] = "Chan";
table.Rows.Add(dr);

```
## Batch Submission using DataAdapter
```csharp
SqlDataAdapter adapter = new SqlDataAdapter("select * from students", conn);
SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
adapter.Fill(ds, "students");

// Submit changes
adapter.Update(ds.Tables["students"]);

```
## DataRelation (Parent-Child Relationship)
```csharp
DataRelation rel = new DataRelation(
    "stu_enroll",
    ds.Tables["students"].Columns["id"],
    ds.Tables["enrollings"].Columns["studentid"]
);
ds.Relations.Add(rel);

```
## DataView & Filtering
```csharp
DataView view = ds.Tables["students"].DefaultView;
view.RowFilter = "age > 30";
view.Sort = "age asc, gender desc";

```
## DataRowView for UI Binding
```csharp
BindingSource bs = new BindingSource();
bs.DataSource = ds.Tables["enrollings"].DefaultView;
DataRowView drv = (DataRowView)bs.Current;
DataRow stuRow = drv.Row.GetParentRow("stu_enroll");
var firstname = stuRow["firstname"];

```