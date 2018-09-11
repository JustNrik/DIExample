Imports Microsoft.Extensions.DependencyInjection
Imports System.Data.SqlClient
Module Program
    Private Const ConnectionString As String = "Some connection string" ' You may load it from a json/xml file, or an environment variable.

    Sub Main()
        MainAsync.GetAwaiter.GetResult()
    End Sub

    Async Function MainAsync() As Task
        Dim serviceCollection As New ServiceCollection ' Initialise a ServiceCollection
        serviceCollection.AddSingleton(New SqlConnection(ConnectionString)) ' Add a Singleton to each object you want to inject in your services
        Dim services = AppDomain.CurrentDomain.GetAssemblies.SelectMany(Function(x) x.GetTypes).Where(Function(y) y.GetCustomAttributes(GetType(ServiceAttribute), True).Length > 0)
        ' I do this for ease, I can tag all my services with a custom attribute so their are easier to pick up
        For Each service In services
            serviceCollection.AddSingleton(service) 'Otherwise you must add a singleton for each service manually
        Next ' Like AddSingleton(Of StartupService).AddSingleton(Of DatabaseService).AddSingleton(Of TService).... and so on.
        Dim servicePrivider = serviceCollection.BuildServiceProvider ' Here we have the provider, we've just injected out services and we are ready to use them.
        Await servicePrivider.GetService(Of StartupService).InitialiseAsync ' Let's initialise them!
    End Function

End Module
