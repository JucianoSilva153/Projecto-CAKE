using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projecto_Back.Models;
using Projecto_Back.Helper;
using Projecto_Front.Context;
using Microsoft.AspNetCore.Authorization;
using Projecto_Back.Data;

namespace Projecto_Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {

        [FromServices] 
        public static DataContext Dados { get; set; }
        
        public ClientesAcessoDados dadosClientes = new ClientesAcessoDados(Dados);

        [HttpPost]
        [Route("/Autenticacao")]
        [AllowAnonymous]
        public RetornoDados Login([FromServices] DataContext data, [FromBody] Usuario usuario)
        {
            var token = string.Empty;
            try
            {
                var user = data.Usuario.SingleOrDefault(u => u.nome == usuario.nome && u.password == usuario.password);
                if (user is null)
                    return new RetornoDados
                    {
                        Entidade = null,
                        Mensagem = "Usuário nao Encontrado!!"
                    };

                token = AuthJWT.GerarToken(usuario, data);
            }
            catch (System.Exception erro)
            {
                return new RetornoDados
                {
                    Entidade = null,
                    Mensagem = $"Erro ao Autenticar Usuario. Erro: {erro.Message}"
                };
            }

            return new RetornoDados
            {
                Entidade = new { Token = token },
                Mensagem = "Usuario Autenticado com sucesso"
            };
        }

        [HttpPost]
        [Route("/Autenticacao/{email}/{password}")]
        [AllowAnonymous]
        public RetornoDados LoginViaEmail([FromServices] DataContext data, string email, string password)
        {
            var usuario = (dadosClientes.LoginClienteCadastradoEmail(email, password)).usuario;
            var token = string.Empty;

            try
            {
                if (usuario is null)
                    return new RetornoDados
                    {
                        Entidade = null,
                        Mensagem = "Erro ao Autenticar. Usuario nao encontrado!!"
                    };

                token = AuthJWT.GerarToken(usuario, data);
            }
            catch (System.Exception erro)
            {
                return new RetornoDados
                {
                    Entidade = null,
                    Mensagem = $"Erro ao Autenticar. Erro: '{erro.Message}'"
                };
            }


            return new RetornoDados
            {
                Entidade = new { Token = token },
                Mensagem = "Usuario Autenticado com Sucesso"
            };
        }

        [HttpPost]
        [Route("/Autenticacao/{numero}/{password}")]
        [AllowAnonymous]
        public RetornoDados LoginViaNumeroTelefone([FromServices] DataContext data, int numero, string password)
        {
            var usuario = (dadosClientes.LoginClienteCadastradoTelefone(numero, password)).usuario;
            var token = string.Empty;

            try
            {
                if (usuario is null)
                    return new RetornoDados
                    {
                        Entidade = null,
                        Mensagem = "Erro ao Autenticar. Usuario nao encontrado!!"
                    };

                token = AuthJWT.GerarToken(usuario, data);
            }
            catch (System.Exception erro)
            {
                return new RetornoDados
                {
                    Entidade = null,
                    Mensagem = $"Erro ao Autenticar. Erro: '{erro.Message}'"
                };
            }


            return new RetornoDados
            {
                Entidade = new { Token = token },
                Mensagem = "Usuario Autenticado com Sucesso"
            };
        }
    }
}