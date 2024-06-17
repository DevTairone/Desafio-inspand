using Domain.IoC;
using Infrastructure;
using WebApp.Configuration;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


services.AddControllersWithViews();
services.AddInfrastructure(builder.Configuration);
services.AddDomain(builder.Configuration);
services.AddAutoMapperConfiguration();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();



app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();