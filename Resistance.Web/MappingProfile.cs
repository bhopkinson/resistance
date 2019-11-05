using AutoMapper;
using Resistance.GameModel;
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
