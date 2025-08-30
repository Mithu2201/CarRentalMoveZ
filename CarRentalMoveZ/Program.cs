using CarRentalMoveZ.Data;
using CarRentalMoveZ.Repository.Implementations;
using CarRentalMoveZ.Repository.Interfaces;
using CarRentalMoveZ.Services.Implementations;
using CarRentalMoveZ.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRentalMoveZ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("CarRentalData")));

            // ?? Register Repositories
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IStaffRepository, StaffRepository>();

            // ?? Register Services
            builder.Services.AddScoped<IRegisterService, RegisterService>();
            builder.Services.AddScoped<ILoginService, LoginService>();


            builder.Services.AddSession();
            var app = builder.Build();
            app.UseSession();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
        }
    }
}
