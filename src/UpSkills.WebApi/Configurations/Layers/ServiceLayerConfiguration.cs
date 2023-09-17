using System.Security.Principal;
using UpSkills.Service.Interfaces.Auth;
using UpSkills.Service.Interfaces.Commons;
using UpSkills.Service.Interfaces.Courses;
using UpSkills.Service.Service.Auth;
using UpSkills.Service.Service.Commons;

namespace UpSkills.WebApi.Configurations.Layers;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IIdentityService, IdentityService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<IPaginator, Paginator>();
    }
}