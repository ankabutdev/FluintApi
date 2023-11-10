using Demo_Fluint_Api.DTOs;
using Demo_Fluint_Api.Models;

namespace Demo_Fluint_Api.Interfaces;

public interface IUserRepository
{
    public ValueTask<IEnumerable<User>> GetAllUsersAsync();

    public ValueTask<User> GetByIdAsync(int id);

    public ValueTask<bool> CreateAsync(User user);

    public ValueTask<bool> UpdateAsync(int id, UserDto user);

    public ValueTask<bool> DeleteAsync(int id);

}