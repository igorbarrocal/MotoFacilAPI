using Microsoft.AspNetCore.Mvc;
using MotoFacil.Data;
using MotoFacil.Domain.Entities;
using MotoFacil.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MotoFacil.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MotoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CadastrarMoto([FromBody] MotoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos");

            var moto = dto.ToEntity();
            _context.Motos.Add(moto);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObterPorId), new { id = moto.GetId() }, MapToReadDto(moto));
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var motos = _context.Motos
                .AsNoTracking()
                .ToList()
                .Select(m => MapToReadDto(m))
                .ToList();

            return Ok(motos);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var moto = _context.Motos
                .AsNoTracking()
                .FirstOrDefault(m => m.GetId() == id);

            if (moto == null)
                return NotFound("Moto não encontrada");

            return Ok(MapToReadDto(moto));
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarMoto(int id, [FromBody] MotoDto dto)
        {
            var moto = _context.Motos.FirstOrDefault(m => m.GetId() == id);
            if (moto == null)
                return NotFound("Moto não encontrada para atualização");

            moto.Modelo = dto.Modelo;
            moto.Placa = dto.Placa;
            moto.Chassi = dto.Chassi;
            moto.Status = dto.Status;
            moto.SetUserId(dto.UserId); // ← usando setter público

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarMoto(int id)
        {
            var moto = _context.Motos.FirstOrDefault(m => m.GetId() == id);
            if (moto == null)
                return NotFound("Moto não encontrada para exclusão");

            _context.Motos.Remove(moto);
            _context.SaveChanges();

            return NoContent();
        }

        private MotoReadDto MapToReadDto(Moto moto)
        {
            return new MotoReadDto
            {
                Id = moto.GetId(),
                Modelo = moto.Modelo,
                Placa = moto.Placa,
                Chassi = moto.Chassi,
                Status = moto.Status,
                UserId = moto.GetUserId()
            };
        }
    }
}
