using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using virtualization.Data;

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
    public async Task<ActionResult<List<User>>> GetAll()
    {
        var users = await _context.Users.ToListAsync();
        return Ok(users);
    }
}