using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjektBDWAI.Areas.Identity.Data;
using ProjektBDWAI.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ProjektBDWAIContextConnection") ?? throw new InvalidOperationException("Connection string 'ProjektBDWAIContextConnection' not found.");;

builder.Services.AddDbContext<ProjektBDWAIContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ProjektBDWAIUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ProjektBDWAIContext>();

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
app.MapRazorPages();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
