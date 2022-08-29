using AutoMapper;
using WebAPI_Systemutveckling_.Net.Models;
using WebAPI_Systemutveckling_.Net.Models.Entities;

namespace WebAPI_Systemutveckling_.Net.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AccountEntity, Account>().ReverseMap();

            CreateMap<AccountEntity, AccountTokenHandler>();
           
            CreateMap<SignUp, AccountEntity>();
            CreateMap<SignIn, AccountEntity>();
        }
    }
}
