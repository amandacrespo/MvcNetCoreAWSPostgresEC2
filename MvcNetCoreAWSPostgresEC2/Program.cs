using Microsoft.EntityFrameworkCore;
using MvcNetCoreAWSPostgresEC2.Data;
using MvcNetCoreAWSPostgresEC2.Repositories;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("Postgres");
builder.Services.AddDbContext<HospitalContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddTransient<RepositoryHospital>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Departamentos}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
