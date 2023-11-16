using Demo_Fluint_Api.DTOs;
using Demo_Fluint_Api.Models;

namespace Demo_Fluint_Api.Interfaces;

public interface IAuthorRepository
{
    public ValueTask<IEnumerable<Author>> GetAllUsersAsync();

    public ValueTask<Author> GetByIdAsync(int id);

    public ValueTask<bool> CreateAsync(Author author);

    public ValueTask<bool> UpdateAsync(int id, AuthorDto dto);

    public ValueTask<bool> DeleteAsync(int id);
}
