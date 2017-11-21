using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yousus.Models.DTO
{
    public class DataRotaDTO
    {
        public int Id { get; set; }
        public int DiasSemana { get; set; }
        public DateTime DiaUnico { get; set; }
        public DateTime Horario { get; set; }
    }
}
