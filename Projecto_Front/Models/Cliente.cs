using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecto_Front.Models
{
    public class Cliente
    {
        public int id_cliente { get; set; }
        public string? nome { get; set; }
        public string? email { get; set; }
        public int contacto { get; set; }
        public string? endereco { get; set; }
    }
}