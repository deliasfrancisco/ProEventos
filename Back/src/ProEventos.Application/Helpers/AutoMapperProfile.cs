 using AutoMapper;
using ProEventos.Domain;
//using ProEventos.Domain.Identity;
using ProEventos.Application.Dtos;
using System.Linq;

namespace ProEventos.Application.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Evento, EventoDto>() // estabelece relação de muitos para muitos
                .ForMember(d => d.Palestrantes, opt => {
                    opt.MapFrom(src => src.PalestrantesEventos.Select(p => p.Palestrante).ToList());
                })
                .ReverseMap();

            CreateMap<Palestrante, PalestranteDto>() // estabelece relação de muitos para muitos
                .ForMember(d => d.Eventos, opt => {
                    opt.MapFrom(src => src.PalestrantesEventos.Select(e => e.Evento).ToList());
                })
                .ReverseMap();

            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
            //CreateMap<User, UserDto>().ReverseMap();
            //CreateMap<User, UserLoginDto>().ReverseMap();

        }
    }
}
