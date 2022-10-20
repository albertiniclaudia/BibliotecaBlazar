using BibliotecaProject.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BibliotecaDbContext>(options => options.UseSqlServer(

    builder.Configuration.GetConnectionString("DefaultConnection")

));
builder.Services.AddDistributedMemoryCache();
//ConfigureServices
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(s => s.IdleTimeout = TimeSpan.FromMinutes(30));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCookiePolicy();
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
