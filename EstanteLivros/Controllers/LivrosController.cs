using AutoMapper;
using EstanteLivros.Data;
using EstanteLivros.DTO;
using EstanteLivros.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstanteLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly DBEstantes _context;
        private readonly IMapper _mapper;

        //public LivrosController(DBEstantes context)
        //{
        //    _context = context;
        //}

        public LivrosController(DBEstantes context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }


        //Lista de Livros
        [EnableCors]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
        {
            var x = await _context.Livros
                .Where(l => l.Ativo == true)
                .OrderBy(l => l.NomeLivro)
                .Include("Autor")
                .ToListAsync();
            return Ok(x);
            
        }

        //Obter um só livro
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Livro>> GetLivros(int id)
        {
            var livros = await _context.Livros.FindAsync(id);

            if (livros == null)
            {
                return NotFound();
            }

            return livros;
        }

        //[HttpGet("{isbn}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<Livro>> GetLivrosPorISBN(string isbn)
        //{
        //    //var livros = await _context.Livros.Where(l => l.ISBN == isbn).FirstOrDefault();

        //    if (livros == null)
        //    {
        //        return NotFound();
        //    }

        //    return livros;
        //}


        //Criar entrada para um livro
        [EnableCors]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Livro>> PostLivros(LivroDTO novoLivro)
        {
            var livro =_mapper.Map<Livro>(novoLivro);
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutors", new { id = livro.ID }, livro);
        }


        //Apagar uma entrada de livro
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteLivros(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            livro.Ativo = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LivrosExists(int id)
        {
            return _context.Livros.Any(e => e.ID == id);
        }


        //Alterar uma entrada de livros
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutLivros(int id, Livro livros)
        {
            if (id != livros.ID)
            {
                return BadRequest();
            }

            _context.Entry(livros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivrosExists(id))
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
