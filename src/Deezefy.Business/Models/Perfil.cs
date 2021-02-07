using System.Collections.Generic;

namespace Deezefy.Business.Models
{
    public class Perfil : Entity
    {
        public int Id { get; set; }
        public string Informacoes { get; set; }


        public string OuvinteEmail { get; set; }
        public Ouvinte Ouvinte { get; set; }
        public ICollection<Artista> ArtistasFavoritos { get; set; }
        public ICollection<Genero> GenerenosFavoritos { get; set; }
    }
}
