using Demo.BLL.Profiles;
using Demo.BLL.Services.Attachment_Services;
using Demo.BLL.Services.DepartmentServices;
using Demo.BLL.Services.EmployeeServices;
using Demo.DAL.Data.DbContex;
using Demo.DAL.Data.Repostitories.EntityTypes;
using Demo.DAL.Data.Repostitories.NoUsedRepo.Departments;
using Demo.DAL.Data.Repostitories.NoUsedRepo.Employees;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Models.IDentityModel;
using Microsoft.AspNetCore.Identity;
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
                options.UseLazyLoadingProxies();
            });

            //builder.Services.AddScoped<DepartmentRepostiory>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddScoped<IDepartmentRepostiory, DepartmentRepostiory>();
            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            builder.Services.AddScoped<IEntityTypeRepo<Employee>, EmployeeRepo>();
            builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfile()));
            builder.Services.AddScoped<IAttachmentServices, AttachmentServices>();
            builder.Services.AddIdentity<Application_User, IdentityRole>()
                            .AddEntityFrameworkStores<ApplicationDbContext>();

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
                pattern: "{controller=Account}/{action=Register}/{id?}");
            #endregion



            #region RUN
            app.Run();
            #endregion
        }
    }
}
