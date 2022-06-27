using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using lab_2._5.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<lab_2_5Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("lab_2_5Context") ?? throw new InvalidOperationException("Connection string 'lab_2_5Context' not found.")));

builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "Quiz.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(180);
    options.Cookie.IsEssential = true;
}) ;

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Mockups/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();