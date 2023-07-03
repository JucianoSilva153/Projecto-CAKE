using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecto_Front.Models
{
    public class ItemPedido
    {
        public int id_itemPedido { get; set; }
        public int pedidoId { get; set; }
        public int produtoId { get; set; }
    }
}