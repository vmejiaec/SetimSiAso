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
        public Decimal Valor_Mas_Comision { get; set; }
        public Int32 No_Cuotas { get; set; }
        public Int32 No_Cuotas_PEN { get; set; }
        public Int32 No_Cuotas_COB { get; set; }
        public String Desc_Coutas { get; set; }
        public String asoServicio_Nombre { get; set; }
    }
}