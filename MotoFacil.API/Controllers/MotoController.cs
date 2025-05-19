using Microsoft.AspNetCore.Mvc;
using MotoFacil.Data;
using MotoFacil.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult CadastrarMoto([FromBody] Moto moto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos");

            _context.Motos.Add(moto);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObterPorId), new { id = moto.Id }, moto);
        }

      
        [HttpGet]
        public IActionResult Listar()
        {
            var motos = _context.Motos.ToList();
            return Ok(motos);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var moto = _context.Motos.Find(id);
            if (moto == null)
                return NotFound("Moto não encontrada");

            return Ok(moto);
        }

        
        [HttpGet("buscarPorPlaca")]
        public IActionResult BuscarPorPlaca([FromQuery] string placa)
        {
            var moto = _context.Motos.FirstOrDefault(m => m.Placa == placa);
            if (moto == null)
                return NotFound("Moto com essa placa não encontrada");

            return Ok(moto);
        }

        
        [HttpPut("{id}")]
        public IActionResult AtualizarMoto(int id, [FromBody] Moto motoAtualizada)
        {
            var moto = _context.Motos.Find(id);
            if (moto == null)
                return NotFound("Moto não encontrada para atualização");

            moto.Placa = motoAtualizada.Placa;
            moto.Modelo = motoAtualizada.Modelo;
            moto.Cor = motoAtualizada.Cor;
            moto.Categoria = motoAtualizada.Categoria;

            _context.SaveChanges();
            return NoContent(); // 204
        }

       
        [HttpDelete("{id}")]
        public IActionResult DeletarMoto(int id)
        {
            var moto = _context.Motos.Find(id);
            if (moto == null)
                return NotFound("Moto não encontrada para exclusão");

            _context.Motos.Remove(moto);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
