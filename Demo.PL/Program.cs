using Demo.BLL.Profiles;
using Demo.BLL.Services.DepartmentServices;
using Demo.BLL.Services.EmployeeServices;
using Demo.DAL.Data.DbContex;
using Demo.DAL.Data.Repostitories.EntityTypes;
using Demo.DAL.Data.Repostitories.NoUsedRepo.Departments;
using Demo.DAL.Data.Repostitories.NoUsedRepo.Employees;
using Demo.DAL.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore;

namespace Demo.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region Services Container
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //builder.Services.AddScoped<DepartmentRepostiory>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddScoped<IDepartmentRepostiory, DepartmentRepostiory>();
            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            builder.Services.AddScoped<IEntityTypeRepo<Employee>, EmployeeRepo>();
            builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfile()));
            #endregion

            var app = builder.Build();

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

            #region HTTP Request Pipeline
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion



            #region RUN
            app.Run();
            #endregion
        }
    }
}
