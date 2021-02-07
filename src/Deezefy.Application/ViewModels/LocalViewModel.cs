using System.ComponentModel.DataAnnotations;

namespace Deezefy.Application.ViewModels
{
    public class LocalViewModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Pais { get; set; }

        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Cidade { get; set; }
    }
}
