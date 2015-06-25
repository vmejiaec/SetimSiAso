using System;
using SetimBasico;

namespace SetimBasico
{
    ///<summary>
    ///Poco class para asoParametro 
    ///</summary>
    public class asoParametro : Entidad
    {
        public Int32 Id { get; set; }
        public Int32 asoPeriodo_Id_Actual { get; set; }
        public Decimal Porcentaje_Comision_Por_Defecto { get; set; }
        public Decimal Valor_Reingreso { get; set; }
        public Int32 No_Periodos_Reingreso { get; set; }
        public Decimal Valor_Accion_Minimo { get; set; }
        public Decimal Valor_Ahorro_Minimo { get; set; }
        public Decimal Tasa_Interes_Por_Defecto { get; set; }
        public String Nombre_Largo_Asociacion { get; set; }
        public String Nombre_Corto_Asociacion { get; set; }
        public DateTime asoPeriodo_Actual_Fecha { get; set; }
    }
}