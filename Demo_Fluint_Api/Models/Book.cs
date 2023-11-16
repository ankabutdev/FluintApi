using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Fluint_Api.Models;

public class Book
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int AuthorId { get; set; }

    public string Title { get; set; }

    public int StudentId { get; set; }

    [ForeignKey(nameof(StudentId))]
    public Student Student { get; set; }

    [ForeignKey(nameof(AuthorId))]
    public Author Author { get; set; }
}
