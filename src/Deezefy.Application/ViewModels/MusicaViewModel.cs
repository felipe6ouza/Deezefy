using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Deezefy.Application.ViewModels
{
    public class MusicaViewModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }
        public int Duracao { get; set; }

        public ICollection<OuvinteViewModel> Ouvintes { get; set; }
        public ICollection<ArtistaViewModel> Artistas { get; set; }
        public ICollection<PlaylistViewModel> Playlists { get; set; }
        public ICollection<AlbumViewModel> Albums { get; set; }
        public ICollection<GeneroViewModel> Generos { get; set; }
    }
}
