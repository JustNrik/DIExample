Imports Microsoft.Extensions.DependencyInjection
Imports System.Data.SqlClient
Module Program
    Private Const ConnectionString As String = "Some connection string" ' You may load it from a json/xml file, or an environment variable.

    Sub Main()
        MainAsync.GetAwaiter.GetResult()
    End Sub

    Async Function MainAsync() As Task
        ' Initialise a ServiceCollection
        Dim serviceCollection As New ServiceCollection 
        ' Add a Singleton to each object you want to inject in your services
        serviceCollection.AddTrasient(New SqlConnection(ConnectionString)) 
        ' I do this for ease, I can tag all my services with a custom attribute so their are easier to pick up
        Dim services = AppDomain.CurrentDomain.GetAssemblies(). ' Gets the assemblies of your project
            SelectMany(Function(x) x.GetTypes).
            Where(Function(y) y.GetCustomAttributes(GetType(ServiceAttribute), True).Length > 0) ' This filters them for ServiceAttribute

        For Each service In services
            serviceCollection.AddSingleton(service) 'Otherwise you must add a singleton for each service manually
        ' Like AddSingleton(Of StartupService).AddSingleton(Of DatabaseService).AddSingleton(Of TService).... and so on.
        Next 
            
        ' Here we have the provider, we've just injected out services and we are ready to use them.
        Dim servicePrivider = serviceCollection.BuildServiceProvider 
        ' Let's initialise them!
        Await servicePrivider.GetService(Of StartupService).InitialiseAsync 
    End Function

End Module
