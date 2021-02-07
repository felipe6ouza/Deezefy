using System;
using System.Collections.Generic;
using System.Text;

namespace Deezefy.Business.Models
{
    public class Musica : Entity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Duracao { get; set; }

        public ICollection<Ouvinte> Ouvintes { get; set; }
        public ICollection<Artista> Artistas { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<Genero> Generos { get; set; }
    }
}
