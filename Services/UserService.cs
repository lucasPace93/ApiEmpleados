
using EmployedProyect.Controllers;
using EmployedProyect.Models;
using EmployedProyect.database;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployedProyect.Services;

public class UserService : IUserService
{
    UserContext context;
    public UserService(UserContext dbContext)
    {
        context = dbContext;
    }
    public IEnumerable<User> Get()
    {
        return context.UserDb;
    }
    public IEnumerable<User> GetUserById(Guid id)
    {
        var UsuarioActual = context.UserDb.Find(id);
        //if (UsuarioActual != null) return context.UserDb;
        return context.UserDb;
    }

    /*public async Task GetUser(Guid id)
    {
        var GetUsuario = context.UserDb.Find(id);
        if (GetUsuario != null)
        {
            GetUsuario.Name = usuario.Name;
            GetUsuario.Surname = usuario.Surname;
            GetUsuario.UserId = usuario.UserId;
            GetUsuario.UserCategory = usuario.UserCategory;
        }
        await context.SaveChangesAsync();
    }*/
    public async Task Save(User usuario)
    {
        var NewUser = context.UserDb.Add(usuario);
        await context.SaveChangesAsync();
    }
    public async Task Update(Guid id, User usuario)
    {
        var UsuarioActual = context.UserDb.Find(id);

        if (UsuarioActual != null)
        {
            UsuarioActual.Name = usuario.Name;
            UsuarioActual.Surname = usuario.Surname;
            UsuarioActual.UserCategory = usuario.UserCategory;

            await context.SaveChangesAsync();
        }
    }
    public async Task Delete(Guid id)
    {
        var UsuarioActual = context.UserDb.Find(id);
        if (UsuarioActual != null)
        {
            context.Remove(UsuarioActual);
            await context.SaveChangesAsync();
        }
    }
}
public interface IUserService
{
    IEnumerable<User> Get();
    IEnumerable<User> GetUserById(Guid id);
    Task Save(User Usuario);
    Task Update(Guid id, User usuario);
    Task Delete(Guid id);
};