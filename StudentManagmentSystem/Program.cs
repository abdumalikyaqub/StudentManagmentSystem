using Microsoft.EntityFrameworkCore;
using StudentManagmentSystem.Models;
using StudentManagmentSystem.Models.Repositories.Implementation;
using StudentManagmentSystem.Models.Repositories.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connection));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IDactyloscopyRepository, DactyloscopyRepository>();
builder.Services.AddScoped<IEducationRepository, EducationRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//app.MapControllerRoute(
//    name: "Reports",
//    pattern: "Student/GeneratePdfReport",
//    defaults: new { controller = "Student", action = "GeneratePdfReport" }
//);

app.Run();
