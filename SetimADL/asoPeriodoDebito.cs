using System;
using SetimBasico;

namespace SetimBasico
{
    ///<summary>
    ///Poco class para asoPeriodoDebito 
    ///</summary>
    public class asoPeriodoDebito : Entidad
    {
        public Int32 Id { get; set; }
        public Int32 asoPeriodo_Id { get; set; }
        public Int32 asoServicio_Id { get; set; }
        public Int32 asoSocio_Id { get; set; }
        public Decimal Valor { get; set; }
        public Decimal Valor_Comision { get; set; }
        public String Estado { get; set; }
        public String Descripcion { get; set; }
        public String asoSocio_Nombre { get; set; }
        public DateTime asoPeriodo_Fecha { get; set; }
    }
}