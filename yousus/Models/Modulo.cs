using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yousus.Models
{
    public class Modulo : Base
    {
        public Modulo()
        {
            Privilegios = new List<Privilegio>();
        }

        public string Nome { get; set; }

        public virtual ICollection<Privilegio> Privilegios { get; set; }
    }
}
