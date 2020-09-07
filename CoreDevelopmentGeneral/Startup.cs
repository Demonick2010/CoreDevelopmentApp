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
        // ��������� ������������ ����� �����������
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // ��������� ���������� ��� �������� ������ ������������ ������ GET
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // ��������� ������� ������������� ���������� � ������������ (MVC)
            services.AddControllersWithViews();

            services.AddEntityFrameworkSqlServer();

            // ��������� ����������� ����
            services.AddDbContext<AppDbContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("DBConn"));
            });

            // ��������� ����������� ������������ ���������
            
            
            // ��������� ����������� �����������
            services.AddScoped<IRepository, SQLRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // ��������� ����������� �����
            app.UseStaticFiles();

            // �������� ������������� � HTTP �� HTTPS
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // �������� ��������
                endpoints.MapControllerRoute
                (
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            });
        }
    }
}
