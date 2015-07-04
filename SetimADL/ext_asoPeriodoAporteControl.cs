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
    /// Completa las funciones de la clase generada automáticamente asoPeriodoAporte
    /// </summary>
    public partial class asoPeriodoAporteControl
    {
        public IList<asoPeriodoAporte> _0SelByAll(Int32? asoPeriodo_Id, String tipo, string estado, string campo, object valor, Int32 PageIndex, Int32 PageSize, String SortField, String SortDirection)
        {
            IList<asoPeriodoAporte> res = new List<asoPeriodoAporte>();
            switch (campo)
            {
                // Recuerda poner Nombre: "%"+ (String)valor + "%", en los campos tipo String
                case "Descripcion":
                    res = _0SelByAll(
                        Descripcion: "%" + (String)valor + "%",
                        asoPeriodo_Id: asoPeriodo_Id,
                        Tipo: tipo,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "asoSocio_Nombre":
                    res = _0SelByAll(
                        asoSocio_Nombre: "%" + (String)valor + "%",
                        asoPeriodo_Id: asoPeriodo_Id,
                        Tipo: tipo,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                default:
                    res = _0SelByAll(
                        asoPeriodo_Id: asoPeriodo_Id,
                        Tipo: tipo,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
            }
            return res;
        }
    }
}