using System;
using System.Collections.Generic;
using System.Text;

namespace Deezefy.Business.Models
{
    public class Local : Entity
    {
        public int Id { get; set; }
        public string Pais { get; set; }
        public string Cidade { get; set; }
    }

}
