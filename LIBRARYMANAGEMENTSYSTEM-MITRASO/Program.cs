using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LIBRARYMANAGEMENTSYSTEM_MITRASO.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LIBRARYMANAGEMENTSYSTEM_MITRASOContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LIBRARYMANAGEMENTSYSTEM_MITRASOContext") ?? throw new InvalidOperationException("Connection string 'LIBRARYMANAGEMENTSYSTEM_MITRASOContext' not found.")));

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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=LoginView}/{id?}");

app.Run();
