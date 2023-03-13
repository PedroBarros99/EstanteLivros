using EstanteLivros.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EstanteLivros.DTO
{
    public class LivroUpdateDTO
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string ISBN { get; set; }

        [Required]
        public string NomeLivro { get; set; } = null!;

        [Required]
        public int IDAutor { get; set; }

        [Required]
        public decimal PrecoLivro { get; set; }

    }
}
