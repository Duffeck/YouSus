using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yousus.Models.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public float Pontos { get; set; }
        public int RaioBusca { get; set; }
    }
}