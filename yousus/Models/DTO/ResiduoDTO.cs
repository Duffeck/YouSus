using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yousus.Models.DTO
{
    public class ResiduoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Estado { get; set; }
        public string Observacao { get; set; }
        public CategoriaDTO Categoria { get; set; }
        public List<FotoDTO> Fotos { get; set; }
    }
}
