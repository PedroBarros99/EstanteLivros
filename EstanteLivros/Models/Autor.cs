using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstanteLivros.Models
{
    public class Autor
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string NomeAutor { get; set; }

        [InverseProperty("Autor")]
        public virtual ICollection<Livro>? Livros { get; set; }
    }
}
