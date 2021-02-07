using System;
using System.Collections.Generic;
using System.Text;

namespace Deezefy.Business.Models
{
    public class Ouvinte : Usuario
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }

        public ICollection<Artista> Artistas { get; set; }
        public ICollection<Musica> Musicas { get; set; }

        public Perfil Perfil { get; set; }

        public ICollection<Playlist> Playlists { get; set; }
        public ICollection<Album> Albums { get; set; }


    }
}
