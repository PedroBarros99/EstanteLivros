using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstanteLivros.Models
{
    public class Livro
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int ISBN { get; set; }

        [Required]
        public string nomeLivro { get; set; } = null!;

        [Required]
        public int IDAutor { get; set; }

        public Autor Autor { get; set; }

        [Required]
        [Column(TypeName = "decimal(15,4)")]
        public decimal precoLivro { get; set; }
    }
}
