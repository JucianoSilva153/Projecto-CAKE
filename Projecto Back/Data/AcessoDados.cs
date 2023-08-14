using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public Cliente? LoginClienteCadastradoEmail(string email, string password)
        {
            Cliente? cliente = context?.Clientes?
                .Include(c => c.pedidos)
                    .ThenInclude(p => p.produtos)
                .Include(c => c.usuario)
                .Single(cl => cl.email == email && cl.usuario.password == password);

            if (cliente is null)
                return null;

            cliente = ResolverErroLoopCliente(cliente);
            return cliente;
        }

        public RetornoDados RetornarPedidosDeCliente(int IdCliente)
        {
            Cliente? cliente = context?.Clientes?
                .Include(c => c.pedidos)
                    .ThenInclude(p => p.produtos)
                        .ThenInclude(cat => cat.categoria)
                .Single(cl => cl.Id == IdCliente);

            if (cliente is null)
                return new RetornoDados
                {
                    Entidade = null,
                    Mensagem = "Paciente nao Encontrado"
                };

            cliente = ResolverErroLoopCliente(cliente);
            return new RetornoDados
            {
                Entidade = cliente.pedidos,
                Mensagem = "Paciente Encontrado"
            };
        }

        public RetornoDados RetornarClientePeloID(int IdCliente)
        {
            Cliente? cliente = context?.Clientes?
                .Include(c => c.pedidos)
                    .ThenInclude(p => p.produtos)
                        .ThenInclude(cat => cat.categoria)
                .Include(u => u.usuario)
                .Single(cl => cl.Id == IdCliente);

            if (cliente is null)
                return new RetornoDados
                {
                    Entidade = null,
                    Mensagem = "Paciente nao Encontrado"
                };

            cliente = ResolverErroLoopCliente(cliente);
            return new RetornoDados
            {
                Entidade = cliente,
                Mensagem = "Paciente Encontrado"
            };
        }

        public Cliente ResolverErroLoopCliente(Cliente? cliente)
        {
            foreach (var pedido in cliente.pedidos)
            {
                pedido.cliente = null;
                foreach (var pedidosProduto in pedido.produtos)
                {
                    pedidosProduto.pedidos = null;
                }
            }
            return cliente;
        }

        public Cliente? LoginClienteCadastradoTelefone(int numeroTelefone, string password)
        {
            var cliente = context?.Clientes?
                .Include(c => c.pedidos)
                .Include(c => c.usuario)
                .Single(cl => cl.contacto == numeroTelefone && cl.usuario.password == password);

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

            int IDCategoria = 0;

            try
            {
                if(produto.categoria.Id > 0){
                    IDCategoria = produto.categoria.Id;
                    produto.categoria = context.Categorias.Find(IDCategoria);
                }

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

            var produtoAdicionado = context.Produtos.FirstOrDefault(pr => pr.nome == produto.nome);
            return new RetornoDados()
            {
                Entidade = produtoAdicionado,
                Mensagem = "Produto Adicionado com Sucesso!!"
            };
        }

        public RetornoDados RetornarProdutoPeloID(int IdProduto)
        {
            var mensagem = "Produto retornado com sucesso!";

            using (context)
            {
                var produtoRetornado = context.Produtos
                            .Include(p => p.categoria)
                            .Single(p => p.Id == IdProduto);

                if (produtoRetornado is null)
                    mensagem = "Erro ao retornar Produto";

                return new RetornoDados()
                {
                    Entidade = produtoRetornado,
                    Mensagem = mensagem
                };
            }
        }
        public RetornoDados RetornarTodosProduto()
        {
            var mensagem = "Produto retornado com sucesso!";

            using (context)
            {
                var produtoRetornado = context.Produtos
                            .Include(p => p.categoria)
                            .ToList();

                if (produtoRetornado is null)
                    mensagem = "Erro ao retornar Produto";

                return new RetornoDados()
                {
                    Entidade = produtoRetornado,
                    Mensagem = mensagem
                };
            }
        }
        public RetornoDados AdicionarCategoriaDeProduto(Categoria categoria, int IdProduto)
        {
            var produto = context.Produtos.Single(p => p.Id == IdProduto);
            produto.categoria = categoria;
            if (context.SaveChanges() > 0)
                return new RetornoDados()
                {
                    Entidade = produto,
                    Mensagem = $"Categoria '{categoria.nome} adicionada ao produto '{produto.nome}'"
                };
            return new RetornoDados()
            {
                Entidade = null,
                Mensagem = "Erro ao adicionar categoria"
            };
        }

        public RetornoDados AlterarProduto(Produto produto)
        {
            try
            {
                context.Produtos.Update(produto);
                context.SaveChanges();
            }
            catch (System.Exception erro)
            {
                return new RetornoDados
                {
                    Entidade = null,
                    Mensagem = $"Erro ao Tentar Atualizar o produto. Erro: {erro.Message}"
                };
            }

            return new RetornoDados
            {
                Entidade = produto,
                Mensagem = "Produto Alterado com Sucesso"
            };
        }
    }

    public class PedidosAcessoDados
    {
        private DataContext? context { get; set; }

        public PedidosAcessoDados(DataContext data)
        {
            context = data;
        }

        public RetornoDados CriarPedidoDeCliente(Pedido pedido, int IdCliente)
        {
            var cliente = context?.Clientes?
                .Include(c => c.pedidos)
                .Single(c => c.Id == IdCliente);

            if (pedido is null)
                return new RetornoDados()
                {
                    Entidade = null,
                    Mensagem = "Insira um Pedido Valido"
                };

            cliente?.pedidos?.Add(pedido);

            if (context?.SaveChanges() > 0)
                return new RetornoDados()
                {
                    Entidade = null,
                    Mensagem = "Pedido adicionado com sucesso"
                };

            return new RetornoDados()
            {
                Entidade = null,
                Mensagem = "Erro ao adicionar novo Pedido"
            };
        }

        public RetornoDados AdicionarProdutoAoPedido()
        {
            return new RetornoDados();
        }
    }

    public class CategoriasAcessoDados
    {
        private DataContext? context { get; set; }

        public CategoriasAcessoDados(DataContext data)
        {
            context = data;
        }

        public RetornoDados NovaCategoria(Categoria categoria)
        {
            try
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
            }
            catch (System.Exception erro)
            {
                return new RetornoDados()
                {
                    Entidade = null,
                    Mensagem = $"Erro ao Adicionar nova categoria: {erro.Message}"
                };
            }

            var categoriaAdicionada = context.Categorias.FirstOrDefault(cat => cat.nome == categoria.nome);
            return new RetornoDados()
            {
                Entidade = categoriaAdicionada,
                Mensagem = "Categoria Adicionada com sucesso"
            };

        }
    }
}