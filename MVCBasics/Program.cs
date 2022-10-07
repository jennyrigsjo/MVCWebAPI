using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MVCBasics.Data;
using MVCBasics.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); //Register database context as a service to enable dependency injection
});

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false) // Create service for default identity
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDBContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
});

builder.Services.AddRazorPages();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; // ignore circular references
    //options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull; // ignore all null properties
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyContactsApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.UseCors();


// enforce use of periods as decimal separator
var cultureInfo = new CultureInfo("en-US"); 
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=About}/{id?}" //Add default pattern to enable linking to pages by referencing controller and action names 
    );

app.MapControllerRoute(
    name: "fevercheck",
    pattern: "fevercheck",
    defaults: new { controller = "Doctor", action = "FeverCheck" }
    );

app.MapControllerRoute(
    name: "guessinggame",
    pattern: "guessinggame",
    defaults: new { controller = "GuessNumber", action = "GuessNumber" }
    );

app.Run();
