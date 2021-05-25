using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI.Domain
{
    public class Adocao
    {
        public int IdAdocao { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Especie { get; set; }
        public DateTime? DtNascimento { get; set; }
        public int NvFofura { get; set; }
        public int NvCarinho { get; set; }
        public string Email { get; set; }
    }
}
