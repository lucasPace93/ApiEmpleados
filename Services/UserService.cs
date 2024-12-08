
using EmployedProyect.Controllers;
using EmployedProyect.Models;
using EmployedProyect.database;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        return context.Users.AsNoTracking().ToList();
    }
    public IEnumerable<User> GetUserById(Guid id)
    {

        var UsuarioActual = context.Users.FirstOrDefault(e => (e.UserId == id));
        if (UsuarioActual != null)
        {
            context.SaveChangesAsync();
            return context.Users.Where(e => e.UserId == id).ToList();
        }
        else return null;  //el HTTP NOT FOUND va en el controller pero como lo armo aca? 
    }

    public async Task Save(User usuario)
    {
        var NewUser = context.Users.AddAsync(usuario);
        await context.SaveChangesAsync();
    }
    public async Task Update(Guid id, User usuario)
    {
        var UsuarioActual = context.Users.Find(id);

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
        var UsuarioActual = context.Users.Find(id);
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