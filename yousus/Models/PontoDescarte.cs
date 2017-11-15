using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yousus.Models
{
    public class PontoDescarte : Base
    {
        public PontoDescarte()
        {
            Alertas = new List<Alerta>();
            RotasColeta = new HashSet<RotaColeta>();
        }

        public string Estado { get; set; }
        public bool EhPArticular { get; set; }

        public virtual Area Area { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Localizacao Localizacao { get; set; }
        public virtual ZonaVerde ZonaVerde { get; set; }
        public virtual List<Alerta> Alertas { get; set; }
        public virtual ICollection<RotaColeta> RotasColeta { get; set; }

    }
}
