using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecto_Front.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string? data { get; set; }

        public Cliente? cliente { get; set; }
        public List<Produto>? produtos { get; set; }
    }
}