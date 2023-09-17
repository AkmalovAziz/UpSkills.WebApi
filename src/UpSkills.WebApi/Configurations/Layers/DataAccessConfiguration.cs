using UpSkills.DataAccess.Interfaces.Categories;
using UpSkills.DataAccess.Interfaces.Courses;
using UpSkills.DataAccess.Interfaces.Orders;
using UpSkills.DataAccess.Interfaces.Users;
using UpSkills.DataAccess.Interfaces.Videos;
using UpSkills.DataAccess.Repositories.Categories;
using UpSkills.DataAccess.Repositories.Courses;
using UpSkills.DataAccess.Repositories.Orders;
using UpSkills.DataAccess.Repositories.Users;
using UpSkills.DataAccess.Repositories.Videos;

namespace UpSkills.WebApi.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        //DI contener
        builder.Services.AddScoped<ICoursRepository, CourseRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IVideoRepository, VideoRepository>();
    }
}