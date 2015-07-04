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
    /// Completa las funciones de la clase generada automáticamente asoPrestamo
    /// </summary>
    public partial class asoPrestamoControl
    {
        public IList<asoPrestamo> _0SelByAll(string estado, string campo, object valor, Int32 PageIndex, Int32 PageSize, String SortField, String SortDirection)
        {
            IList<asoPrestamo> res = new List<asoPrestamo>();
            switch (campo)
            {
                // Recuerda poner Nombre: "%"+ (String)valor + "%", en los campos tipo String
                case "asoSocio_Id":
                    res = _0SelByAll(
                        asoSocio_Id: (Int32?)valor,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Valor":
                    res = _0SelByAll(
                        Valor: (Decimal?)valor,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Tasa_Interes":
                    res = _0SelByAll(
                        Tasa_Interes: (Decimal?)valor,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "No_Periodos":
                    res = _0SelByAll(
                        No_Periodos: (Int32?)valor,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Fecha_Solicitud":
                    res = _0SelByAll(
                        Fecha_Solicitud: (DateTime?)valor,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "asoSocio_Id_Garante":
                    res = _0SelByAll(
                        asoSocio_Id_Garante: (Int32?)valor,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Descripcion":
                    res = _0SelByAll(
                        Descripcion: (String)valor,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "asoSocio_Nombre":
                    res = _0SelByAll(
                        asoSocio_Nombre: (String)valor,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "asoSocio_Nombre_Garante":
                    res = _0SelByAll(
                        asoSocio_Nombre_Garante: (String)valor,
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