using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yousus.Models
{
    public class Informativo : Base
    {
        public Informativo()
        {
            Administradores = new HashSet<Administrador>();
        }

        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Administrador> Administradores { get; set; }
    }
}
