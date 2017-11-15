using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yousus.Models
{
    public class Residuo : Base
    {
        public Residuo()
        {
            Fotos = new List<Foto>();
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Estado { get; set; }
        public string Observacao { get; set; }

        public virtual ICollection<Foto> Fotos { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
