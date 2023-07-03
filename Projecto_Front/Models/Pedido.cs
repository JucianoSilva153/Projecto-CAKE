using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecto_Front.Models
{
    public class Pedido
    {
        public int id_pedido { get; set; }
        
        public string? data { get; set; }
        
        public int clienteId{ get; set; }
        
    }
}