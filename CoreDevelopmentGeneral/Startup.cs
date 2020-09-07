using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CoreDevelopmentApp.Data.DB;
using CoreDevelopmentApp.Data.Repository;

namespace CoreDevelopmentGeneral
{
    public class Startup
    {
        // Добавляем конфигурацию через конструктор
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // Добавляем переменную для хранения данных конфигурации только GET
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Добавляем приязку представлений приложения к контроллерам (MVC)
            services.AddControllersWithViews();

            services.AddEntityFrameworkSqlServer();

            // Добавляем зависимость базы
            services.AddDbContext<AppDbContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("DBConn"));
            });

            // Добавляем зависимость постраничной навигации
            
            
            // Добавляем зависимость репозитория
            services.AddScoped<IRepository, SQLRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Добавляем статические файлы
            app.UseStaticFiles();

            // Добаляем переадресацию с HTTP на HTTPS
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Изменить маршруты
                endpoints.MapControllerRoute
                (
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            });
        }
    }
}
