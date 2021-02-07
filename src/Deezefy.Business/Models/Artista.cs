using System;
using System.Collections.Generic;
using System.Text;

namespace Deezefy.Business.Models
{
    public class Artista : Usuario
    {
        public string NomeArtistico { get; set; }
        public string Biografia { get; set; }
        public int AnoFormacao { get; set; }
        
        public ICollection<Ouvinte> Ouvintes { get; set; }
        public ICollection<Musica> Musicas { get; set; }
        public ICollection<Perfil> PerfisArtistaFavorito { get; set; }
        public ICollection<Album> AlbumsLancados { get; set; }
        public ICollection<Genero> Generos { get; set; }

    }
}
