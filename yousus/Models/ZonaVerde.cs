using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yousus.Models
{
    public class ZonaVerde : Base
    {
        //[ForeignKey("Localizacao")]
        //public int LocalizacaoId { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual Localizacao Localizacao { get; set; }
    }
}
