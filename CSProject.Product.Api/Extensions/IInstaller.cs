using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CSProject.Product.Api.Extensions
{
    public interface IInstaller
    {
        void Configure(IServiceCollection serviceCollection, IConfiguration configuration);
    }
}
