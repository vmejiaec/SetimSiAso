using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetimBasico
{
    public class PaginaEstado
    {
        // Atributos
        public int UserId { get; set; }
        public int ModuleID { get; set; }
        public int NoFilasPorPagina { get; set; }
        public int PaginaActual { get; set; }
        public string Ordenar_Campo { get; set; }
        public string Ordenar_Sentido { get; set; }
        public string Filtro_Campo { get; set; }
        public string Filtro_Valor { get; set; }
        // Constructor
        public PaginaEstado()
        {
            UserId = -1;
            ModuleID = -1;
            NoFilasPorPagina = 10;
            PaginaActual = 0;
            Ordenar_Sentido = "ASC";
        }
    }
}
