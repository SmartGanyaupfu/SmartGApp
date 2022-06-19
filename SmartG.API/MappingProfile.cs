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

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>();

            CreateMap<Post, PostDto>();
            CreateMap<PostForCreationDto, Post>();
            CreateMap<PostForUpdateDto, Post>();

            CreateMap<Comment, CommentDto>();
            CreateMap<CommentForCreationDto, Comment>();
            CreateMap<CommentForUpdateDto, Comment>();

            CreateMap<Portfolio, PortfolioDto>();
            CreateMap<PortfolioForCreationDto, Portfolio>();
            CreateMap<PortfolioForUpdateDto, Portfolio>();

            CreateMap<Image, ImageDto>();
            CreateMap<ImageForCreationDto, Image>();
            CreateMap<ImageDto, ImageDto>();

            CreateMap<ContentBlock, ContentBlockDto>();
            CreateMap<ContentBlockForCreationDto, ContentBlock>();
            CreateMap<ContentBlockForUpdateDto, ContentBlock>();

            CreateMap<OfferedService, ServiceDto>();
            CreateMap<ServiceForCreationDto, OfferedService>();
            CreateMap<ServiceForUpdateDto, OfferedService>();
        }
    }
}

