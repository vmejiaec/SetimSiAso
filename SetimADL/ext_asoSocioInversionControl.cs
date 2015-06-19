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
    /// Completa las funciones de la clase generada automáticamente asoSocioInversion
    /// </summary>
    public partial class asoSocioInversionControl
    {
        public IList<asoSocioInversion> _0SelByAll(Int32? asoInversion_Id, string campo, object valor, Int32 PageIndex, Int32 PageSize, String SortField, String SortDirection)
        {
            IList<asoSocioInversion> res = new List<asoSocioInversion>();
            switch (campo)
            {
                case "asoSocio_Id":
                    res = _0SelByAll(
                        asoSocio_Id: (Int32?)valor,
                        asoInversion_Id: asoInversion_Id,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "asoSocio_Nombre":
                    res = _0SelByAll(
                        asoSocio_Nombre: (String)valor,
                        asoInversion_Id: asoInversion_Id,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "No_Socios_Regs":
                    res = _0SelByAll(
                        No_Socios_Regs: (Int32?)valor,
                        asoInversion_Id: asoInversion_Id,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;

                default:
                    res = _0SelByAll(
                        asoInversion_Id: asoInversion_Id,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
            }
            return res;
        }
    }
}