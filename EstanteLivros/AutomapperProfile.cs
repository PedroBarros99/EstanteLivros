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

            CreateMap<Autor, AutorDTO>();
            CreateMap<AutorDTO, Autor>();
        }
    }
}
