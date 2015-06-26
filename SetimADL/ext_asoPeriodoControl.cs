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
    /// Completa las funciones de la clase generada automáticamente asoPeriodo
    /// </summary>
    public partial class asoPeriodoControl
    {
        public IList<asoPeriodo> _0SelByAll(string estado, string campo, object valor, Int32 PageIndex, Int32 PageSize, String SortField, String SortDirection)
        {
            IList<asoPeriodo> res = new List<asoPeriodo>();
            switch (campo)
            {
                case "No_Periodo":
                    Int32? iValor;
                    try
                    {
                        iValor = Int32.Parse((string)valor);
                    }
                    catch (Exception e)
                    {
                        iValor = (Int32?)null;
                    }
                    res = _0SelByAll(
                        No_Periodo: iValor,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Fecha_Periodo":
                    res = _0SelByAll(
                        Fecha_Periodo: (DateTime?)valor,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Descripcion":
                    res = _0SelByAll(
                        Descripcion: "%" + (String)valor + "%",
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                default:
                    res = _0SelByAll(
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
            }
            return res;
        }
    }
}