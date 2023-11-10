namespace Demo_Fluint_Api.Models;

public class Group
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public IList<User> Users { get; set; }

}
