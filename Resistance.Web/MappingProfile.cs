using AutoMapper;

namespace Resistance.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GameModels.Game, Dispatchers.DispatchModels.Game>();
            CreateMap<GameModels.Player, Dispatchers.DispatchModels.Player>();
        }
    }
}
