using Microsoft.AspNetCore.Mvc;
using MotoFacil.Data;
using MotoFacil.Domain.Entities;
using MotoFacil.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MotoFacil.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MotoController(AppDbContext context) => _context = context;

        // POST
        [HttpPost]
        public IActionResult Cadastrar([FromBody] MotoCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest("Dados inválidos");

            var moto = new Moto { Modelo = dto.Modelo, Placa = dto.Placa, Chassi = dto.Chassi, Status = dto.Status };

            _context.Motos.Add(moto);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObterPorId), new { id = moto.Id }, new MotoReadDto
            {
                Id = moto.Id,
                Modelo = moto.Modelo,
                Placa = moto.Placa,
                Chassi = moto.Chassi,
                Status = moto.Status
            });
        }

        // GET
        [HttpGet]
        public IActionResult Listar() =>
            Ok(_context.Motos.AsNoTracking().Select(m => new MotoReadDto
            {
                Id = m.Id,
                Modelo = m.Modelo,
                Placa = m.Placa,
                Chassi = m.Chassi,
                Status = m.Status
            }));

        // GET
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var moto = _context.Motos.AsNoTracking().FirstOrDefault(m => m.Id == id);
            if (moto == null) return NotFound("Moto não encontrada");

            return Ok(new MotoReadDto
            {
                Id = moto.Id,
                Modelo = moto.Modelo,
                Placa = moto.Placa,
                Chassi = moto.Chassi,
                Status = moto.Status
            });
        }

        // GET
        [HttpGet("buscar")]
        public IActionResult BuscarPorModelo([FromQuery] string modelo)
        {
            var motos = _context.Motos
                .Where(m => m.Modelo.Contains(modelo))
                .Select(m => new MotoReadDto
                {
                    Id = m.Id,
                    Modelo = m.Modelo,
                    Placa = m.Placa,
                    Chassi = m.Chassi,
                    Status = m.Status
                })
                .ToList();

            return Ok(motos);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] MotoCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest("Dados inválidos");

            var moto = _context.Motos.FirstOrDefault(m => m.Id == id);
            if (moto == null) return NotFound("Moto não encontrada");

            moto.Modelo = dto.Modelo;
            moto.Placa = dto.Placa;
            moto.Chassi = dto.Chassi;
            moto.Status = dto.Status;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var moto = _context.Motos.FirstOrDefault(m => m.Id == id);
            if (moto == null) return NotFound("Moto não encontrada");

            _context.Motos.Remove(moto);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
