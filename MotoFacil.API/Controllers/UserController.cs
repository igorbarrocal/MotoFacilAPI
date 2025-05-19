using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoFacil.Data;
using MotoFacil.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user == null ? NotFound("Usuário não encontrado.") : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
                    return BadRequest("Usuário e senha são obrigatórios.");

                var existingUser = await _context.Users
                    .Where(u => u.Username.ToLower() == user.Username.ToLower())
                    .Select(u => u.Id)
                    .FirstOrDefaultAsync();

                if (existingUser != 0)
                    return Conflict("Usuário já cadastrado.");

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao salvar no banco de dados Oracle: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Erro interno: " + ex.Message);
            }
        }

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

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao atualizar no banco Oracle: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound("Usuário não encontrado.");

            _context.Users.Remove(user);

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao deletar no banco Oracle: " + ex.Message);
            }
        }
    }
}
