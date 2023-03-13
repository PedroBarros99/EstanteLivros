using AutoMapper;
using EstanteLivros.DTO;
using EstanteLivros.Models;

namespace EstanteLivros
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Livro, LivroDTO>();
            CreateMap<LivroDTO, Livro>();

            CreateMap<Livro, LivroUpdateDTO>();
            CreateMap<LivroUpdateDTO, Livro>();

            CreateMap<Autor, AutorDTO>();
            CreateMap<AutorDTO, Autor>();

            CreateMap<Autor, AutorUpdateDTO>();
            CreateMap<AutorUpdateDTO, Autor>();
        }
    }
}
