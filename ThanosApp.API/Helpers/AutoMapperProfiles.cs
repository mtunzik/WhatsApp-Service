
using AutoMapper;
using ThanosApp.API.Models;
using ThanosApp.API.Dtos;
using System.Linq;

namespace ThanosApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
            .ForMember(dest => dest.PhotoUrl, opt =>
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
             .ForMember( dest => dest.Age , opt => opt.MapFrom( src => src.DateofBirth.Value.CalculateAge()) );

            CreateMap<User, UserForDetailedDto>()
            .ForMember(dest => dest.PhotoUrl, opt =>
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
            .ForMember( dest => dest.Age , opt => opt.MapFrom( src => src.DateofBirth.Value.CalculateAge()) );

            CreateMap<Photo, PhotosForDetaledDto>();

            CreateMap<MessageForCreateDto,Message>().ReverseMap();
            CreateMap<Message, MessageToRetunDto>();
        }
    }
}