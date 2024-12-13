using EmployedProyect.Models;
using EmployedProyect.Services;
using EmployedProyect.Controllers;
using EmployedProyect.database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//inyeccion de dependencias
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSqlServer<UserContext>(builder.Configuration.GetConnectionString("cnUser"));
builder.Services.AddDbContext<UserContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cnUser"));
});

//inyeccion de dependencias
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

//MIDDLEWARES :
app.UseUserInitializer();


app.MapGet("/GetUser", () => "Hello World"); //modificar



app.MapGet("/dbconexion", ([FromServices] UserService Services) =>
{
    return Results.Ok("Base de datos");
});

//app.MapControllers();
app.Run();