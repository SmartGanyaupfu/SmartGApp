using System;
using AutoMapper;
using SmartG.Entities.Models;
using SmartG.Shared.DTOs;

namespace SmartG.API
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<UserForUpdateDto, User>();

            CreateMap<Page, PageDto>();
            CreateMap<PageForCreationDto, Page>();
            CreateMap<PageForUpdateDto, Page>();
        }
    }
}

