using Demo_Fluint_Api.DataAccess;
using Demo_Fluint_Api.DTOs;
using Demo_Fluint_Api.Interfaces;
using Demo_Fluint_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_Fluint_Api.Service;

#nullable disable

public class UserService : IUserRepository
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async ValueTask<bool> CreateAsync(User user)
    {
        try
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async ValueTask<bool> DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user is null)
            return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async ValueTask<IEnumerable<User>> GetAllUsersAsync()
        => await _context.Users.ToListAsync();


    public async ValueTask<User> GetByIdAsync(int id)
        => await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

    public async ValueTask<bool> UpdateAsync(int id, UserDto user)
    {
        try
        {
            var existingUser = await _context.Users.FindAsync(id);

            if (existingUser is null)
                return false;

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.UserName = user.UserName;

            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
