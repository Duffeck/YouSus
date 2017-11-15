using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yousus.Models
{
    public class Area : Base
    {
        public Area()
        {
            Privilegios = new List<Privilegio>();
            Eventos = new List<Evento>();
            RotasColeta = new List<RotaColeta>();
            PontosDescarte = new List<PontoDescarte>();
        }

        public string Nome  { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Privilegio> Privilegios { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; }
        public virtual ICollection<RotaColeta> RotasColeta { get; set; }
        public virtual ICollection<PontoDescarte> PontosDescarte { get; set; }

    }
}
