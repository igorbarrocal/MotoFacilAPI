using Microsoft.AspNetCore.Mvc;
using MotoFacil.Data;
using MotoFacil.Domain.Entities;
using MotoFacil.DTOs;

namespace MotoFacil.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users

                .Select(static u => new UserCreateDto
                {
                    Id = u.Id,
                    Username = u.Username
                })
                .ToList();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            var dto = new UserCreateDto
            {
                Id = user.Id,
                Username = user.Username
            };

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Create(UserCreateDto dto)
        {
            var user = new User(dto.Username, dto.Senha);
            _context.Users.Add(user);
            _context.SaveChanges();

            var readDto = new UserReadDto
            {
                Id = user.Id,
                Username = user.Username
            };

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, readDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
