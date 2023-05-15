using Microsoft.AspNetCore.Identity;using Microsoft.EntityFrameworkCore;using PROJET.Data;using Microsoft.Extensions.DependencyInjection;using PROJET.Models;var builder = WebApplication.CreateBuilder(args);builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PROJETContext") ?? throw new InvalidOperationException("Connection string 'PROJETContext' not found.")));
builder.Services.AddDbContext<ApplicationDbContext>(options =>    options.UseSqlServer(builder.Configuration.GetConnectionString("PROJETContext") ?? throw new InvalidOperationException("Connection string 'PROJETContext' not found.")));// Add services to the container.var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");builder.Services.AddDbContext<ApplicationDbContext>(options =>    options.UseSqlServer(connectionString));builder.Services.AddDatabaseDeveloperPageExceptionFilter();builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)    .AddEntityFrameworkStores<ApplicationDbContext>();builder.Services.AddControllersWithViews();var app = builder.Build();// Configure the HTTP request pipeline.if (app.Environment.IsDevelopment()){    app.UseMigrationsEndPoint();}else{    app.UseExceptionHandler("/Home/Error");}app.UseStaticFiles();app.UseRouting();app.UseAuthorization();app.MapControllerRoute(    name: "default",    pattern: "{controller=Home}/{action=Index}/{id?}");app.MapRazorPages();
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
   
    context.Database.EnsureCreated();
}




app.Run();