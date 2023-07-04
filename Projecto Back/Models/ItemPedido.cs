using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecto_Front.Models
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public int pedidoId { get; set; }
        public int produtoId { get; set; }
        
        
        public Pedido pedido { get; set; } =  null!;
        public Produto produto { get; set; } =  null!;
    }
}