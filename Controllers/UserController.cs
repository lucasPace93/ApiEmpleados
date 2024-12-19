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
    User usuario;
    Sucursal branch;
    public UserController userController { get; set; }

    public UserController(ILogger<UserController> logger, IUserService service, UserContext db)
    {
        _logger = logger;
        userService = service;
    }

    [HttpGet("/{id}")]
    [Route("/Employee")]
    public IActionResult Get()
    {
        userService.Get();
        _logger.LogInformation("Mostrando lista de empleados");
        return Ok(/*ListaUsuario*/);
    }

    [HttpGet]
    [Route("/Employee/{Id}")]
    public IActionResult GetUserById(Guid Id)
    {
        userService.GetUserById(Id);
        _logger.LogInformation("Mostrando usuario solicitado");
        if (usuario.UserId == Id)   //Lucas: me dijiste que esta logica debe estar en UserService, pero en el service no puedo usar los codigos http 
            return Ok();
        else return NotFound("El id del empleado no existe o es incorrecto");
    }

    [HttpGet("sucursal/{BranchId}")]
    public IActionResult GetUserByBranch(Guid id)
    {
        userService.GetUserByBranch(id);
        _logger.LogInformation("mostrando lista de empleados de la sucursal seleccionada");
        if (branch.BranchId == id)
            return Ok();
        else return BadRequest("id de la sucursal no existe o es incorrecto");
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
