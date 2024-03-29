﻿using AutoMapper;
using EbisuWebApi.Application.Dtos;
using EbisuWebApi.Crosscutting.Utils;
using EbisuWebApi.Domain.Entities;
using EbisuWebApi.Infrastructure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncodingAes = EbisuWebApi.Crosscutting.Security.EncodingAes;

namespace EbisuWebApi.Application.Services.Configuration
{
    public class AutoMapperServiceConfiguration : Profile
    {
        public AutoMapperServiceConfiguration()
        {
            CreateMap<UserDto, UserEntity>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => EncodingAes.EncryptStringToBytes_Aes(src.Password)));

            CreateMap<UserLoginDto, UserEntity>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => EncodingAes.EncryptStringToBytes_Aes(src.Password)));

            CreateMap<CategoryDto, CategoryEntity>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.Parse(typeof(CategoryType), src.Type)));

            CreateMap<UserEntity, UserDto>();
            CreateMap<UserEntity, UserLoginDto>();

            CreateMap<CategoryEntity, CategoryDto>();

            CreateMap<UserEntity, UserDataModel>().ReverseMap();
            CreateMap<CategoryEntity, CategoryDataModel>().ReverseMap();

            CreateMap<TransactionEntity, TransactionDataModel>().ReverseMap();
            CreateMap<TransactionEntity, TransactionDto>().ReverseMap();

        }
    }
}
