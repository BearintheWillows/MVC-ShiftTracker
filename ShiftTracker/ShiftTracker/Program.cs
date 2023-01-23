using Microsoft.EntityFrameworkCore;
using Serilog;
using ShiftTracker.Areas.Shifts.Data;
using ShiftTracker.Areas.Shifts.Services;
using ShiftTracker.Data;
using Tailwind;



var builder = WebApplication.CreateBuilder( args );


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddCors( options =>
	{
		options.AddPolicy( "AllowAll", corbuilder =>
		{
			corbuilder.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader();
		} );
	}
);

builder.Services.AddDbContext<ApplicationDbContext>( options =>
	                                                     options.UseSqlServer(
		                                                     builder.Configuration.GetConnectionString(
			                                                     "DefaultConnection"
		                                                     )
	                                                     )
);

builder.Services.AddScoped<IShopService, ShopService>();
builder.Services.AddScoped<IShiftService, ShiftService>();
builder.Services.AddScoped<IBreakService, BreakService>();
builder.Services.AddScoped<IDailyRoutePlanService, DailyRoutePlanService>();
builder.Services.AddScoped<IRunService, RunService>();

Log.Logger = new LoggerConfiguration()
            .WriteTo.File( "log-.txt",
                           rollingInterval: RollingInterval.Day,
                           outputTemplate:
                           "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
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
app.MapControllerRoute( "Areas",
                        "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute( "Default",
                        "{area=Shifts}/{controller=Home}/{action=Index}/{id?}"
);

if ( app.Environment.IsDevelopment() )
{
	app.RunTailwind( "tailwind", "./" );
}
app.MapRazorPages();
app.Run();