using AutoMapper;
using Models;
using Models.Entity;
using WebAPI.Models;

namespace WebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, SP_Users>()
                .ForMember(e => e.UserId, f => f.MapFrom(v => v.UserId))
                .ForMember(e => e.UserName, f => f.MapFrom(v => v.UserName));
            CreateMap<SP_Users, Users>()
                .ForMember(e => e.UserId, f => f.MapFrom(v => v.UserId))
                .ForMember(e => e.UserName, f => f.MapFrom(v => v.UserName));
            CreateMap<Result<SP_Users>, Result<Users>>()
               .ConstructUsing((Result<SP_Users> m, ResolutionContext context) =>
               {
                   return new Result<Users>(m.Success, m.HasMessage, m.Message ?? "", context.Mapper.Map<IEnumerable<Users>>(m.Data), m.Exception);
               });
        }
    }
}
