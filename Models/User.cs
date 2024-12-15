using System.ComponentModel.DataAnnotations;

namespace EmployedProyect.Models;
public class User
{
    public User(string name, string surname, Guid id, Category category, BranchName branch) //constructor para HttpGet
    {
        this.Name = name;
        this.Surname = surname;
        this.UserId = id;
        TypeCategory(this.UserCategory = category);
    }
    public User(string name, string surname, Category category, BranchName branch) //constructor para HttpPost para que genere el Guid unico por usuario 
    {
        this.Name = name;
        this.Surname = surname;
        TypeCategory(this.UserCategory = category);
        this.UserId = Guid.NewGuid();
    }
    public Guid UserId = new Guid(); //este new Guid() me generaría un nuevo ID cada vez que el programa se ejecute? o el de los datos semilla lo haria? 
    public Guid BranchId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Category UserCategory { get; set; }
    public virtual Branches VBranch { get; set; }
    public static string TypeCategory(Category category)
    {
        return category.ToString();
    }

}
public enum Category
{
    [Display(Name = "Boss")]
    Boss,
    [Display(Name = "Employee")]
    Employee,
}
