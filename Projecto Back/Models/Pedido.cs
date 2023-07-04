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
        
        public int clienteId { get; set; } 
        public Cliente? cliente{ get; set; } = null!;

        //public List<ItemPedido> itensPedido { get; } =  new ();
        public List<Produto> produto { get; } =  new List<Produto>();
    }
}