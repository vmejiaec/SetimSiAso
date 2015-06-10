using System;
using SetimBasico;

namespace SetimBasico
{
    ///<summary>
    ///Poco class para asoSocioInversion 
    ///</summary>
    public class asoSocioInversion : Entidad
    {
        public Int32 Id { get; set; }
        public Int32 asoSocio_Id { get; set; }
        public Int32 asoInversion_Id { get; set; }
    }
}