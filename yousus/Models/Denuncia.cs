using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yousus.Models
{
    [Serializable]
    public class Denuncia : Base
    {
        public string Descricao { get; set; }
        public string Estado { get; set; }

        public virtual Evento Evento { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Foto Foto { get; set; }

    }
}
