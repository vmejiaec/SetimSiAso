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
    /// Completa las funciones de la clase generada automáticamente asoPeriodoDebito
    /// </summary>
    public partial class asoPeriodoDebitoControl
    {
        public IList<asoPeriodoDebito> _0SelByAll(Int32? asoPeriodo_Id, Int32? asoServicio_Id, Int32? asoSocio_Id, string estado, string campo, object valor, Int32 PageIndex, Int32 PageSize, String SortField, String SortDirection)
        {
            IList<asoPeriodoDebito> res = new List<asoPeriodoDebito>();
            switch (campo)
            {
                // Recuerda poner Nombre: "%"+ (String)valor + "%", en los campos tipo String
                case "Descripcion":
                    res = _0SelByAll(
                        asoPeriodo_Id: asoPeriodo_Id,
                        asoServicio_Id: asoServicio_Id,
                        asoSocio_Id: asoSocio_Id,
                        Estado: estado,
                        Descripcion: "%"+(String)valor+"%",
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "asoSocio_Nombre":
                    res = _0SelByAll(
                        asoPeriodo_Id: asoPeriodo_Id,
                        asoServicio_Id: asoServicio_Id,
                        asoSocio_Id: asoSocio_Id,
                        Estado: estado,
                        asoSocio_Nombre:"%"+ (String)valor+"%",
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                default:
                    res = _0SelByAll(
                        asoPeriodo_Id: asoPeriodo_Id,
                        asoServicio_Id: asoServicio_Id,
                        asoSocio_Id: asoSocio_Id,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
            }
            return res;
        }
    }
}