using System;
using SetimBasico;

namespace SetimBasico
{
    ///<summary>
    ///Poco class para asoSetimListaDet 
    ///</summary>
    public class asoSetimListaDet : Entidad
    {
        public Int32 Id { get; set; }
        public Int32 asoSetimLista_Id { get; set; }
        public Int32 Orden { get; set; }
        public String Texto { get; set; }
        public String Valor { get; set; }
    }
}