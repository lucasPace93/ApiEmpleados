using EmployedProyect.Models;
using EmployedProyect.Services;
using EmployedProyect.Controllers;
using EmployedProyect.database;

var builder = WebApplication.CreateBuilder(args);


//inyeccion de dependencias
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inyeccion de dependencias
builder.Services.AddScoped<IUserService,UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
//app.Use[...]Middleware();
app.MapControllers();
app.Run();