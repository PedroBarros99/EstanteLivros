using EstanteLivros.Data;
using EstanteLivros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstanteLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorsController : ControllerBase
    {
        private readonly DBEstantes _context;

        public AutorsController(DBEstantes context)
        {
            _context = context;
        }

        //Obter autores
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutors()
        {
            return await _context.Autors.ToListAsync();
        }

        //Obter um só autor
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Autor>> GetAutors(int id)
        {
            var autores = await _context.Autors.FindAsync(id);

            if (autores == null)
            {
                return NotFound();
            }

            return autores;
        }


        //Criar entrada para um autor
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Autor>> PostAutors(Autor autores)
        {
            _context.Autors.Add(autores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutors", new { id = autores.ID }, autores);
        }

        //Apagar uma entrada de autor
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAutors(int id)
        {
            var autores = await _context.Autors.FindAsync(id);
            if (autores == null)
            {
                return NotFound();
            }

            _context.Autors.Remove(autores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutorsExists(int id)
        {
            return _context.Livros.Any(e => e.ID == id);
        }


        //Alterar uma entrada de autor
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAutors(int id, Livro autores)
        {
            if (id != autores.ID)
            {
                return BadRequest();
            }

            _context.Entry(autores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }

    
}
