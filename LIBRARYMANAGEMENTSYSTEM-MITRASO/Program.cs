using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using LIBRARYMANAGEMENTSYSTEM_MITRASO.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LIBRARYMANAGEMENTSYSTEM_MITRASOContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LIBRARYMANAGEMENTSYSTEM_MITRASOContext") ?? throw new InvalidOperationException("Connection string 'LIBRARYMANAGEMENTSYSTEM_MITRASOContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option => {
        option.LoginPath = "/Login/LoginView";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20); 
    
    });

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=LoginView}/{id?}");


app.Run();
