
using EmployedProyect.Controllers;
using EmployedProyect.Models;
using EmployedProyect.database;

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
    public async Task Save(User usuario)
    {
        context.Add(usuario);
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
    Task Save(User Usuario);
    Task Update(Guid id, User Usiario);
    Task Delete(Guid id);
};