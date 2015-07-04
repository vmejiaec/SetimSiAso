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
    /// Completa las funciones de la clase generada automáticamente asoPeriodoCuota
    /// </summary>
    public partial class asoPeriodoCuotaControl
    {
        public IList<asoPeriodoCuota> _0SelByAll(Int32? asoPrestamo_Id, string estado, string campo, object valor, Int32 PageIndex, Int32 PageSize, String SortField, String SortDirection)
        {
            IList<asoPeriodoCuota> res = new List<asoPeriodoCuota>();
            switch (campo)
            {
                // Recuerda poner Nombre: "%"+ (String)valor + "%", en los campos tipo String
                case "asoPeriodo_Id":
                    res = _0SelByAll(
                        asoPrestamo_Id: asoPrestamo_Id,
                        asoPeriodo_Id: (Int32?)valor,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Valor_Capital":
                    res = _0SelByAll(
                        asoPrestamo_Id: asoPrestamo_Id,
                        Valor_Capital: (Decimal?)valor,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Valor_Interes":
                    res = _0SelByAll(
                        asoPrestamo_Id: asoPrestamo_Id,
                        Valor_Interes: (Decimal?)valor,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Descripcion":
                    res = _0SelByAll(
                        asoPrestamo_Id: asoPrestamo_Id,
                        Descripcion: (String)valor,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "asoSocio_Nombre":
                    res = _0SelByAll(
                        asoPrestamo_Id: asoPrestamo_Id,
                        asoSocio_Nombre: (String)valor,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "asoPeriodo_Fecha":
                    res = _0SelByAll(
                        asoPrestamo_Id: asoPrestamo_Id,
                        asoPeriodo_Fecha: (DateTime?)valor,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;

                default:
                    res = _0SelByAll(
                        asoPrestamo_Id: asoPrestamo_Id,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
            }
            return res;
        }
    }
}