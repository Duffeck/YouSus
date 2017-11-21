using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yousus.Models.DTO
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string CodGrafico { get; set; }
        public string Cor { get; set; }

        /*
        public virtual ICollection<Residuo> Residuos { get; set; }
        public virtual ICollection<Origem> Origens { get; set; }
        public virtual ICollection<Periculosidade> Periculosidades { get; set; }
        public virtual ICollection<Tipo> Tipos { get; set; }
        public virtual ICollection<ComposicaoQuimica> ComposicoesQuimica { get; set; }
        public virtual ICollection<PontoDescarte> PontosDescarte { get; set; }
        */
    }
}