

using EmployedProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployedProyect.database;

public class UserContext : DbContext
{
    #region tabla en db
    public DbSet<User> UserDb { get; set; }
    public UserContext(DbContextOptions<UserContext> options) : base(options) { }
    #endregion

    #region propiedades de las tablas

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<User> UserInit = new List<User>();
        UserInit.Add(new User("Lucas", "Pace",new Guid(), Category.Employee));
        UserInit.Add(new User("Flor", "Escalante",new Guid(), Category.Employee));
        UserInit.Add(new User("Lucifer", "Pace", new Guid(), Category.Employee));
        UserInit.Add(new User("Hector", "Pace", new Guid(), Category.Employee));

        modelBuilder.Entity<User>(user =>
        {
            user.HasData(UserInit);
            user.ToTable("Usuario");
            user.HasKey(p=> p.UserId);
            user.Property(p=> p.Name).IsRequired();
            user.Property(p=> p.Surname).IsRequired();
            user.Property(p =>p.UserCategory).IsRequired();
        });
    }
    #endregion
}