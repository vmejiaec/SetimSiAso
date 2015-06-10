using System;
using SetimBasico;

namespace SetimBasico
{
    ///<summary>
    ///Poco class para asoPeriodo 
    ///</summary>
    public class asoPeriodo : Entidad
    {
        public Int32 Id { get; set; }
        public Int32 No_Periodo { get; set; }
        public DateTime Fecha_Periodo { get; set; }
        public String Estado { get; set; }
        public String Descripcion { get; set; }
    }
}