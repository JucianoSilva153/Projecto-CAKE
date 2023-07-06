﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projecto_Front.Context;

#nullable disable

namespace Projecto_Back.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PedidoProduto", b =>
                {
                    b.Property<int>("pedidosId")
                        .HasColumnType("int");

                    b.Property<int>("produtoId")
                        .HasColumnType("int");

                    b.HasKey("pedidosId", "produtoId");

                    b.HasIndex("produtoId");

                    b.ToTable("PedidoProduto");
                });

            modelBuilder.Entity("Projecto_Front.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Projecto_Front.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("contacto")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("longtext");

                    b.Property<string>("endereco")
                        .HasColumnType("longtext");

                    b.Property<string>("nome")
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Projecto_Front.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("clienteId")
                        .HasColumnType("int");

                    b.Property<string>("data")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("clienteId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Projecto_Front.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("categoriaId")
                        .HasColumnType("int");

                    b.Property<string>("descricao")
                        .HasColumnType("longtext");

                    b.Property<bool>("disponivel")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("imagem")
                        .HasColumnType("longtext");

                    b.Property<string>("nome")
                        .HasColumnType("longtext");

                    b.Property<double>("preco")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("categoriaId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("PedidoProduto", b =>
                {
                    b.HasOne("Projecto_Front.Models.Pedido", null)
                        .WithMany()
                        .HasForeignKey("pedidosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projecto_Front.Models.Produto", null)
                        .WithMany()
                        .HasForeignKey("produtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projecto_Front.Models.Pedido", b =>
                {
                    b.HasOne("Projecto_Front.Models.Cliente", "cliente")
                        .WithMany("pedido")
                        .HasForeignKey("clienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("Projecto_Front.Models.Produto", b =>
                {
                    b.HasOne("Projecto_Front.Models.Categoria", "categoria")
                        .WithMany("produtos")
                        .HasForeignKey("categoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categoria");
                });

            modelBuilder.Entity("Projecto_Front.Models.Categoria", b =>
                {
                    b.Navigation("produtos");
                });

            modelBuilder.Entity("Projecto_Front.Models.Cliente", b =>
                {
                    b.Navigation("pedido");
                });
#pragma warning restore 612, 618
        }
    }
}
