using System.Collections.Generic;

namespace Deezefy.Business.Models
{
    public class Album : Entity
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int AnoLancamento { get; set; } 

        public string ArtistaEmail { get; set; }
        public Artista Artista { get; set; }

        public ICollection<Ouvinte> Ouvintes { get; set; }
        public ICollection<Musica> Musicas { get; set; }
      }
}
