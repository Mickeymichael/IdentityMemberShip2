using IdentityMemberShip.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContextPool<CLSDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("con")));

builder .Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<CLSDbContext>();

builder.Services.Configure<IdentityOptions>(op =>
{
    op.Password.RequiredLength = 6;
    op.Password.RequireUppercase = false;
    op.Password.RequireNonAlphanumeric = true;
    op.Password.RequireLowercase= false;
    op.Password.RequireDigit = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();




app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
