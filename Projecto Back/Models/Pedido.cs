using System.Security.Cryptography;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecto_Front.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string? IdPedido { get; set; }
        public string? data { get; set; }

        public Cliente? cliente { get; set; }
        public List<Produto>? produtos { get; set; }

        public static string GerarIdPedido(string nomeCliente)
        {
            var ID = nomeCliente.Trim() + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

            using (MD5 md5 = MD5.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(ID);
                byte[] hashBytes = md5.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();

                // Converte cada byte do hash em uma representação hexadecimal e concatena
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}