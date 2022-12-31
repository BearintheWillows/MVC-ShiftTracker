using Microsoft.EntityFrameworkCore;
using Serilog;
using ShiftTracker.Data;

var builder = WebApplication.CreateBuilder( args );


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>( options =>
	options.UseSqlServer( builder.Configuration.GetConnectionString( "DefaultConnection" ) ) );

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
	name: "Areas",
	pattern: "{area:exist}/{controller=Home}/{action=Index}/{id?}" );

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.Run();