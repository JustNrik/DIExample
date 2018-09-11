using DIExample;
using System;
using System.Data.SqlClient;

[Service]
public class DatabaseService
{
    private SqlConnection Connection; // You can either declare this private field or make it a public property.

    public DatabaseService(SqlConnection Connection) // You don't need a constructor if the variable is a public property.
        => this.Connection = Connection; // In order for this to work, you must AddSingleton(New SqlConnection)

    public void Initialise()
    {
        // Add your logic for initialisation here
        Console.WriteLine("Database service has been initialised.");
    }
}
