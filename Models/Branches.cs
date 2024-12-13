
namespace EmployedProyect.Models;

public class Branches
{
    public Branches(Branch branch)
        {TypeBranch(this.branch = branch);}

    public Branch branch { get; set; }

    public static string TypeBranch(Branch branch)
    {
        return branch.ToString();
    }

}
public enum Branch
{
    central,
    secundaria
}