using LibraryMvc.Core.IdentityEntities;
using LibraryMvc.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);



//Configuring database connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});



// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();



//Identity
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireDigit = true;

}).AddEntityFrameworkStores<ApplicationDbContext>()
  .AddDefaultTokenProviders()
  .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>()
  .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>();

//-----------------------------------Build App---------------------------------------------------------
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
