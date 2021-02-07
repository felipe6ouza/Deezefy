using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Deezefy.Application.ViewModels
{
    public class PerfilViewModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Informacoes { get; set; }

        public string OuvinteEmail { get; set; }
        public OuvinteViewModel Ouvinte { get; set; }
        public ICollection<ArtistaViewModel> ArtistasFavoritos { get; set; }
        public ICollection<GeneroViewModel> GenerenosFavoritos { get; set; }
    }
}
