using Demo_Fluint_Api.DTOs;
using Demo_Fluint_Api.Models;

namespace Demo_Fluint_Api.Interfaces;

public interface IBookRepository
{
    public ValueTask<IEnumerable<Book>> GetAllUsersAsync();

    public ValueTask<Book> GetByIdAsync(int id);

    public ValueTask<bool> CreateAsync(Book book);

    public ValueTask<bool> UpdateAsync(int id, BookDto dto);

    public ValueTask<bool> DeleteAsync(int id);
}
