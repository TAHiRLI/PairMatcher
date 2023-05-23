using PairMatcher.DAL;
using Microsoft.EntityFrameworkCore;
using PairMatcher.Models;
using Microsoft.AspNetCore.Identity;


// Content
//
// 1. Database
// 2. Identity

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


// 1. Database
builder.Services.AddDbContext<PairMatcherDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});

// 2. Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 5;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = false;
}).AddDefaultTokenProviders().AddEntityFrameworkStores<PairMatcherDbContext>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
