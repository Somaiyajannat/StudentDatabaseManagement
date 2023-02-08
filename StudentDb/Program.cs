using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentDb.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connectionString = builder.Configuration.GetConnectionString("StudentDb");
builder.Services.AddDbContext<StudentDbContext>(e =>e.UseSqlServer(connectionString));
builder.Services.AddDbContext<CourseDbContext>(e => e.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
