using AutoMapper;

namespace Resistance.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GameModels.Game, Dispatchers.DispatchModels.Game>()
                .ForMember(
                    dest => dest.Players,
                    options => options.MapFrom(
                        src => src.Players.Values));

            CreateMap<GameModels.Player, Dispatchers.DispatchModels.Player>();
        }
    }
}
