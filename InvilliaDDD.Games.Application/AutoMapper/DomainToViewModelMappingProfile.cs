﻿using AutoMapper;
using InvilliaDDD.GameManager.Application.ViewModels;
using InvilliaDDD.GameManager.Domain.Entities;

namespace InvilliaDDD.GameManager.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Game, GameViewModel>();
            CreateMap<Friend, FriendViewModel>();
        }
    }
}
