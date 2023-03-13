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
    [Index(nameof(ISBN), IsUnique = true)]
    public class Livro
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string ISBN { get; set; }

        [Required]
        public string NomeLivro { get; set; }

        [Required]
        [ForeignKey("Autor")]
        public int IDAutor { get; set; }

        public virtual Autor Autor { get; set; }

        public bool Ativo { get; set; } = true;


        [Required]
        [Column(TypeName = "decimal(9,2)")]
        public decimal PrecoLivro { get; set; }
    }
}
