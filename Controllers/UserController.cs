using EmployedProyect.Models;
using EmployedProyect.Services;
using Microsoft.AspNetCore.Http.HttpResults;

//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace EmployedProyect.Controllers;

[ApiController]
[Route("/Employee")]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    IUserService userService;
    public UserController(ILogger<UserController> logger, IUserService service)
    {
        _logger = logger;
        userService = service;
    }

    [HttpGet(Name = "Lista de empleados")]
    public IActionResult Get()
    {
        _logger.LogInformation("Mostrando lista de empleados");
        return Ok("lista de empleados en pantalla");
    }

    [HttpGet(Name = "Un Empleado")]
    [Route("/Employee/{UserId}")]
    public IActionResult Get(Guid UserId, [FromBody] User user)
    {
        _logger.LogInformation("Mostrando usuario solicitado");
        return Ok($"Empleado {user.Name} {user.Surname} en pantalla");
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
    public IActionResult Delete([FromBody] Guid UserId)
    {
        userService.Delete(UserId);
        return Ok("usuario eliminado");
    }
}