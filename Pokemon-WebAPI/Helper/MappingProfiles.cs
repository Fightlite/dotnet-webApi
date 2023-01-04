using System;
using AutoMapper;
using Pokemon_WebAPI.Dto;
using Pokemon_WebAPI.Models;

namespace Pokemon_WebAPI.Helper
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<Pokemon, PokemonDto>();
            CreateMap<PokemonDto, Pokemon>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}

