using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projecto_Front.Models
{

    public class PedidoProduto
    {
        public int Id { get; set; }
        public int pedidoId { get; set; }
        public int produtoId { get; set; }
        
        public Pedido? pedido { get; set; }
        public Produto? produto { get; set; }
    }
}