using System;
using SetimBasico;

namespace SetimBasico
{
    ///<summary>
    ///Poco class para asoPrestamo 
    ///</summary>
    public class asoPrestamo : Entidad
    {
        public Int32 Id { get; set; }
        public Int32 asoSocio_Id { get; set; }
        public Decimal Valor { get; set; }
        public Decimal Tasa_Interes { get; set; }
        public Int32 No_Periodos { get; set; }
        public Int32 No_Periodos_Gracia { get; set; }
        public String Tipo { get; set; }
        public DateTime Fecha_Solicitud { get; set; }
        public Int32 asoSocio_Id_Garante { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public String Estado { get; set; }
        public String Descripcion { get; set; }
    }
}