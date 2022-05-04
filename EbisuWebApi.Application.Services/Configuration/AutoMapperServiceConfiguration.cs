using AutoMapper;
using EbisuWebApi.Application.Dtos;
using EbisuWebApi.Crosscutting.Utils;
using EbisuWebApi.Domain.Entities;
using EbisuWebApi.Infrastructure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encoding = EbisuWebApi.Crosscutting.Security.Encoding;

namespace EbisuWebApi.Application.Services.Configuration
{
    public class AutoMapperServiceConfiguration : Profile
    {
        public AutoMapperServiceConfiguration()
        {
            CreateMap<UserDto, UserEntity>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => Encoding.EncryptStringToBytes_Aes(src.Password)))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Enum.Parse(typeof(Role), src.Role)));

            CreateMap<UserLoginDto, UserEntity>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => Encoding.EncryptStringToBytes_Aes(src.Password)));

            CreateMap<CategoryDto, CategoryEntity>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.Parse(typeof(CategoryType), src.Type)));

            CreateMap<UserEntity, UserDto>();
            CreateMap<UserEntity, UserLoginDto>();

            CreateMap<UserEntity, UserLoginTokenDto>()
                .ForMember(dest => dest.Token, opt => opt.MapFrom(src => TokenGenerator.CreateToken(src.UserId, src.UserName, src.Email, src.Role)));

            CreateMap<CategoryEntity, CategoryDto>();

            CreateMap<UserEntity, UserDataModel>().ReverseMap();
            CreateMap<CategoryEntity, CategoryDataModel>().ReverseMap();

            CreateMap<TransactionEntity, TransactionDataModel>().ReverseMap();
            CreateMap<TransactionEntity, TransactionDto>().ReverseMap();

        }
    }
}
