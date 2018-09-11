Imports Microsoft.Extensions.DependencyInjection
<Service>
Public Class StartupService
    Private Services As IServiceProvider

    Sub New(Services As IServiceProvider)
        Me.Services = Services
    End Sub

    Public Async Function InitialiseAsync() As Task ' If you have multiple services, it's good to have a Startup Service
        Services.GetService(Of DatabaseService).Initialise() ' so you can start all of them one by one organized.
        Await Console.Out.WriteLineAsync("All services has been initialised")
        Await Task.Delay(-1) ' This is to avoid the program to finish.
    End Function
End Class
