using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EmployedProyect.database;
using EmployedProyect.Models;
using EmployedProyect.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployedProyect.Controllers;

[ApiController]
//[Route("/Employee")]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    IUserService userService;
    UserContext dbContext;

    User usuario;
    private List<User> ListaUsuario = new List<User>()
    {
        new("Lucas", "Pace", Guid.NewGuid() , Category.Employee),
        new("Florencia","Escalante",Guid.NewGuid(),Category.Employee),
        new("Lucifer","Pace",Guid.NewGuid(),Category.Boss),
        new("Hector","Pace", Guid.NewGuid(), Category.Employee) //Category.Employee)
    };
//ListaEmpleado.Add("Lucas", "Pace", Category.Employee);Quotas quotas = new Quotas();Quotas quotas = new Quotas();

public UserController(ILogger<UserController> logger, IUserService service, UserContext db)
{
    _logger = logger;
    userService = service;
    dbContext = db;
}

[HttpGet]
[Route("create DB")]
public IActionResult CreateDatabase()
{
    dbContext.Database.EnsureCreated();
    return Ok("db successfully created");
}
[HttpGet(Name = "Lista de empleados")]
[Route("/Employee")]
public IActionResult Get()
{
    userService.Get();
    _logger.LogInformation("Mostrando lista de empleados");
    return Ok(ListaUsuario);
}

[HttpGet(Name = "Un Empleado")]
[Route("/Employee/{Id}")]
public IActionResult GetUserById(Guid Id)
{
    var Employee = ListaUsuario.FirstOrDefault(e => (e.UserId == Id));
    if (Employee == null) return NotFound("Empleado no encontrado");
    _logger.LogInformation("Mostrando usuario solicitado");
    return Ok(Employee);
}

[HttpPost]
[Route("/Employees")]
public IActionResult Post([FromBody] User usuario)
{
    userService.Save(usuario);
    _logger.LogInformation("usuario creado");
    return Created();
}

[HttpDelete("{UserId}")]
[Route("Employee/{UserId}")]
public IActionResult Delete([FromBody] Guid UserId)
{
    userService.Delete(UserId);
    return Ok("usuario eliminado");
}
}