using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;
using DotNetNuke.Services.Log.EventLog;
using DotNetNuke.Services.Exceptions;
using SetimBasico;

namespace SetimBasico
{

    /// <summary>
    /// Completa las funciones de la clase generada automáticamente asoServicio
    /// </summary>
    public partial class asoServicioControl
    {
        public IList<asoServicio> _0SelByAll(string tipo, string campo, object valor, Int32 PageIndex, Int32 PageSize, String SortField, String SortDirection)
        {
            IList<asoServicio> res = new List<asoServicio>();
            switch (campo)
            {
                // Recuerda poner Nombre: "%"+ (String)valor + "%", en los campos tipo String
                case "Nombre":
                    res = _0SelByAll(
                        Nombre: "%" + (String)valor + "%",
                        Tipo: tipo,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Descripcion":
                    res = _0SelByAll(
                        Descripcion: "%" + (String)valor + "%",
                        Tipo: tipo,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Porcentaje_Comision":
                    res = _0SelByAll(
                        Porcentaje_Comision: (Decimal?)valor,
                        Tipo: tipo,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Valor":
                    res = _0SelByAll(
                        Valor: (Decimal?)valor,
                        Tipo: tipo,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "No_Periodos":
                    res = _0SelByAll(
                        No_Periodos: (Int32?)valor,
                        Tipo: tipo,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "No_Socios_Regs":
                    res = _0SelByAll(
                        No_Socios_Regs: (Int32?)valor,
                        Tipo: tipo,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;

                default:
                    res = _0SelByAll(
                        Tipo: tipo,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
            }
            return res;
        }
    }
}