using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yousus.Models.DTO
{
    public class EventoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; } 
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string URLFoto { get; set; }
    }
}
