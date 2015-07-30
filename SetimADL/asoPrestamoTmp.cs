using System;
using SetimBasico;

namespace SetimBasico
{
    ///<summary>
    ///Poco class para asoPrestamoTmp 
    ///</summary>
    public class asoPrestamoTmp : Entidad
    {
        public Int32 Id { get; set; }
        public String CI { get; set; }
        public Decimal Valor_Prestamo { get; set; }
        public Int32 No_Periodos { get; set; }
        public Int32 No_Periodos_Faltantes { get; set; }
        public Decimal Valor_Capital { get; set; }
        public Decimal Valor_Interes { get; set; }
    }
}