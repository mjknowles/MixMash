using AutoMapper;
using MixMash.Shared.BL.Entities;
using MixMash.Shared.BL.ViewModels;
using MixMash.Shared.DAL.DTOs;

namespace MixMash.Shared.BL
{
    public class Bootstrapper
    {
        public static void InitializeAutoMapper()
        {
            Mapper.Initialize(
                cfg => {
                    cfg.CreateMap<TrackDto, Track>()
                       .ForMember(
                           dest => dest.SpotifyId,
                           opts => opts.MapFrom(src => src.Id))
                       .ForMember(dest => dest.Id, opt => opt.Ignore());
                    cfg.CreateMap<ArtistDto, TrackArtist>();
                    cfg.CreateMap<Track, TrackViewModel>()
                        .ForMember(
                            dest => dest.Artist,
                            opts => opts.MapFrom(src => src.Artists[0].Name));
                });
        }
    }
}
