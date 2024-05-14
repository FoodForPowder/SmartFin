using System.Diagnostics.Metrics;
using SmartFin.Controllers;
using SmartFin.Db;
using SmartFin.Entities;
using SmartFin.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SmartFinDbContext>();
builder.Services.AddSingleton<FinanceService>();
builder.Services.AddControllers(
    options => options.SuppressAsyncSuffixInActionNames = false

);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers() .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
name: "default",
pattern: "{controller}/{action=Index}/{id?}");

app.Run();