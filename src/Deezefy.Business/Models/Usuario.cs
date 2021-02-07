using System;
using System.Collections.Generic;
using System.Text;

namespace Deezefy.Business.Models
{
    public abstract class Usuario : Entity
    {
        public string Email { get; set; }
        public string Senha { get; set; }
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
