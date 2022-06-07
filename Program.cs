using InAndOut.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
    );
builder.Services.AddControllersWithViews();

    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();  //Middleware
app.UseStaticFiles();       //Middleware -- uses wwwroot files

app.UseRouting();           //Middleware -- define which endpoint will be used eg MVC, SignalR

app.UseAuthorization();     //Middleware

app.MapControllerRoute(                                         //AKA endpoints or routing
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");         //localhost:9099/Home/Index

app.Run();
