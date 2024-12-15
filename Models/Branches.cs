
namespace EmployedProyect.Models;

public class Branches
{
    public Branches(BranchName branch, Guid id)
    {
        BranchId = id;
        this.Branch = branch;
    }

    public Branches(BranchName branch)
    {
        BranchId = Guid.NewGuid();
        this.Branch = branch;
        
    }

    public Guid BranchId { get; set; }
    public Guid UserId { get; set; }
    public BranchName Branch { get; set; }
    public virtual ICollection<User> UsersList { get; set; }

    /*public static string TypeBranch(BranchName branch)
    {
        return branch.ToString();
    }*/



    #region Validacion de nombre de sucursal
    public bool BranchNameValidation(BranchName name)
    {
        return Enum.IsDefined(typeof(BranchName), name.ToString());
    }
    public bool BranchNameExistence(string name)
    {
        if (Enum.TryParse(name, out BranchName BranchString))
        {
            return BranchNameValidation(BranchString);
        }
        return false;
    }
    #endregion
}
public enum BranchName
{
    Central,
    Sucursal2,
    Sucursal3
}