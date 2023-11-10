using Demo_Fluint_Api.DTOs;
using Demo_Fluint_Api.Interfaces;
using Demo_Fluint_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Fluint_Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class GroupsController : ControllerBase
{
    private readonly IGroupRepository _repository;

    public GroupsController(IGroupRepository repository)
    {
        this._repository = repository;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        try
        {
            var result = await _repository.GetAllUsersAsync();

            if (result is null)
                return BadRequest();

            return Ok(result);
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            var result = await _repository.GetByIdAsync(id);
            if (result is null)
                return NotFound("User Not Found!");

            return Ok(result);
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(GroupDto dto)
    {
        try
        {
            Group user = new Group()
            {
                Name = dto.Name,
                Description = dto.Description
            };

            var result = await _repository.CreateAsync(user);
            if (result is false)
                return BadRequest();

            return Ok(result);
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync(int id, GroupDto dto)
    {
        try
        {
            var result = await _repository.UpdateAsync(id, dto);
            if (result is false)
                return NotFound("User Not Found!");

            return Ok(result);
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync(int id)
    {
        try
        {
            var result = await _repository.DeleteAsync(id);
            if (result is false)
                return NotFound("User Not Found!");

            return Ok(result);
        }
        catch
        {
            return BadRequest();
        }
    }
}
