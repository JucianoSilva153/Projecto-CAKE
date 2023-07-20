using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecto_Front.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string? nome { get; set; }
        public string? descricao { get; set; }
        public double preco { get; set; }
        public string? imagem { get; set; }        
        public bool disponivel { get; set; }

        

        public List<Pedido>? pedidos { get; set; }
        public Categoria? categoria { get; set; } = null;
    }
}