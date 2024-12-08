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
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    IUserService userService;
    public UserController userController {get; set;}
    
public UserController(ILogger<UserController> logger, IUserService service, UserContext db)
{
    _logger = logger;
    userService = service;
}

[HttpGet("/{id}")][Route("/Employee")]
public IActionResult Get()
{
    userService.Get();
    _logger.LogInformation("Mostrando lista de empleados");
    return Ok(/*ListaUsuario*/);
}

[HttpGet][Route("/Employee/{Id}")]
public IActionResult GetUserById(Guid Id)   //esta logica deberia estar en UserService
{
    userService.GetUserById(Id);
    _logger.LogInformation("Mostrando usuario solicitado");
    return Ok();
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
