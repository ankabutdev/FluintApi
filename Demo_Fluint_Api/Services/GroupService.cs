using Demo_Fluint_Api.DataAccess;
using Demo_Fluint_Api.DTOs;
using Demo_Fluint_Api.Interfaces;
using Demo_Fluint_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_Fluint_Api.Services;

#nullable disable

public class GroupService : IGroupRepository
{
    private readonly AppDbContext _context;

    public GroupService(AppDbContext dbContext)
    {
        this._context = dbContext;
    }

    public async ValueTask<bool> CreateAsync(Group group)
    {
        try
        {
            await _context.Groups.AddAsync(group);
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
        var group = await _context.Groups.FindAsync(id);
        if (group is null)
            return false;

        _context.Groups.Remove(group);
        await _context.SaveChangesAsync();
        return true;
    }

    public async ValueTask<IEnumerable<Group>> GetAllUsersAsync()

        => await _context.Groups.Include(x => x.Users).ToListAsync();

    public async ValueTask<Group> GetByIdAsync(int id)
        => await _context.Groups.FirstOrDefaultAsync(x => x.Id == id);

    public async ValueTask<bool> UpdateAsync(int id, GroupDto group)
    {
        try
        {
            var existingGroup = await _context.Groups.FindAsync(id);

            if (existingGroup is null)
                return false;

            existingGroup.Name = group.Name;
            existingGroup.Description = group.Description;

            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
