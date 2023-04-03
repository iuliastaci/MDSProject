using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MDSProject.Data;
using MDSProject.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MDSProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MDSProjectContext") ?? throw new InvalidOperationException("Connection string 'MDSProjectContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedDataClients.Initialize(services);
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedDataDestinations.Initialize(services);
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedDataHotels.Initialize(services);
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedDataFlights.Initialize(services);
}

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
