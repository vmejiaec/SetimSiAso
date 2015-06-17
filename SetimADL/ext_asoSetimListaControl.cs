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
    /// Completa las funciones de la clase generada automáticamente asoSetimLista
    /// </summary>
    public partial class asoSetimListaControl
    {
        public IList<asoSetimLista> _0SelByAll(string estado, string campo, object valor, Int32 PageIndex, Int32 PageSize, String SortField, String SortDirection)
        {
            IList<asoSetimLista> res = new List<asoSetimLista>();
            switch (campo)
            {
                case "Nombre":
                    res = _0SelByAll(
                        Nombre: "%"+ (String)valor +"%",
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Descripcion":
                    res = _0SelByAll(
                        Descripcion: "%" + (String)valor + "%",
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Detalles":
                    res = _0SelByAll(
                        Detalles: "%" + (String)valor + "%",
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;

                default:
                    res = _0SelByAll(
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
            }
            return res;
        }
    }
}