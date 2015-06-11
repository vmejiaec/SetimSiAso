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
    /// Completa las funciones de la clase generada automáticamente asoSetimListaDet
    /// </summary>
    public partial class asoSetimListaDetControl
    {
        public IList<asoSetimListaDet> _0SelByAll(string estado, string campo, object valor, Int32 PageIndex, Int32 PageSize, String SortField, String SortDirection)
        {
            IList<asoSetimListaDet> res = new List<asoSetimListaDet>();
            switch (campo)
            {
                case "asoSetimLista_Id":
                    res = _0SelByAll(
                        asoSetimLista_Id: (Int32?)valor,
                        //Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Orden":
                    res = _0SelByAll(
                        Orden: (Int32?)valor,
                        //Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Texto":
                    res = _0SelByAll(
                        Texto: (String)valor,
                        //Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Valor":
                    res = _0SelByAll(
                        Valor: (String)valor,
                        //Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;

                default:
                    res = _0SelByAll(
                        //Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
            }
            return res;
        }
    }
}