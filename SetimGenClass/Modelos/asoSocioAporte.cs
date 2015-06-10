using System;
using SetimBasico;

namespace SetimBasico
{
    ///<summary>
    ///Poco class para asoSocioAporte 
    ///</summary>
    public class asoSocioAporte : Entidad
    {
        public Int32 Id { get; set; }
        public Int32 asoSocio_Id { get; set; }
        public String Tipo { get; set; }
        public Decimal Valor { get; set; }
    }
}