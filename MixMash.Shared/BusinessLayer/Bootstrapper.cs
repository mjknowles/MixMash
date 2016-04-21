﻿using AutoMapper;
using MixMash.Shared.BL.Entities;
using MixMash.Shared.DAL.DTOs;

namespace MixMash.Shared.BL
{
    public class Bootstrapper
    {
        public static IMapper AutoMapper()
        {
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<TrackDto, Track>()
                    .ForMember(
                        dest => dest.SpotifyId,
                        opts => opts.MapFrom(src => src.Id)));
            return config.CreateMapper();
        }
    }
}
