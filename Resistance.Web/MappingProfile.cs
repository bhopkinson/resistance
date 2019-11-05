using AutoMapper;
using Resistance.GameModels;
using Resistance.Web.Dispatchers.Models;

namespace Resistance.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Player, PlayerDetails>();
        }
    }
}
