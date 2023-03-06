using EstanteLivros.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;


namespace EstanteLivros.Data
{
    public class DBEstantes : DbContext
    {
        public DbSet<Autor> Autors { get; set; } = null!;

        public DbSet<Livro> Livros { get; set; } = null!;


        public DBEstantes() 
        {
        }

        public DBEstantes(DbContextOptions<DBEstantes> options)
            : base(options)
        {
        }

        

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) :base(optionsBuilder)
        //{
        //optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-PQ0V2OD3\SQLEXPRESS;Initial Catalog=DBEstantes;Integrated Security=True;
        //Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //}

    }
}
