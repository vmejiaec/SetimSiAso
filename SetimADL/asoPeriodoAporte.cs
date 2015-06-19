using System;
using SetimBasico;

namespace SetimBasico
{
    ///<summary>
    ///Poco class para asoPeriodoAporte 
    ///</summary>
    public class asoPeriodoAporte : Entidad
    {
        public Int32 Id { get; set; }
        public Int32 asoPeriodo_Id { get; set; }
        public Int32 asoSocio_Id { get; set; }
        public String Tipo { get; set; }
        public Decimal Valor { get; set; }
        public String Estado { get; set; }
        public String Descripcion { get; set; }
        public String asoSocio_Nombre { get; set; }
    }
}