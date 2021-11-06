using AddressBookAPI.DTOs;
using AddressBookAPI.Entities;
using AutoMapper;

namespace AddressBookAPI.Helper
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ContactDTO,Contact>().ReverseMap();
            CreateMap<ContactCreationDTO, Contact>();
        }
    }
}
