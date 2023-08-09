using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projecto_Back.Data;
using Projecto_Back.Models;
using Projecto_Front.Context;
using Projecto_Front.Models;

namespace Projecto_Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {

        [HttpGet]
        [Route("Produto/ById/{IdProduto}")]
        [Authorize]
        public RetornoDados RetornarProdutoById([FromServices] DataContext data, int IdProduto)
        {
            var get = new ProdutosAcessoDados(data);
            return get.RetornarProdutoPeloID(IdProduto);
        }

        [HttpGet]
        [Route("Produto/")]
        [AllowAnonymous]
        public RetornoDados RetornarTodosProduto([FromServices] DataContext data)
        {
            var get = new ProdutosAcessoDados(data);
            return get.RetornarTodosProduto();
        }

        [HttpPost]
        [Route("Produto/Novo")]
        [Authorize]
        public RetornoDados NovoProduto([FromServices] DataContext data, [FromBody] Produto produto)
        {
            if (produto is null)
                return new RetornoDados()
                {
                    Entidade = null,
                    Mensagem = "Insira um Produto"
                };

            var add = new ProdutosAcessoDados(data);
            return add.NovoProduto(produto);
        }

        [HttpPut]
        [Route("Produto/Categoria/Adicionar/{IdProduto}")]
        [Authorize]
        public RetornoDados AdicionarCategoria([FromServices] DataContext data, [FromBody] Categoria categoria, int IdProduto)
        {
            if ( IdProduto <= 0 ||  categoria is null)
                return new RetornoDados(){
                    Entidade = null,
                    Mensagem = "Erro. Insira os Dados corretos"
                };
            
            var add = new ProdutosAcessoDados(data);
            return add.AdicionarCategoriaDeProduto(categoria, IdProduto);
        }
    }
}