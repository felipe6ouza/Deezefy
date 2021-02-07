using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Deezefy.Application.ViewModels
{
    public class OuvinteViewModel : UsuarioViewModel
    {
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Sobrenome { get; set; }

        [Phone]
        public string Telefone { get; set; }

        public ICollection<ArtistaViewModel> Artistas { get; set; }
        public ICollection<MusicaViewModel> Musicas { get; set; }

        public PerfilViewModel Perfil { get; set; }

        public ICollection<PlaylistViewModel> Playlists { get; set; }
        public ICollection<AlbumViewModel> Albums { get; set; }
    }
}
