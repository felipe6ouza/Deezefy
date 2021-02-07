using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Deezefy.Application.ViewModels
{
    public class AlbumViewModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Titulo { get; set; }
        public int AnoLancamento { get; set; }


        [EmailAddress]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string ArtistaEmail { get; set; }
        public ArtistaViewModel Artista { get; set; }

        public ICollection<OuvinteViewModel> Ouvintes { get; set; }
        public ICollection<MusicaViewModel> Musicas { get; set; }
    }
}
