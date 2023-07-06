using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projecto_Back.Models;
using Projecto_Front.Context;
using Projecto_Front.Models;

namespace Projecto_Back.Data
{
    public class ClientesAcessoDados
    {
        private DataContext? context { get; set; }

        public ClientesAcessoDados(DataContext data)
        {
            context = data;
        }

        public Object? LoginClienteCadastradoEmail(string email, string password)
        {
            var cliente = context.Clientes
                .AsNoTracking()
                .FirstOrDefault(cl => cl.email == email && cl.password == password);

            if (cliente is null)
                return null;
            return cliente;
        }

        public Object? LoginClienteCadastradoTelefone(int numeroTelefone, string password)
        {
            var cliente = context?.Clientes
                .AsNoTracking()
                .FirstOrDefault(cl => cl.contacto == numeroTelefone && cl.password == password);

            if (cliente is null)
                return null;
            return cliente;
        }

        public RetornoDados NovoCliente(Cliente cliente)
        {
            try
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }
            catch (System.Exception erro)
            {
                return new RetornoDados()
                {
                    Entidade = null,
                    Mensagem = $"Erro ao adicionar novo Cliente: '{erro.Message}'"
                };
            }

            var clienteAdicionado = context.Clientes.FirstOrDefault(cl => cl.contacto == cliente.contacto && cl.email == cliente.email);
            return new RetornoDados()
            {
                Entidade = clienteAdicionado,
                Mensagem = "Novo Cliente Adicionado"

            };
        }
    }

    public class ProdutosAcessoDados
    {
        private DataContext? context { get; set; }

        public ProdutosAcessoDados(DataContext data)
        {
            context = data;
        }

        public RetornoDados NovoProduto(Produto produto)
        {
            try
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
            }
            catch (System.Exception erro)
            {
                return new RetornoDados()
                {
                    Entidade = null,
                    Mensagem = $"Erro ao adicionar novo Produto: '{erro.Message}'"
                };
            }

            var produtoAdicionado = context.Produtos.FirstOrDefault(pr => pr.nome == produto.nome && pr.categoriaId == produto.categoriaId);
            return new RetornoDados()
            {
                Entidade = produtoAdicionado,
                Mensagem = "Produto Adicionado com Sucesso!!"
            };
        }
    }

    public class CategoriasAcessoDados
    {
        private DataContext? context { get; set; }

        public CategoriasAcessoDados(DataContext data)
        {
            context = data;
        }

        public RetornoDados NovaCategoria(Categoria categoria){
            try
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
            }
            catch (System.Exception erro)
            {
                return new RetornoDados(){
                    Entidade = null,
                    Mensagem = $"Erro ao Adicionar nova categoria: {erro.Message}"
                };
            }

            var categoriaAdicionada = context.Categorias.FirstOrDefault(cat => cat.nome == categoria.nome);
            return new RetornoDados(){
                Entidade = categoriaAdicionada,
                Mensagem = "Categoria Adicionada com sucesso"
            };
            
        } 
    }
}