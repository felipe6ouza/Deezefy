using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Deezefy.Application.ViewModels
{
    public class ArtistaViewModel : UsuarioViewModel
    {
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string NomeArtistico { get; set; }

        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Biografia { get; set; }
        public int AnoFormacao { get; set; }

        public ICollection<OuvinteViewModel> Ouvintes { get; set; }
        public ICollection<MusicaViewModel> Musicas { get; set; }
        public ICollection<PerfilViewModel> PerfisArtistaFavorito { get; set; }
        public ICollection<AlbumViewModel> AlbumsLancados { get; set; }
        public ICollection<GeneroViewModel> Generos { get; set; }
    }
}
