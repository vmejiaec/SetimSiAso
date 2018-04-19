using System;
using SetimBasico;

namespace SetimBasico
{
    ///<summary>
    ///Poco class para asoAnio 
    ///</summary>
    public class asoAnio : Entidad
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public Int32 Anio { get; set; }
        public Int32 Max_Id { get; set; }
    }
}