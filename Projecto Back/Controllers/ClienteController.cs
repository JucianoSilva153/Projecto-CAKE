using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projecto_Back.Data;
using Projecto_Back.Models;
using Projecto_Front.Context;
using Projecto_Front.Models;

namespace Projecto_Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("Login/Email/{email}/{password}")]
        public async Task<RetornoDados> LoginClienteViaEmail([FromServices] DataContext data, string email, string password)
        {
            if (!CredenciaisInseridasEValidos(data, email, password))
                return new RetornoDados()
                {
                    Entidade = null,
                    Mensagem = "Credenciais Inválidas!!"
                };

            var acesso = new AcessoDados(data);
            var cliente = acesso.LoginClienteCadastradoEmail(email, password);

            return Retorno(cliente);
        }

        [HttpGet]
        [Route("Login/Contacto/{numero}/{password}")]
        public async Task<RetornoDados> LoginClienteviaContacto([FromServices] DataContext data, int numero, string password)
        {
            if (!CredenciaisInseridasEValidos(data, numero, password))
                return new RetornoDados()
                {
                    Entidade = null,
                    Mensagem = "Credenciais Inválidas!!"
                };

            var acesso = new AcessoDados(data);
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

        private RetornoDados Retorno(object retornoAcesso)
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
        [Route("Cliente/Novo")]
        public async Task<RetornoDados> AdicionarNovoCliente([FromServices] DataContext data, [FromBody] Cliente cliente)
        {
            if(cliente is null)
                return new RetornoDados(){
                    Entidade = null,
                    Mensagem = "Dados do Cliente Inválidos"
                };
            
            var dados = new AcessoDados(data);
            return dados.NovoCliente(cliente);
        }   
    }
}