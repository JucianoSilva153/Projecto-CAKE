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
    public class PedidoController : ControllerBase
    {

        [HttpPost]
        [Route("/Cliente/Adicionar/{IdCliente}")]
        public RetornoDados AdicionarPedidoAoCliente ([FromServices]DataContext data,[FromBody]List<Produto>? produtos, int IdCliente){
            var add = new PedidosAcessoDados(data);
            var cliente = data.Clientes?.SingleOrDefault(c => c.Id == IdCliente);
            if(cliente is null)
                return new RetornoDados(){Entidade = null, Mensagem = "Erro, Cliente não encontrado!!"};


            var pedido = new Pedido{
                IdPedido = Pedido.GerarIdPedido(cliente.nome),
                data = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year,
                cliente = cliente,
                produtos = produtos
            };
            
            return add.CriarPedidoDeCliente(pedido, IdCliente);
        }
    }
}