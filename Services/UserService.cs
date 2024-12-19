using EmployedProyect.Models;
using EmployedProyect.database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

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
    /*public IEnumerable<User> GetUserById(Guid id)
    {

        var UsuarioActual = context.Users.FirstOrDefault(e => (e.UserId == id));
        if (UsuarioActual != null)
        {
            context.SaveChangesAsync();
            return context.Users.Where(e => e.UserId == id).ToList();
        }
        else return null;
                            //el HTTP NOT FOUND va en el controller pero como lo armo aca? 
    }*/

    public async Task <User> GetUserById(Guid id)       //encontre esta otra manera de escribir el GetUserById, 
    {
        await context.SaveChangesAsync();
        return await context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetUserByBranch(Guid id)
    {
        return await context.Users
            .Where(e => e.BranchId == id)
            .ToListAsync();
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
    //IEnumerable<User> GetUserById(Guid id);   lo comento para poder usar el Task de abajo
    Task<User> GetUserById(Guid id);
    Task<IEnumerable<User>> GetUserByBranch(Guid id); // encontre esta otra manera de utilizar el task, que cambia? 
    Task Save(User Usuario);
    Task Update(Guid id, User usuario);
    Task Delete(Guid id);
};