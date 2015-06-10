using System;
using SetimBasico;

namespace SetimBasico
{
    ///<summary>
    ///Poco class para asoSocio 
    ///</summary>
    public class asoSocio : Entidad
    {
        public Int32 Id { get; set; }
        public Int32 UserID { get; set; }
        public String CI { get; set; }
        public String Descripcion { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public String Estado { get; set; }
        public String Users_EMail { get; set; }
        public String Users_Nombre { get; set; }
        public Decimal Valor_Accion { get; set; }
        public Decimal Valor_Ahorro { get; set; }
    }
}