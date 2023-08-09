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

namespace Projecto_Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("/autenticacao")]
        [AllowAnonymous]
        public RetornoDados Login([FromServices] DataContext context, [FromBody] Usuario usuario)
        {
            var token = string.Empty;
            try
            {
                var user = context.Usuario.SingleOrDefault(u => u.nome == usuario.nome && u.password == usuario.password);
                if (user is null)
                    return new RetornoDados
                    {
                        Entidade = null,
                        Mensagem = "Usuário nao Encontrado!!"
                    };

                token = AuthJWT.GerarToken(usuario);
            }
            catch (System.Exception erro)
            {
                return new RetornoDados{
                    Entidade = null,
                    Mensagem = $"Erro ao Autenticar Usuario. Erro: {erro.Message}"
                };
            }

            return new RetornoDados{
                Entidade = new { Token = token },
                Mensagem = "Usuario Autenticado com sucesso"
            };
        }
    }
}