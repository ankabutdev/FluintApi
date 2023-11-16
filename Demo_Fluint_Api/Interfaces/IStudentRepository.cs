using Demo_Fluint_Api.DTOs;
using Demo_Fluint_Api.Models;

namespace Demo_Fluint_Api.Interfaces;

public interface IStudentRepository
{
    public ValueTask<IEnumerable<Student>> GetAllUsersAsync();

    public ValueTask<Student> GetByIdAsync(int id);

    public ValueTask<bool> CreateAsync(Student student);

    public ValueTask<bool> UpdateAsync(int id, StudentDto dto);

    public ValueTask<bool> DeleteAsync(int id);
}
