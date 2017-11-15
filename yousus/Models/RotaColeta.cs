using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yousus.Models
{
    public class RotaColeta : Base
    {
        public RotaColeta()
        {
            PontosDescarte = new HashSet<PontoDescarte>();
        }

        public string Nome { get; set; }
        public string Status { get; set; }

        public virtual ICollection<PontoDescarte> PontosDescarte { get; set; }
        //public virtual DataRota Data { get; set; }
        public virtual Area Area { get; set; }
    }
}
