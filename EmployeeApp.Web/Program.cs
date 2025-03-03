using EmployeeData.Consumer;
using EmployeeData.Interfaces;
using EmployeeBusiness.Interfaces;
using EmployeeBusiness.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddScoped<IEmployeeConsumer, EmployeeConsumer>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddControllersWithViews();


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
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
