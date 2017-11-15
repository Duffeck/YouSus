using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yousus.Models
{
    public class Alerta : Base
    {
        public string Descricao { get; set; }

        public PontoDescarte PontoDescarte { get; set; }
        public Usuario Usuario { get; set; }
    }
}
