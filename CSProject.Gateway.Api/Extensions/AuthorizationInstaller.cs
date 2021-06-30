using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using System.Text;

namespace CSProject.Gateway.Api.Extensions
{
    public class AuthorizationInstaller : IInstaller
    {
        public void Configure(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            configuration.GetSection("GatewayOptions");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidateIssuer = true,
                ValidIssuer = "Arden",
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("Authentication")["Secret"])),
                ValidateActor = false,
                RequireSignedTokens = true,
                RequireExpirationTime = false
            };

            serviceCollection.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = "TestKey";
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer("TestKey", x =>
            {
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = tokenValidationParameters;
            });
        }
    }
}
