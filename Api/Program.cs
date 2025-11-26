using Application;
using Application.Middlewares;
using Infrastructure.Data;
using Infrastructure.Dependecies;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// connection to SQL server
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conStr"));
});

#region add dependecies
builder.Services
    .AddRepositoriesDependencies()
    .AddApplicationDependencies();
#endregion

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();



app.MapControllers();


app.Run();
