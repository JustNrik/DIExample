using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace DIExample
{
    class Program
    {
        private const string ConnectionString = "Some connection string"; // You may load it from a json/xml file, or an environment variable.
        async void Main()
        {
                // Initialise a ServiceCollection
                var serviceCollection = new ServiceCollection();
                // Add a Singleton to each object you want to inject in your services
                serviceCollection.AddSingleton(new SqlConnection(ConnectionString));
                // I do this for ease, I can tag all my services with a custom attribute so their are easier to pick up
                var services = AppDomain.CurrentDomain.GetAssemblies().
                SelectMany(x => x.GetTypes()).
                Where(y => y.GetCustomAttributes(typeof(ServiceAttribute), true).Length > 0); // This filters them for ServiceAttribute

                foreach (var service in services)
                    serviceCollection.AddSingleton(service);// Otherwise you must add a singleton for each service manually

                // Here we have the provider, we've just injected out services and we are ready to use them.
                var servicePrivider = serviceCollection.BuildServiceProvider();
                // Let's initialise them!
                await servicePrivider.GetService<StartupService>().InitialiseAsync();
        }
    }
}
