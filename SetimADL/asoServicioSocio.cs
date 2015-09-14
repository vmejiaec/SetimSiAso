using System;
using SetimBasico;

namespace SetimBasico
{
    ///<summary>
    ///Poco class para asoServicioSocio 
    ///</summary>
    public class asoServicioSocio : Entidad
    {
        public Int32 Id { get; set; }
        public Int32 asoSocio_Id { get; set; }
        public Int32 asoServicio_Id { get; set; }
        public String asoSocio_Nombre { get; set; }
        public Decimal Valor { get; set; }
        public Int32 No_Periodos { get; set; }
    }
}