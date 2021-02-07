using Deezefy.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Deezefy.Application.ViewModels
{
    public abstract class UsuarioViewModel
    {
        [Key]
        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Senha { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public int Idade
        {
            get
            {
                var dataAtual = DateTime.Now;
                var diferenca = dataAtual.Subtract(DataNascimento);
                var dias = diferenca.Days;
                return dias / 365;
            }
        }

        public ICollection<Evento> EventosOrganizados { get; set; }
    }
}
