using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Deezefy.Application.ViewModels
{
    public class PlaylistViewModel
    {
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        public bool Ativo { get; set; }
        
        public int numeroOuvintes
        {
            get
            {
                return Ouvintes.Count;
            }
        }
        public ICollection<OuvinteViewModel> Ouvintes { get; set; }
        public ICollection<MusicaViewModel> Musicas { get; set; }
    }
}
