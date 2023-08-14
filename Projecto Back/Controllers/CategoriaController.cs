using System.Net;
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
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        [HttpPost]
        [Route("Nova")]
        [Authorize]
        public RetornoDados NovaCategoria([FromServices] DataContext data, [FromBody] Categoria categoria)
        {
            if (categoria is null)
                return new RetornoDados()
                {
                    Entidade = null,
                    Mensagem = "Insira uma Categoria"
                };

            var add = new CategoriasAcessoDados(data);
            return add.NovaCategoria(categoria);
        }

        [HttpGet]
        [Route("Retornar")]
        [AllowAnonymous]
        public RetornoDados RetornarTodasCategorias([FromServices] DataContext data)
        {
            var categorias = data.Categorias.AsNoTracking().ToList();
            if (categorias is null)
                return new RetornoDados
                {
                    Mensagem = "Sem Categorias Disponiveis",
                    Entidade = null
                };

            return new RetornoDados
            {
                Entidade = categorias,
                Mensagem = $"{categorias.Count} Categorias Encontradas"
            };
        }

        [HttpGet]
        [Route("Retornar/{ID}")]
        [AllowAnonymous]
        public RetornoDados RetornarCategoriaPeloID([FromServices] DataContext data, int ID)
        {
            var categoria = data.Categorias.AsNoTracking().Single(c => c.Id == ID);
            if (categoria is null)
                return new RetornoDados
                {
                    Mensagem = "Sem Categorias Disponiveis",
                    Entidade = null
                };

            return new RetornoDados
            {
                Entidade = categoria,
                Mensagem = "Categoria Encontrada"
            };
        }

        [HttpPut]
        [Route("Alterar/{ID}")]
        [Authorize]
        public RetornoDados AlterarCategoria([FromServices] DataContext data, Categoria Categoria, int ID)
        {
            var categoria = data.Categorias.AsNoTracking().Single(c => c.Id == ID);
            if (categoria is null)
                return new RetornoDados
                {
                    Entidade = null,
                    Mensagem = "Categoria nao Encontrada"
                };


            try
            {
                categoria.nome = Categoria.nome;
                data.Categorias.Update(categoria);
                data.SaveChanges();
            }
            catch (System.Exception erro)
            {
                return new RetornoDados
                {
                    Entidade = null,
                    Mensagem = $"Erro ao Alterar a Categoria. Erro: '{erro.Message}'"
                };
            }

            return new RetornoDados
            {
                Entidade = categoria,
                Mensagem = $"Categoria Alterada com Sucesso!!"
            };

        }

        [HttpDelete]
        [Route("Eliminar/{ID}")]
        [Authorize]
        public RetornoDados EliminarCategoria([FromServices] DataContext data, int ID)
        {
            var categoria = data.Categorias.AsNoTracking().Single(c => c.Id == ID);
            var produtos = data.Produtos
                            .Include(p => p.categoria)
                            .Where(p => p.categoria.Id == categoria.Id);

            if (categoria is null || produtos.Count() > 0)
                return new RetornoDados
                {
                    Entidade = null,
                    Mensagem = "Categoria nao Encontrada ou Impossivel de Eliminar!"
                };

            try
            {
                data.Remove(categoria);
                data.SaveChanges();
            }
            catch (System.Exception erro)
            {
                return new RetornoDados
                {
                    Entidade = null,
                    Mensagem = $"Houve um Problema ao eliminar a categoria. Erro - '{erro.Message}'"
                };
            }

            return new RetornoDados
            {
                Entidade = null,
                Mensagem = $"Categoria Elimina com Sucesso"
            };

        }

    }
}