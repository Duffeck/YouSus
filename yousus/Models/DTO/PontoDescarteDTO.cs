using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yousus.Models.DTO
{
    public class PontoDescarteDTO
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public bool EhPArticular { get; set; }
        public LocalizacaoDTO Localizacao { get; set; }
    }
}
