using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Entities;
using OuterrimRepository;
using View.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<OuterrimContext>(options =>
{
    options.UseSqlite("Data Source=database.db", sqLiteOptions =>
    {
        sqLiteOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
    });
});

builder.Services.AddScoped<IRepository<CrimeSyndicate>, OuterrimRepository<CrimeSyndicate>>();
builder.Services.AddScoped<IRepository<Aircraft>, OuterrimRepository<Aircraft>>();
builder.Services.AddScoped<IRepository<AircraftCrew>, OuterrimRepository<AircraftCrew>>();
builder.Services.AddScoped<IRepository<Mercenary>, OuterrimRepository<Mercenary>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();