using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecto_Back.Helper
{
    public class Settings
    {
        public string Env { get; set; } = "dev";   
        
        public static string Chave {get;} = "6A37EFE3C6FA35AF0169AD005FFF41E4B7B0AC64CCB7AC8E0811BD1E3BC1A6C8";
    }
}