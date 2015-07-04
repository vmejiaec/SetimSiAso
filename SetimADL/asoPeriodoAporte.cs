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
        public String Estado { get; set; }
        public String Descripcion { get; set; }
        public String asoSocio_Nombre { get; set; }
        public DateTime asoPeriodo_Fecha { get; set; }
        public Decimal Valor_Accion { get; set; }
        public Decimal Valor_Ahorro { get; set; }
        public Decimal Valor_Voluntario { get; set; }
        public Decimal Valor_Suma { get; set; }
        public Decimal Valor_Saldo_Accion { get; set; }
        public Decimal Valor_Saldo_Ahorro { get; set; }
        public Decimal Valor_Saldo_Voluntario { get; set; }
    }
}