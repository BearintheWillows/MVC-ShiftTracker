using Microsoft.EntityFrameworkCore;
using Serilog;
using ShiftTracker.Data;
using ShiftTracker.Services;

var builder = WebApplication.CreateBuilder( args );


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowSpecificOrigin",
	                  builder => builder.WithOrigins("http://localhost:44392"));
});

builder.Services.AddDbContext<ApplicationDbContext>( options =>
	options.UseSqlServer( builder.Configuration.GetConnectionString( "DefaultConnection" ) ) );

builder.Services.AddScoped<IShopService, ShopService>();

Log.Logger = new LoggerConfiguration()
            .WriteTo.File( 
	             "log-.txt", 
	             rollingInterval: RollingInterval.Day,
	             outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
             ).CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( !app.Environment.IsDevelopment() )
{
	app.UseExceptionHandler( "/Error" );

	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();


app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
	name: "Areas",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}" );

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.Run();