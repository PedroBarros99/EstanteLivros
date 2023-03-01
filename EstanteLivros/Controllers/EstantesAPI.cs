using EstanteLivros.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstanteLivros.Controllers
{
    [ApiController]

    public class EstantesAPI : ControllerBase
    {
        [HttpGet(Name = "GetAutors")]
        public IEnumerable<Autor> GetAutors() 
        {
            return new List<Autor>()
            {
                new Autor{ID=1, NomeAutor= "Pedro"},
                new Autor{ID=2, NomeAutor= "João"},
                new Autor{ID=3, NomeAutor= "Luís"},
                new Autor{ID=4, NomeAutor= "António"},
                new Autor{ID=5, NomeAutor= "Joana"},
                new Autor{ID=6, NomeAutor= "Inês"}
            };
        }
        
        [HttpGet(Name = "GetLivros")]
        public IEnumerable<Livro> GetLivros() 
        {
            return new List<Livro>()
            {
                new Livro{ID=1, IDAutor=1, ISBN=925868656, nomeLivro="The Legend Himself", precoLivro= (decimal)15.99},
                new Livro{ID=2, IDAutor=2, ISBN=945712856, nomeLivro="O Paraíso", precoLivro= (decimal)20.00},
                new Livro{ID=3, IDAutor=3, ISBN=928563135, nomeLivro="Odisseia", precoLivro= (decimal)12.99},
                new Livro{ID=4, IDAutor=4, ISBN=935835738, nomeLivro="Frankenstein", precoLivro= (decimal)10.00},
                new Livro{ID=5, IDAutor=5, ISBN=951238578, nomeLivro="Hamlet", precoLivro= (decimal)7.99},
                new Livro{ID=6, IDAutor=6, ISBN=982137395, nomeLivro="As Mil e Uma Noites", precoLivro= (decimal)17.99}

            };
        }
    }
}
