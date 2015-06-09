using System;
using SetimBasico;

namespace SetimBasico
{
    ///<summary>
    ///Poco class para asoPeriodoInversion 
    ///</summary>
    public class asoPeriodoInversion : Entidad
    {
        public Int32 Id { get; set; }
        public Int32 asoPeriodo_Id { get; set; }
        public Int32 asoInversion_Id { get; set; }
        public Int32 asoSocio_Id { get; set; }
        public Decimal Valor { get; set; }
        public Decimal Valor_Comision { get; set; }
        public String Estado { get; set; }
        public String Descripcion { get; set; }
    }
}