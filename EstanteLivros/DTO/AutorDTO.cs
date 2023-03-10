using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EstanteLivros.Models;

namespace EstanteLivros.DTO
{
    public class AutorDTO
    {
        [Required]
        public string NomeAutor { get; set; } = null!;
    }
}
