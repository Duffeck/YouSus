using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yousus.Models
{
    public class Localizacao : Base
    {
        public Localizacao()
        {
            //PontosDescarte = new List<PontoDescarte>();
        }

        public string Latitude { get; set; }
        public string Longitude { get; set; }

        //public virtual ICollection<PontoDescarte> PontosDescarte { get; set; }
        //public virtual ZonaVerde ZonaVerde { get; set; }
        //public virtual Usuario Usuario { get; set; }

    }
}
