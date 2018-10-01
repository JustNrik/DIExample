using DIExample;
using System;
using System.Data.SqlClient;

[Service]
public class DatabaseService
{
    private readonly SqlConnection _connection; // You can either declare this private field or make it a public property.

    public DatabaseService(SqlConnection connection) // You don't need a constructor if the variable is a public property.
        => _connection = connection; // In order for this to work, you must AddTrasient(New SqlConnection)

    public void Initialise()
    {
        // Add your logic for initialisation here
        Console.WriteLine("Database service has been initialised.");
    }
}
