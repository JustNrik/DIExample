Imports System.Data.SqlClient
<Service>
Public Class DatabaseService
    Private Connection As SqlConnection ' You can either declare this private field or make it a public property.

    Sub New(Connection As SqlConnection) ' You don't need a constructor if the variable is a public property.
        Me.Connection = Connection ' In order for this to work, you must AddTrasient(New SqlConnection)
    End Sub

    Public Sub Initialise()
        ' Add your logic for initialisation here
        Console.WriteLine("Database service has been initialised.")
    End Sub
End Class
