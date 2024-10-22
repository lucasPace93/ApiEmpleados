


namespace EmployedProyect.Models;


public class User
{
    public int Id { get; set; }
    private string _Name { get; set; }

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    public string surname { get; set; }
    private int Identifier { get; set; }
    public int Dni
    {
        get { return Identifier; }
        set { Identifier = value; }
    }





}