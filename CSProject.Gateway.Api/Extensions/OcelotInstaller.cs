using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Provider.Consul;

namespace CSProject.Gateway.Api.Extensions
{
    public class OcelotInstaller : IInstaller
    {
        public void Configure(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddOcelot(configuration).AddConsul();
        }
    }
}
