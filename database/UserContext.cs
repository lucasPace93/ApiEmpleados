using EmployedProyect.Models;
using Microsoft.EntityFrameworkCore;
namespace EmployedProyect.database;

public class UserContext : DbContext
{
    #region tabla en db
    public DbSet<User> Users { get; set; }
    public DbSet<Sucursal> Branches { get; set; }
    public UserContext(DbContextOptions<UserContext> options) : base(options) { }
    #endregion

    #region propiedades de las tablas

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Datos semilla
        List<User> UserInit = new List<User>();
        UserInit.Add(new User("Lucas", "Pace", Guid.NewGuid(), Category.Employee, BranchName.Central));
        UserInit.Add(new User("Flor", "Escalante", Guid.NewGuid(), Category.Employee, BranchName.Central));
        UserInit.Add(new User("Lucifer", "Pace", Guid.NewGuid(), Category.Employee, BranchName.Central));
        UserInit.Add(new User("Hector", "Pace", Guid.NewGuid(), Category.Employee, BranchName.Sucursal2));

        List<Sucursal> BranchesInit = new List<Sucursal>();
        BranchesInit.Add(new Sucursal(BranchName.Central, Guid.NewGuid()));
        BranchesInit.Add(new Sucursal(BranchName.Sucursal2, Guid.NewGuid()));
        BranchesInit.Add(new Sucursal(BranchName.Sucursal3, Guid.NewGuid()));

        modelBuilder.Entity<User>(user =>
        {
            user.HasData(UserInit);
            user.ToTable("Usuario");
            user.HasKey(p => p.UserId);
            user.Property(p => p.Name).IsRequired();
            user.Property(p => p.Surname).IsRequired();
            user.Property(p => p.UserCategory).IsRequired();
            user.HasOne(p=>p.VBranch).WithMany(p => p.UsersList).HasForeignKey(p=>p.BranchId);
        });

        modelBuilder.Entity<Sucursal>(branch =>
        {
            branch.HasData(BranchesInit);
            branch.ToTable("Sucursales");
            branch.HasKey(p => p.BranchId);
            branch.HasMany(p => p.UsersList).WithOne(p => p.VBranch).HasForeignKey(p=>p.UserId);

        });
    }
    #endregion
}