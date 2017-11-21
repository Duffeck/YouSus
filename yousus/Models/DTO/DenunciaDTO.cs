using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yousus.Models.DTO
{
    [Serializable]
    public class DenunciaDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Estado { get; set; }
    }
}
