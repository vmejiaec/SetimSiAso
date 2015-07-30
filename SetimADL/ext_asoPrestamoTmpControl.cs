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
    /// Completa las funciones de la clase generada automáticamente asoPrestamoTmp
    /// </summary>
    public partial class asoPrestamoTmpControl
    {
        public IList<asoPrestamoTmp> _0SelByAll(string estado, string campo, object valor, Int32 PageIndex, Int32 PageSize, String SortField, String SortDirection)
        {
            IList<asoPrestamoTmp> res = new List<asoPrestamoTmp>();
            switch (campo)
            {
                // Recuerda poner Nombre: "%"+ (String)valor + "%", en los campos tipo String
                case "CI":
                    res = _0SelByAll(
                        CI: (String)valor,
                        //Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Valor_Prestamo":
                    res = _0SelByAll(
                        Valor_Prestamo: (Decimal?)valor,
                        //Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "No_Periodos":
                    res = _0SelByAll(
                        No_Periodos: (Int32?)valor,
                        //Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "No_Periodos_Faltantes":
                    res = _0SelByAll(
                        No_Periodos_Faltantes: (Int32?)valor,
                        //Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Valor_Capital":
                    res = _0SelByAll(
                        Valor_Capital: (Decimal?)valor,
                        //Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Valor_Interes":
                    res = _0SelByAll(
                        Valor_Interes: (Decimal?)valor,
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