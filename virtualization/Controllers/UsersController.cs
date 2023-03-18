using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using virtualization.Data;
using X.PagedList;

namespace virtualization.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly MyDbContext _context;

    public UsersController(MyDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAll(int pageNumber = 1, int pageSize = 10)
    {
        
        var users = await _context.Users.ToListAsync();
        var pagedUsers = users.ToPagedList(pageNumber, pageSize);
        return Ok(pagedUsers);
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<User>> GetRecordById(Guid id)
    {
        var user = await _context.Users
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();
        return Ok(user);
    }

    [HttpPost]
    public async Task CreateUser(CreateUserDto user)
    {
        var newUser = new User()
        {
            Id = Guid.NewGuid(),
            Usermane = user.Usermane,
            Password = user.Password,
            Age = user.Age,
            RegistryDate = DateTime.Now.ToUniversalTime()
        };

        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();
    }

    [HttpDelete]
    public async Task<ActionResult<Guid>> DeleteUser(Guid userId)
    {
        var record = await _context.Users.FirstOrDefaultAsync(p => p.Id == userId);
        if (record == null)
        {
            return NotFound();
        }

        _context.Users.Remove(record);
        await _context.SaveChangesAsync();
        return Ok(userId);
    }
}