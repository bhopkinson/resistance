using AutoMapper;
using Resistance.Web.Handlers.RequestModels;
using Resistance.Web.Hubs.Models;

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
