using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projecto_Back.Data;
using Projecto_Back.Models;
using Projecto_Front.Context;
using Projecto_Front.Models;

namespace Projecto_Back.Controllers
{
    [ApiController]
    [Route("api/Cliente")]
    public class ClienteController : ControllerBase
    {

        [HttpGet]
        [Route("Pedidos/{IdCliente}")]
        [Authorize]
        public RetornoDados RetornarPedidosDeClientePeloID([FromServices] DataContext data, int IdCliente)
        {
            var acesso = new ClientesAcessoDados(data);
            return acesso.RetornarPedidosDeCliente(IdCliente);
        }

        [HttpGet]
        [Route("{IdCliente}")]
        [Authorize]
        public RetornoDados RetornarClientePeloID([FromServices] DataContext data, int IdCliente)
        {
            var acesso = new ClientesAcessoDados(data);
            return acesso.RetornarClientePeloID(IdCliente);
        }

        [HttpGet]
        [Route("Todos")]
        [Authorize]
        public async Task<RetornoDados> RetornarClienteTodos([FromServices] DataContext data)
        {
            var servico = new ClientesAcessoDados(data);
            return await servico.RetornarTodosClientes();
        }

        [HttpGet]
        [Route("Email/{email}/{password}")]
        [Authorize]
        public RetornoDados LoginClienteViaEmail([FromServices] DataContext data, string email, string password)
        {
            if (!CredenciaisInseridasEValidos(data, email, password))
                return new RetornoDados()
                {
                    Entidade = null,
                    Mensagem = "Credenciais Inválidas!!"
                };

            var acesso = new ClientesAcessoDados(data);
            var cliente = acesso.LoginClienteCadastradoEmail(email, password);

            return Retorno(cliente);
        }

        [HttpGet]
        [Route("Contacto/{numero}/{password}")]
        [Authorize]
        public RetornoDados LoginClienteviaContacto([FromServices] DataContext data, int numero, string password)
        {
            if (!CredenciaisInseridasEValidos(data, numero, password))
                return new RetornoDados()
                {
                    Entidade = null,
                    Mensagem = "Credenciais Inválidas!!"
                };

            var acesso = new ClientesAcessoDados(data);
            var cliente = acesso.LoginClienteCadastradoTelefone(numero, password);

            return Retorno(cliente);
        }

        private bool CredenciaisInseridasEValidos(DataContext contexto, string email, string password)
        {
            if (contexto is null && (email is null || password is null))
                return false;
            return true;
        }

        private bool CredenciaisInseridasEValidos(DataContext contexto, int numero, string password)
        {
            if (contexto is null && (numero.ToString().Length < 0 || password is null))
                return false;
            return true;
        }

        private RetornoDados Retorno(object? retornoAcesso)
        {
            if (retornoAcesso is null)
                return new RetornoDados()
                {
                    Entidade = null,
                    Mensagem = "Erro de Login!! Credendiciais Erradas!!"
                };

            return new RetornoDados()
            {
                Entidade = retornoAcesso,
                Mensagem = "Login Efetuado com Sucesso"
            };
        }

        [HttpPost]
        [Route("Novo")]
        [Authorize]
        public RetornoDados AdicionarNovoCliente([FromServices] DataContext data, [FromBody] Cliente cliente)
        {
            if (cliente is null)
                return new RetornoDados()
                {
                    Entidade = null,
                    Mensagem = "Dados do Cliente Inválidos"
                };

            var dados = new ClientesAcessoDados(data);
            return dados.NovoCliente(cliente);
        }

        [HttpPut]
        [Route("Alterar/{ID}")]
        [Authorize]
        public RetornoDados AlterarCliente([FromServices] DataContext data, Cliente cliente)
        {
            var clienteAlterado = data.Clientes.AsNoTracking().Single(c => c.Id == cliente.Id);

            try
            {
                clienteAlterado.contacto = cliente.contacto;
                clienteAlterado.email = cliente.email;
                clienteAlterado.endereco = cliente.endereco;
                clienteAlterado.usuario = cliente.usuario;
                data.Clientes.Update(clienteAlterado);
                data.SaveChanges();
            }
            catch (System.Exception erro)
            {
                return new RetornoDados
                {
                    Entidade = null,
                    Mensagem = $"Erro ao Alterar Cliente. Erro: '{erro.Message}'"
                };
            }

            return new RetornoDados
            {
                Entidade = cliente,
                Mensagem = "Cliente Atualizado com Sucesso"
            };
        }

        [HttpDelete]
        [Route("Eliminar/{ID}")]
        [AllowAnonymous]
        public RetornoDados EliminarCliente([FromServices] DataContext data, int ID)
        {
            try
            {
                var cliente = data.Clientes.AsNoTracking().Single(c => c.Id == ID);
                data.Clientes.Remove(cliente);
                data.SaveChanges();
            }
            catch (System.Exception erro)
            {
                return new RetornoDados
                {
                    Entidade = null,
                    Mensagem = $"Erro ao Eliminar Cliente. Erro: '{erro.Message}'"
                };
            }

            return new RetornoDados
            {
                Entidade = null,
                Mensagem = "Cliente eliminado com sucesso!!"
            };
        }
    }
}