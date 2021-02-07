using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Deezefy.Application.ViewModels
{
    public class GeneroViewModel
    {
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [Key]
        public string Nome { get; set; }

        public enum Estilo
        {
            Blues,
            Rock,
            Mpb,
            Samba,
            Sertanejo,
            Jazz,
            Clássica
        }

        public ICollection<ArtistaViewModel> Artistas { get; set; }
        public ICollection<MusicaViewModel> Musicas { get; set; }
        public ICollection<PerfilViewModel> GeneroFavoritoPerfis { get; set; }
    }
}
