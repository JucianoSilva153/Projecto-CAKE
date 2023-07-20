using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Projecto_Front.Models;

namespace Projecto_Front.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Pedido>? Pedidos { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        private readonly IConfiguration configuration;

        public DataContext(IConfiguration config)
        {
            configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=bd_cake;user=root;password=");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

}