using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.DAL.Contexts;
using ProjectManagementSystem.DAL.IRepositories;
using ProjectManagementSystem.DAL.Repositories;
using ProjectManagementSystem.Service.Interfaces;
using ProjectManagementSystem.Service.Mappers;
using ProjectManagementSystem.Service.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//AppDbContext
builder.Services.AddDbContext<AppDbContext>(option
    => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//Logger
var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


//Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//Services
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITeamService, TeamService>();


//AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

/*app.UseMiddleware<ExceptionHandlerMiddleware>();
*/
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
