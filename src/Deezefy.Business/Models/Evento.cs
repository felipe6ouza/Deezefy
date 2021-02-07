using System;
using System.Collections.Generic;
using System.Text;

namespace Deezefy.Business.Models
{
    public class Evento : Entity
    {
        public int Id { get; set; }
        public int Nome { get; set; } 
        public string EmailOrganizador { get; set; }
        public Usuario Organizador { get; set; }

    }
}
