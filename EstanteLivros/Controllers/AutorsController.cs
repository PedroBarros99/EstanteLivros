﻿using AutoMapper;
using EstanteLivros.Data;
using EstanteLivros.DTO;
using EstanteLivros.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Dataflow;

namespace EstanteLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorsController : ControllerBase
    {
        private readonly DBEstantes _context;
        private readonly IMapper _mapper;

        public AutorsController(DBEstantes context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        //Obter autores
        [EnableCors]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutors()
        {
            var x = await _context.Autors
                .OrderBy(a => a.NomeAutor)
                .ToListAsync();
            
            return Ok(x);
        }

        //Obter um só autor
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Autor>> GetAutors(int id)
        {
            var autor = await _context.Autors.FindAsync(id);

            if (autor == null)
            {
                return NotFound();
            }

            return Ok(autor);
        }


        //Criar entrada para um autorEnableCors
        [EnableCors]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Autor>> PostAutors(AutorDTO novoAutor)
        {
            var autor = _mapper.Map<Autor>(novoAutor);
            _context.Autors.Add(autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutors", new { id = autor.ID }, autor);
        }

        //Apagar uma entrada de autor
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAutors(int id)
        {
            var autor = await _context.Autors.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            _context.Autors.Remove(autor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutorExists(int id)
        {
            return (_context.Autors?.Any(e => e.ID == id)).GetValueOrDefault();
        }


        //Alterar uma entrada de autor
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAutors(int id, AutorUpdateDTO autor)
        {
            MessagingHelper messaging = new MessagingHelper();
            
            if (id != autor.ID)
            {
                messaging.success = false;
                messaging.message = "O autor não existe na base de dados";

                return Ok(messaging);
            }

            try
            {
                var autorEditar = _mapper.Map<Autor>(autor);
                _context.Entry(autorEditar).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(id))
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
