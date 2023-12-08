using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecto_Front.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string? nome { get; set; }
        public string? descricao { get; set; }
        public double preco { get; set; }
        public string? imagem { get; set; }
        public bool disponivel { get; set; }



        public List<Produto> ListarProdutos()
        {
            throw new Exception();
        }

        public static List<Produto> ListarProdutosDestaques()
        {
            var lista = new List<Produto>();
            lista.Add(new Produto()
            {
                Id = 1,
                nome = "Ressois de Peixe",
                descricao = "Cesto completo 1x20 de ressois crocantes recheados de peixe.",
                disponivel = true,
                imagem = "SemImagem",
                preco = 22000
            });
            lista.Add(new Produto()
            {
                Id = 1,
                nome = "Ressois de Peixe",
                descricao = "Cesto completo 1x12 de ressois crocantes recheados de peixe.",
                disponivel = true,
                imagem = "SemImagem",
                preco = 14000
            });
            lista.Add(new Produto()
            {
                Id = 1,
                nome = "Ressois de Frango",
                descricao = "Cesto completo 1x12 de ressois crocantes recheados de frango.",
                disponivel = true,
                imagem = "SemImagem",
                preco = 12000
            });
            lista.Add(new Produto()
            {
                Id = 1,
                nome = "Bolo de Chocolate",
                descricao = "Bolo de chocolate branco, de 3 camadas para casamentos.",
                disponivel = true,
                imagem = "SemImagem",
                preco = 28000
            });
            lista.Add(new Produto()
            {
                Id = 1,
                nome = "Bolo de Jimguba",
                descricao = "Bolo normal de jimguba, perfeito para festas e outros eventos.",
                disponivel = true,
                imagem = "SemImagem",
                preco = 20000
            });
            lista.Add(new Produto()
            {
                Id = 1,
                nome = "Cochinhas de Frango",
                descricao = "Tabuleiro de Cochinhas 1x20 completamente recheado de frango.",
                disponivel = true,
                imagem = "SemImagem",
                preco = 15000
            });

            return lista;
        }

        public static List<Produto> ListarProdutosBestSellers()
        {
            var lista = new List<Produto>();

            lista.Add(new Produto()
            {
                Id = 1,
                nome = "Bolo de Chocolate",
                descricao = "Bolo de chocolate branco, de 3 camadas para casamentos.",
                disponivel = true,
                imagem = "SemImagem",
                preco = 28000
            });
            lista.Add(new Produto()
            {
                Id = 1,
                nome = "Bolo de Jimguba",
                descricao = "Bolo normal de jimguba, perfeito para festas e outros eventos.",
                disponivel = true,
                imagem = "SemImagem",
                preco = 20000
            });
            lista.Add(new Produto()
            {
                Id = 1,
                nome = "Cochinhas de Frango",
                descricao = "Tabuleiro de Cochinhas 1x20 completamente recheado de frango.",
                disponivel = true,
                imagem = "SemImagem",
                preco = 15000
            });
            lista.Add(new Produto()
            {
                Id = 1,
                nome = "Cochinhas de Frango",
                descricao = "Tabuleiro de Cochinhas 1x30 completamente recheado de frango.",
                disponivel = true,
                imagem = "SemImagem",
                preco = 30000
            });

            return lista;
        }

        public static List<Produto> PesquisarProdutos(string pesquisa)
        {
            var lista = new List<Produto>();
            lista.Add(new Produto(){
                Id = 1,
                nome = "Ressois de Peixe",
                descricao = "Cesto completo 1x20 de ressois crocantes recheados de peixe.",
                disponivel = true,
                imagem = "SemImagem",
                preco = 22000
            });
            lista.Add(new Produto(){
                Id = 1,
                nome = "Ressois de Peixe",
                descricao = "Cesto completo 1x12 de ressois crocantes recheados de peixe.",
                disponivel = true,
                imagem = "SemImagem",
                preco = 14000
            });
            lista.Add(new Produto(){
                Id = 1,
                nome = "Ressois de Frango",
                descricao = "Cesto completo 1x12 de ressois crocantes recheados de frango.",
                disponivel = true,
                imagem = "SemImagem",
                preco = 12000
            });
            lista.Add(new Produto(){
                Id = 1,
                nome = "Bolo de Chocolate",
                descricao = "Bolo de chocolate branco, de 3 camadas para casamentos.",
                disponivel = true,
                imagem = "SemImagem",
                preco = 28000
            });
            lista.Add(new Produto(){
                Id = 1,
                nome = "Bolo de Jimguba",
                descricao = "Bolo normal de jimguba, perfeito para festas e outros eventos.",
                disponivel = true,
                imagem = "SemImagem",
                preco = 20000
            });
            lista.Add(new Produto(){
                Id = 1,
                nome = "Cochinhas de Frango",
                descricao = "Tabuleiro de Cochinhas 1x20 completamente recheado de frango.",
                disponivel = true,
                imagem = "SemImagem",
                preco = 15000
            });


            return lista.FindAll(p => p.nome.ToLower().Contains(pesquisa.ToLower()));
        }

    }
}