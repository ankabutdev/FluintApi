using Demo_Fluint_Api.DTOs;
using Demo_Fluint_Api.Models;

namespace Demo_Fluint_Api.Interfaces;

public interface IGroupRepository
{
    public ValueTask<IEnumerable<Group>> GetAllUsersAsync();

    public ValueTask<Group> GetByIdAsync(int id);

    public ValueTask<bool> CreateAsync(Group group);

    public ValueTask<bool> UpdateAsync(int id, GroupDto group);

    public ValueTask<bool> DeleteAsync(int id);
}
