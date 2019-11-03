using AutoMapper;
using Resistance.Web.Dispatchers.Models;

namespace Resistance.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Player, PlayerDetails>();
        }
    }
}
