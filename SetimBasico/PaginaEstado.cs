using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetimBasico
{
    public class PaginaEstado
    {
        public int UserId { get; set; }
        public int ModuleID { get; set; }
        public int NoFilasPorPagina { get; set; }
        public int PaginaActual { get; set; }
        public string OrdenarCampo { get; set; }
        public string OrdenarSentido { get; set; }
        public string FiltroNombre { get; set; }
        public string FiltroValor { get; set; }
    }
}
