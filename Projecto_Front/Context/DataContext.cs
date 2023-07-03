using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projecto_Front.Models;

namespace Projecto_Front.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Pedido>? Pedidos { get; set; }
        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<ItemPedido>? ItensPedido { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ServerVersion.AutoDetect("server=localhost;database=bd_cake;user=root;password="));
            base.OnConfiguring(optionsBuilder);
        }

        

        
    }
}