using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yousus.Models
{
    public class Periculosidade : Base
    {
        public Periculosidade()
        {
            Categorias = new HashSet<Categoria>();
        }

        public string Descricao { get; set; }
        public int Peso { get; set; }

        public virtual ICollection<Categoria> Categorias { get; set; }
    }
}
