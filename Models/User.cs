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
        this.branch = branch;
    }
    public User(string name, string surname, Category category, BranchName branch) //constructor para HttpPost para que genere el Guid unico por usuario 
    {
        this.Name = name;
        this.Surname = surname;
        TypeCategory(this.UserCategory = category);
        this.UserId = Guid.NewGuid();
        this.branch = branch;
    }
    public Guid UserId = new Guid();
    public string Name { get; set; }
    public string Surname { get; set; }
    public Category UserCategory { get; set; }
    public BranchName branch { get; set; }
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
