﻿using System;
using SetimBasico;

namespace SetimBasico
{
    ///<summary>
    ///Poco class para asoServicio 
    ///</summary>
    public class asoServicio : Entidad
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public Decimal Porcentaje_Comision { get; set; }
        public String Tipo { get; set; }
        public Decimal Valor { get; set; }
        public Int32 No_Periodos { get; set; }
        public Int32 No_Socios_Regs { get; set; }
    }
}