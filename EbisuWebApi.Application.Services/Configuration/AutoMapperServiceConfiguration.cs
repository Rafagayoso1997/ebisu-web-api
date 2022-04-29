﻿using AutoMapper;
using EbisuWebApi.Application.DTOs;
using EbisuWebApi.Crosscutting.Utils;
using EbisuWebApi.Domain.Entities;
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
            CreateMap<UserDTO, UserEntity>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => Encoding.EncryptStringToBytes_Aes(src.Password)));

            CreateMap<CategoryDto, CategoryEntity>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.Parse(typeof(CategoryType), src.Type)));

            CreateMap<UserEntity, UserDTO>();
            CreateMap<CategoryEntity, CategoryDto>();

        }
    }
}
