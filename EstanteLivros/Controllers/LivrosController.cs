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

        [EnableCors]
        [HttpGet("PesquisarLivros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivrosPesquisados([FromQuery]string termoPesquisa)
        {
            var x = await _context.Livros
                .Where(l => l.Ativo == true && (l.NomeLivro.Contains(termoPesquisa) || l.ISBN.Contains(termoPesquisa) ))
                .OrderBy(l => l.NomeLivro)
                .Include("Autor")
                .ToListAsync();
            return Ok(x);

        }

        //Obter um só livro
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LivroDTO>> GetLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);

            if (livro == null)
            {
                return NotFound();
            }

            var livrodto = _mapper.Map<LivroDTO>(livro);

            return Ok(livrodto);

            
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

            return CreatedAtAction("GetLivros", new { id = livro.ID }, livro);
        }


        //Apagar uma entrada de livro
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            livro.Ativo = false;
            _context.Entry(livro).State = EntityState.Modified;

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

        private bool LivrosExists(int id)
        {
            return _context.Livros.Any(e => e.ID == id);
        }


        //Alterar uma entrada de livros
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutLivro(int id, LivroUpdateDTO livroAlterado)
        {
            if (id != livroAlterado.ID)
            {
                return BadRequest();
            }

            var livro = _mapper.Map<Livro>(livroAlterado);

            _context.Entry(livro).State = EntityState.Modified;

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
