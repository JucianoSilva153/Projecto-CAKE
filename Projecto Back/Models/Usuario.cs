using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projecto_Front.Models;

namespace Projecto_Back.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string password { get; set; }
        public string tipo { get; set; }
    }
}