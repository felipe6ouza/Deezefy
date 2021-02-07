using System;
using System.Collections.Generic;
using System.Text;

namespace Deezefy.Business.Models
{
    public class Genero : Entity
    {
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

        public ICollection<Artista> Artistas { get; set; }
        public ICollection<Musica> Musicas { get; set; }
        public ICollection<Perfil> GeneroFavoritoPerfis { get; set; }


    }

}
