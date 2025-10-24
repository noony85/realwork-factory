using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using realwork.Data;
using realwork.Localization;

namespace realwork.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, string connectionString, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // 리소스 경로 지정
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            // SharedLocalizer 등록 (프로젝트 요구에 따라 Singleton/Scoped 변경 가능)
            services.AddSingleton<SharedLocalizer>();

            services.AddRazorPages();

            return services;
        }
    }
}