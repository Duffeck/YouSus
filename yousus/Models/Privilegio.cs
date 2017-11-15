using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yousus.Models
{
    public class Privilegio : Base
    {
        public char Nivel { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Area Area { get; set; }
        public virtual Modulo Modulo { get; set; }
    }
}
