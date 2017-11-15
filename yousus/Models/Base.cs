using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yousus.Models
{
    public class Base
    {
        public int Id { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public Base() {
            this.DataCriacao = DateTime.Now;
            this.DataAtualizacao = DateTime.Now;
        }
    }
}