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
        [Route("Pedido/Cliente/Adicionar")]
        public RetornoDados AdicionarPedidoAoCliente ([FromServices]DataContext data, [FromBody]Pedido pedido){
            var add = new PedidosAcessoDados(data);
            return add.CriarPedidoDeCliente(pedido);
        }
    }
}