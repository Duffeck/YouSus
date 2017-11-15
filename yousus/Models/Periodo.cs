using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yousus.Models
{
    public class Periodo : Base
    {
        public DateTime HorarioInicial { get; set; }
        public DateTime HorarioFinal { get; set; }

        public virtual Evento Evento { get; set; }
    }
}
