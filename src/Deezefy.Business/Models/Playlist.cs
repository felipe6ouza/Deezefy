using System;
using System.Collections.Generic;
using System.Text;

namespace Deezefy.Business.Models
{
   
    public class Playlist : Entity
    {
        public string Nome { get; set; }

        public enum Status
        {
            Ativo,
            Inativo
        }
        public int nOuvintes { get; set; }

        public ICollection<Ouvinte> Ouvintes { get; set; }
        public ICollection<Musica> Musicas { get; set; }

    }
}
