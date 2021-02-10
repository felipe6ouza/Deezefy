using AutoMapper;
using Deezefy.Application.ViewModels;
using Deezefy.Business.Models;

namespace Deezefy.Application.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AlbumViewModel, Album>().ReverseMap();
            CreateMap<ArtistaViewModel, Artista>()
                .IncludeBase<UsuarioViewModel, Usuario>().ReverseMap();
            CreateMap<GeneroViewModel, Genero>().ReverseMap();
            CreateMap<LocalViewModel, Local>().ReverseMap();
            CreateMap<MusicaViewModel, Musica>().ReverseMap();
            CreateMap<OuvinteViewModel, Ouvinte>()
                 .IncludeBase<UsuarioViewModel, Usuario>()
                .ReverseMap();
            CreateMap<PerfilViewModel, Perfil>().ReverseMap();
            CreateMap<PlaylistViewModel, Playlist>().ReverseMap();
            CreateMap<UsuarioViewModel, Usuario>().ReverseMap();

        }
    }
}
