
namespace EmployedProyect.Models;

public class Branches
{
    public Branches(BranchName branch)
    { TypeBranch(this.branch = branch); }

    public BranchName branch { get; set; }

    public static string TypeBranch(BranchName branch)
    {
        return branch.ToString();
    }

    #region Validacion de nombre de sucursal
    public bool BranchNameValidation(BranchName name)
    {
        return Enum.IsDefined(typeof(BranchName), name.ToString());
    }
    public bool BranchNameExistence(string name)
    {
        if (Enum.TryParse(name, out BranchName result))
        {
            return BranchNameValidation(result);
        }
        return false;
    }
    #endregion
}
public enum BranchName
{
    central,
    sucursal2,
    sucursal3
}