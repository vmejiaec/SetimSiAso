using System;
using SetimBasico;

namespace SetimBasico
{
    ///<summary>
    ///Poco class para asoPeriodoCuota 
    ///</summary>
    public class asoPeriodoCuota : Entidad
    {
        public Int32 Id { get; set; }
        public Int32 asoPeriodo_Id { get; set; }
        public Int32 asoPrestamo_Id { get; set; }
        public Decimal Valor_Capital { get; set; }
        public Decimal Valor_Interes { get; set; }
        public String Estado { get; set; }
        public String Descripcion { get; set; }
    }
}