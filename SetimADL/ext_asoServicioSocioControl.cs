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
    /// Completa las funciones de la clase generada automáticamente asoServicioSocio
    /// </summary>
    public partial class asoServicioSocioControl
    {
        public IList<asoServicioSocio> _0SelByAll(Int32? asoServicio_Id, string campo, object valor, Int32 PageIndex, Int32 PageSize, String SortField, String SortDirection)
        {
            IList<asoServicioSocio> res = new List<asoServicioSocio>();
            switch (campo)
            {
                // Recuerda poner Nombre: "%"+ (String)valor + "%", en los campos tipo String
                case "asoSocio_Id":
                    res = _0SelByAll(
                        asoSocio_Id: (Int32?)valor,
                        asoServicio_Id: asoServicio_Id,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "asoSocio_Nombre":
                    res = _0SelByAll(
                        asoSocio_Nombre: "%" + (String)valor + "%",
                        asoServicio_Id: asoServicio_Id,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;

                default:
                    res = _0SelByAll(
                        asoServicio_Id: asoServicio_Id,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
            }
            return res;
        }
    }
}