using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yousus.Models
{
    public class Usuario : Base
    {
        public Usuario()
        {
            Eventos = new HashSet<Evento>();
            Denuncias = new List<Denuncia>();
            Fotos = new List<Foto>();
            Residuos = new List<Residuo>();
            Localizacoes = new List<Localizacao>();
            Alertas = new List<Alerta>();
            Acoes = new HashSet<Acao>();
            Privilegios = new List<Privilegio>();
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public float Pontos { get; set; }
        public int RaioBusca { get; set; }


        public virtual ICollection<Evento> Eventos { get; set; }
        public virtual ICollection<Denuncia> Denuncias { get; set; }
        public virtual ICollection<Foto> Fotos { get; set; }
        public virtual ICollection<Residuo> Residuos { get; set; }
        public virtual ICollection<Alerta> Alertas { get; set; }
        public virtual ICollection<Acao> Acoes { get; set; }
        public virtual ICollection<Localizacao> Localizacoes { get; set; }
        public virtual ICollection<Privilegio> Privilegios { get; set; }
    }
}