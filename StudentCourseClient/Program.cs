using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using DataLayer.Interfaces;
using DataLayer.Models;
using ServiceLayer.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StudentCourseContext>(options =>
{
    options.UseLazyLoadingProxies();
    options.UseSqlServer("Server=DESKTOP-ERV6E6M\\SQLEXPRESSGROUP;Database=StudentCourse;Trusted_Connection=True;TrustServerCertificate=True");
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<CourseService>();

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
    pattern: "{controller=Student}/{action=Index}/{id?}");


app.Run();
