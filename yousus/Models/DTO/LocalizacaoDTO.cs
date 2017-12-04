using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yousus.Models.DTO
{
    public class LocalizacaoDTO
    {
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        //public ICollection<PontoDescarteDTO> PontosDescarte { get; set; }
        //public ZonaVerdeDTO ZonaVerde { get; set; }
        public UsuarioDTO Usuario { get; set; }
    }
}
