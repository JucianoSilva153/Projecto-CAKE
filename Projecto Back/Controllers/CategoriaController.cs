using System;
using System.Collections.Generic;
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
    public class CategoriaController : ControllerBase
    {
        [HttpPost]
        [Route("Categoria/Nova")]
        public RetornoDados NovaCategoria([FromServices] DataContext data, [FromBody] Categoria categoria)
        {
            if(categoria is null)
                return new RetornoDados(){
                    Entidade = null,
                    Mensagem = "Insira uma Categoria"
                };
            
            var add = new CategoriasAcessoDados(data);
            return add.NovaCategoria(categoria);
        }
    }
}