using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projecto_Back.Models;
using Projecto_Front.Context;
using Projecto_Front.Models;

namespace Projecto_Back.Data
{
    public class AcessoDados
    {
        private DataContext? context { get; set; }

        public AcessoDados(DataContext data)
        {
            context = data;
        }

        public Object? LoginClienteCadastradoEmail(string email, string password)
        {
            var cliente = context.Clientes
                .AsNoTracking()
                .FirstOrDefault(cl => cl.email == email && cl.password == password);

            if (cliente is null)
                return null;
            return cliente;
        }

        public Object? LoginClienteCadastradoTelefone(int numeroTelefone, string password)
        {
            var cliente = context?.Clientes
                .AsNoTracking()
                .FirstOrDefault(cl => cl.contacto == numeroTelefone && cl.password == password);

            if (cliente is null)
                return null;
            return cliente;
        }

        public RetornoDados NovoCliente(Cliente cliente)
        {
            try
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }
            catch (System.Exception erro)
            {
                return new RetornoDados(){
                    Entidade = null,
                    Mensagem = $"Erro ao adicionar novo Cliente: '{erro.Message}'"
                };
            }

            var clienteAdicionado = context.Clientes.FirstOrDefault(cl => cl.contacto == cliente.contacto && cl.email == cliente.email);
            return new RetornoDados(){
                Entidade = clienteAdicionado,
                Mensagem = "Novo Cliente Adicionado"
                
            };
        }
    }
}