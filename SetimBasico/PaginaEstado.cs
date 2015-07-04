using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetimBasico
{
    public class ListaPaginaEstado
    {
        public List<PaginaEstado> p { get; set; }
        public ListaPaginaEstado()
        {
            // Primera página para el master 0, las siguientes son el master 1 y 2.
            p = new List<PaginaEstado>();
            p.Add(new PaginaEstado());
            p.Add(new PaginaEstado());
            p.Add(new PaginaEstado());
        }
    }
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
        public object Filtro_Valor { get; set; }
        public string Filtro_Estado { get; set; }
        public string Filtro_Tipo { get; set; }
        public Int32? Filtro_Periodo { get; set; }
        public int dgMasterItemIndex { get; set; }  // por confirmar si se cambia el nombre
        public Int32? Master_Id { get; set; }
        public string Master_Nombre { get; set; }  // Para llevar y traer los títulos
        public string Avisos { get; set; }
        // Constructor
        public PaginaEstado()
        {
            UserId = -1;
            ModuleID = -1;
            NoFilasPorPagina = 10;
            PaginaActual = 0;
            Ordenar_Sentido = "ASC"; // por defecto orden ascendente
            Filtro_Estado = null; // por defecto todos los estados
            Filtro_Estado = null; // por defecto todos los tipos
            Filtro_Valor = null; // por defecto todos los valores
            dgMasterItemIndex = -1;
            Master_Id = null;
        }
    }
}
