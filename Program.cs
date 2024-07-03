using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using secDockerApp.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SchoolContext>(Options=>Options.UseNpgsql(builder.Configuration.GetConnectionString("SchoolContext")));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
var services = scope.ServiceProvider;
try
{
// add 10 seconds delay to ensure the db server is up to accept connections
// this won't be needed in real world application
System.Threading.Thread.Sleep(10000);
var context = services.GetRequiredService<SchoolContext>();
var created = context.Database.EnsureCreated();
 
}
catch (Exception ex)
{
//var logger = services.GetRequiredService<ILogger,Program>();
//logger.LogError(ex, "An error occurred creating the DB.");
}
}
// Configre the Http request pipeline.
if(!app.Environment.IsDevelopment())
app.UseExceptionHandler("/Error");

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
