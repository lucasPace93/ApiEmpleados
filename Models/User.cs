using System.ComponentModel.DataAnnotations;

namespace EmployedProyect.Models;

public class User
{
    public User(string name, string surname, Guid id, Category category) //constructor para HttpGet
    {
        this.Name = name;
        this.Surname = surname;
        this.UserId = id;
        this.UserCategory = category;
    }
    public User(string name, string surname, Category category) //constructor para HttpPost para que genere el Guid unico por usuario 
    {
        this.Name = name;
        this.Surname = surname;
        this.UserCategory = category;
        this.UserId = Guid.NewGuid();
    }

    public Guid UserId = new Guid();
    public string Name { get; set; }
    public string Surname { get; set; }
    public Category UserCategory { get; set; }

    
}

public enum Category
{
    [Display(Name="Boss")]
    Boss,
    [Display(Name = "Employee")] 
    Employee,
}
