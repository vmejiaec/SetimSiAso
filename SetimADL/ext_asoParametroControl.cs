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
    /// Completa las funciones de la clase generada automáticamente asoParametro
    /// </summary>
    public partial class asoParametroControl
    {
        public IList<asoParametro> _0SelByAll(string estado, string campo, object valor, Int32 PageIndex, Int32 PageSize, String SortField, String SortDirection)
        {
            IList<asoParametro> res = new List<asoParametro>();
            switch (campo)
            {
                // Recuerda poner Nombre: "%"+ (String)valor + "%", en los campos tipo String
                case "asoPeriodo_Id_Actual":
                    res = _0SelByAll(
                        asoPeriodo_Id_Actual: (Int32?)valor,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Porcentaje_Comision_Por_Defecto":
                    res = _0SelByAll(
                        Porcentaje_Comision_Por_Defecto: (Decimal?)valor,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Valor_Reingreso":
                    res = _0SelByAll(
                        Valor_Reingreso: (Decimal?)valor,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "No_Periodos_Reingreso":
                    res = _0SelByAll(
                        No_Periodos_Reingreso: (Int32?)valor,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Valor_Accion_Minimo":
                    res = _0SelByAll(
                        Valor_Accion_Minimo: (Decimal?)valor,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Valor_Ahorro_Minimo":
                    res = _0SelByAll(
                        Valor_Ahorro_Minimo: (Decimal?)valor,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Tasa_Interes_Por_Defecto":
                    res = _0SelByAll(
                        Tasa_Interes_Por_Defecto: (Decimal?)valor,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Nombre_Largo_Asociacion":
                    res = _0SelByAll(
                        Nombre_Largo_Asociacion: (String)valor,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Nombre_Corto_Asociacion":
                    res = _0SelByAll(
                        Nombre_Corto_Asociacion: (String)valor,
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