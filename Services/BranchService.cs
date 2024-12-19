
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

public class BranchService //: IBranchService
{
    UserContext context;
    public BranchService(UserContext dbContext)
    {
        context = dbContext;
    }
    public IEnumerable<Sucursal> Get()
    {
        return context.Branches.AsNoTracking().ToList();    //Branches, es el dbset en UserContext
    }

    public IEnumerable<Sucursal> GetUserById(Guid id)
    {

        var UsuarioActual = context.Users.FirstOrDefault(e => (e.UserId == id));
        if (UsuarioActual != null)
        {
            context.SaveChangesAsync();
            return context.Branches.Where(e => e.BranchId == id).ToList();
        }
        else return null;  //el HTTP NOT FOUND va en el controller pero como lo armo aca? 
    }
    /*public async Task Save(Sucursal sucursal)
    {
        var NewUser = context.Users.AddAsync(sucursal);
        await context.SaveChangesAsync();
    }*/

    /*public async Task Update(Guid id, Sucursal sucursal)
    {
        var UsuarioActual = context.Users.Find(id);

        if (UsuarioActual != null)
        {
            UsuarioActual.Name = usuario.Name;
            UsuarioActual.Surname = usuario.Surname;
            UsuarioActual.UserCategory = usuario.UserCategory;

            await context.SaveChangesAsync();
        }
    }*/
    /*public async Task Delete(Guid id)
    {
        var UsuarioActual = context.Users.Find(id);
        if (UsuarioActual != null)
        {
            context.Remove(UsuarioActual);
            await context.SaveChangesAsync();
        }
    }*/
}

public interface IBranchService
{
    IEnumerable<Sucursal> Get();
    IEnumerable<Sucursal> GetUserById(Guid id);
    Task Save(Sucursal sucursal);
    Task Update(Guid id, Sucursal sucursal);
    Task Delete(Guid id);
};


