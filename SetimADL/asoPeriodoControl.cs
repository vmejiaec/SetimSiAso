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
    ///Controladores para los procedimientos de asoPeriodo
    ///</summary>
    public class asoPeriodoControl
    {
        LogEventos _eventos = new LogEventos();
        public IList<asoPeriodo> _0Sel()
        {
            return CBO.FillCollection<asoPeriodo>(DataProvider.Instance().ExecuteReader(
                "sp_asoPeriodo_0Sel"

            ));
        }

        public IList<asoPeriodo> _0SelByAll(Int32? No_Periodo, DateTime? Fecha_Periodo, String Estado, String Descripcion, Int32 PageIndex, Int32 PageSize, String SortField, String SortDirection)
        {
            return CBO.FillCollection<asoPeriodo>(DataProvider.Instance().ExecuteReader(
                "sp_asoPeriodo_0SelByAll"
                , No_Periodo, Fecha_Periodo, Estado, Descripcion, PageIndex, PageSize, SortField, SortDirection
            ));
        }

        public asoPeriodo _1SelById(Int32 Id)
        {
            return CBO.FillObject<asoPeriodo>(DataProvider.Instance().ExecuteReader(
                "sp_asoPeriodo_1SelById"
                , Id
            ));
        }

        public int _3Upd(asoPeriodo o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPeriodo_3Upd"
                    , o.Id, o.No_Periodo, o.Fecha_Periodo, o.Estado, o.Descripcion
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPeriodo, operacion: sp_asoPeriodo_3Upd, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        public int _4Del(asoPeriodo o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPeriodo_4Del"
                    , o.Id
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPeriodo, operacion: sp_asoPeriodo_4Del, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        public int _2Ins(asoPeriodo o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPeriodo_2Ins"
                    , o.No_Periodo, o.Fecha_Periodo, o.Estado, o.Descripcion
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPeriodo, operacion: sp_asoPeriodo_2Ins, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        public int _5GenerarPeriodos(Int32 p_No_Periodos_a_Generar)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPeriodo_5GenerarPeriodos"
                    , p_No_Periodos_a_Generar
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPeriodo, operacion: sp_asoPeriodo_5GenerarPeriodos, parámetros. p_No_Periodos_a_Generar:> {0}", p_No_Periodos_a_Generar);
                throw new Exception(mensaje, exc);
            }
        }

    }
}