using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecto_Front.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string? nome { get; set; }

        public List<Produto>? produtos { get; } =  new List<Produto>();
    }
}