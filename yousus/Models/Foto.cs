using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yousus.Models
{
    public class Foto : Base
    {
        public Foto()
        {
            Denuncias = new List<Denuncia>();
        }
        public string URL { get; set; }

        public virtual ICollection<Denuncia> Denuncias { get; set; }
        public virtual Residuo Residuo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
