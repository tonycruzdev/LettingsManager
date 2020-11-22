using AutoMapper;
using LettingsManager.WebSite.Dto;
using LettingsManager.WebSite.Models;

namespace LettingsManager.WebSite.Helpers
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<House, ReturnHousesDto>()
                .ForMember(rh => rh.LandlordName, o => o.MapFrom(h => h.Landlord.Name));
            
            CreateMap<Landlord, LandlordDto>().ReverseMap();
            CreateMap<Landlord, ReturnLandlordDto>();
            CreateMap<HouseInsertDto, House>();
            CreateMap<ReturnHouseWithLandlordDto, House>().ReverseMap();
            
            CreateMap<Landlord, LandlordWithHouseDto>().ReverseMap();
            CreateMap<House, HouseToPrintDto>().ReverseMap();

        }
    }
}
