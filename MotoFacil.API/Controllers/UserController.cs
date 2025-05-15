using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoFacil.Data;
using MotoFacil.Models;

namespace MotoFacil.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user == null ? NotFound("Usuário não encontrado.") : Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
                return BadRequest("Usuário e senha são obrigatórios.");

            // Verifica se já existe usuário com esse username
            var exists = await _context.Users
                .AnyAsync(u => u.Username == user.Username);

            if (exists)
                return Conflict("Usuário já cadastrado.");

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User updatedUser)
        {
            if (id != updatedUser.Id)
                return BadRequest("ID não confere.");

            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound("Usuário não encontrado.");

            user.Username = updatedUser.Username;
            user.Password = updatedUser.Password;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound("Usuário não encontrado.");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
