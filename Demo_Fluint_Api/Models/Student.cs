namespace Demo_Fluint_Api.Models;

public class Student
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public ICollection<Book> Books { get; set; }
}