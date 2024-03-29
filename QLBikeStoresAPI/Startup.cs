using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Interfaces;
using Services.Models;
using Services.XuLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBikeStoresAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(cors =>
            {
                cors.AddPolicy("AllowOrgin", c => c.AllowAnyOrigin());
            });
            services.AddControllers();

            services.AddDbContext<demoContext>();
            services.AddScoped<IXuLyTheLoaiSanPham, XuLyTheLoaiSanPham>();
            services.AddScoped<IXuLySanPham, XuLySanPham>();
            services.AddScoped<IXuLyCuaHang, XuLyCuaHang>();
            services.AddScoped<IXuLyNhanHieu, XuLyNhanHieu>();
            services.AddScoped<IXuLyKhachHang, XuLyKhachHang>();
            services.AddScoped<IXuLyNhanVien, XuLyNhanVien>();
            services.AddScoped<IXuLyKhoHang, XuLyKhoHang>();
            services.AddScoped<IXuLyMuaHang, XuLyMuaHang>();
            services.AddScoped<IXuLyDonDatHang, XuLyDonDatHang>();
            services.AddScoped<IXuLyMenu, XuLyMenu>();
            services.AddScoped<IXuLyQuyen, XuLyQuyen>();
            services.AddScoped<IXuLyLienLac, XuLyLienLac>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(c => c.AllowAnyOrigin());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
