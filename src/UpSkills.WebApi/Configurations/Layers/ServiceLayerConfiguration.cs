using System.Security.Principal;
using UpSkills.Service.Interfaces.Auth;
using UpSkills.Service.Interfaces.Categories;
using UpSkills.Service.Interfaces.Commons;
using UpSkills.Service.Interfaces.Courses;
using UpSkills.Service.Interfaces.Notifications;
using UpSkills.Service.Interfaces.Orders;
using UpSkills.Service.Interfaces.Users;
using UpSkills.Service.Service.Auth;
using UpSkills.Service.Service.Categories;
using UpSkills.Service.Service.Commons;
using UpSkills.Service.Service.Courses;
using UpSkills.Service.Service.Notifications;
using UpSkills.Service.Service.Orders;
using UpSkills.Service.Service.Users;

namespace UpSkills.WebApi.Configurations.Layers;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IIdentityService, IdentityService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<IEmailSMSSender, EmailSMSSender>();
        builder.Services.AddScoped<IPaginator, Paginator>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<ICourseService, CourseService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IOrderService, OrderService>();
    }
}