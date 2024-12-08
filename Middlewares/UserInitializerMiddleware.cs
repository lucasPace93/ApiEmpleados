
using EmployedProyect.database;
using EmployedProyect.Models;
using Microsoft.EntityFrameworkCore;


public class UserInitializerMiddleware(UserContext dbContext) : IMiddleware
{
    protected RequestDelegate next;

    public async Task InvokeAsync(HttpContext context, RequestDelegate nextRequest)
    {
        next = nextRequest;

        var user = new User("User1", "Surname1", Category.Boss);
        //user.UserCategory.PrintEnum(); armar metodo para imprimir string y no parametro de enum

        await next(context);
        if (!(await dbContext.Users.AnyAsync()))
        {
            await dbContext.Users.AddRangeAsync(new List<User>
            {
                new User ("User1","Surname1",Category.Boss),
                new User ("User2","Surname2",Category.Employee),
                new User ("User3","Surname3",Category.Employee),
                new User ("User4","Surname4",Category.Employee),
                new User ("User5","Surname5",Category.Employee),
                new User ("User6","Surname6",Category.Employee),
                new User ("User7","Surname7",Category.Employee),
            });
        }
    }
}

public static class UserInitializerMiddlewareExtension
{
    public static IApplicationBuilder UseUserInitializer(this IApplicationBuilder builder)
    {
    return builder.UseMiddleware<UserInitializerMiddleware>();
    }
}