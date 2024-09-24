//using Company.Electronics.BLL.Repositories;
//using Company.Electronics.DAL.Data.Contexts;
//using Microsoft.EntityFrameworkCore;

//namespace Company.Electronics
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            // Add services to the container.
//            builder.Services.AddControllersWithViews();
//           // builder.Services.AddScoped<AppDBContext>();
//            builder.Services.AddDbContext<AppDBContext>(options => 
//            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
//            );

//            builder.Services.AddScoped<DepartmentRepository>();


//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (!app.Environment.IsDevelopment())
//            {
//                app.UseExceptionHandler("/Home/Error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();

//            app.UseRouting();

//            app.UseAuthorization();

//            app.MapControllerRoute(
//                name: "default",
//                pattern: "{controller=Home}/{action=Index}/{id?}");

//            app.Run();
//        }
//    }
//}


using Company.Electronics.BLL.Interfaces;
using Company.Electronics.BLL.Repositories;
using Company.Electronics.DAL.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Company.Electronics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            builder.Services.AddScoped<DepartmentRepository>();
            builder.Services.AddScoped<EmployeeRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();



            // listen video of refactoring
        }
    }
}

