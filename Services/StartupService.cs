using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using DIExample;

[Service]
public class StartupService
{
    private readonly IServiceProvider _services;

    public StartupService(IServiceProvider services)
    {
        _services = Services;
    }

    public async Task InitialiseAsync() // If you have multiple services, it's good to have a Startup Service
    {
        Services.GetService<DatabaseService>().Initialise(); // so you can start all of them one by one organized.
        await Console.Out.WriteLineAsync("All services has been initialised");
        await Task.Delay(-1); // This is to avoid the program to finish.
    }
}
