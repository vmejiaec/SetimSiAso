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

    ///<summary>
    ///Controladores para los procedimientos de asoParametro
    ///</summary>
    public partial class asoParametroControl
    {
        LogEventos _eventos = new LogEventos();
        public IList<asoParametro> _0Sel()
        {
            return CBO.FillCollection<asoParametro>(DataProvider.Instance().ExecuteReader(
                "sp_asoParametro_0Sel"

            ));
        }

        public IList<asoParametro> _0SelByAll(Int32? asoPeriodo_Id_Actual = null, Decimal? Porcentaje_Comision_Por_Defecto = null, Decimal? Valor_Reingreso = null, Int32? No_Periodos_Reingreso = null, Decimal? Valor_Accion_Minimo = null, Decimal? Valor_Ahorro_Minimo = null, Decimal? Tasa_Interes_Por_Defecto = null, String Nombre_Largo_Asociacion = null, String Nombre_Corto_Asociacion = null, DateTime? asoPeriodo_Actual_Fecha = null, Int32 PageIndex = 0, Int32 PageSize = 10, String SortField = "Id", String SortDirection = "ASC")
        {
            return CBO.FillCollection<asoParametro>(DataProvider.Instance().ExecuteReader(
                "sp_asoParametro_0SelByAll"
                , asoPeriodo_Id_Actual, Porcentaje_Comision_Por_Defecto, Valor_Reingreso, No_Periodos_Reingreso, Valor_Accion_Minimo, Valor_Ahorro_Minimo, Tasa_Interes_Por_Defecto, Nombre_Largo_Asociacion, Nombre_Corto_Asociacion, asoPeriodo_Actual_Fecha, PageIndex, PageSize, SortField, SortDirection
            ));
        }

        public asoParametro _1SelById(Int32 Id)
        {
            return CBO.FillObject<asoParametro>(DataProvider.Instance().ExecuteReader(
                "sp_asoParametro_1SelById"
                , Id
            ));
        }

        public int _4Del(asoParametro o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoParametro_4Del"
                    , o.Id
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoParametro, operacion: sp_asoParametro_4Del, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        public int _2Ins(asoParametro o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoParametro_2Ins"
                    , o.asoPeriodo_Id_Actual, o.Porcentaje_Comision_Por_Defecto, o.Valor_Reingreso, o.No_Periodos_Reingreso, o.Valor_Accion_Minimo, o.Valor_Ahorro_Minimo, o.Tasa_Interes_Por_Defecto, o.Nombre_Largo_Asociacion, o.Nombre_Corto_Asociacion
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoParametro, operacion: sp_asoParametro_2Ins, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        public int _3Upd(asoParametro o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoParametro_3Upd"
                    , o.Id, o.asoPeriodo_Id_Actual, o.Porcentaje_Comision_Por_Defecto, o.Valor_Reingreso, o.No_Periodos_Reingreso, o.Valor_Accion_Minimo, o.Valor_Ahorro_Minimo, o.Tasa_Interes_Por_Defecto, o.Nombre_Largo_Asociacion, o.Nombre_Corto_Asociacion
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoParametro, operacion: sp_asoParametro_3Upd, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

    }
}