using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;
using DotNetNuke.Services.Log.EventLog;
using DotNetNuke.Services.Exceptions;

using SetimBasico;

namespace SetimBasico
{

    ///<summary>
    ///Controladores para los procedimientos de asoPeriodoDebito
    ///</summary>

    [DataObjectAttribute()]
    public partial class asoPeriodoDebitoControl
    {
        LogEventos _eventos = new LogEventos();
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoPeriodoDebito> _0SelByasoServicio_Id(Int32 p_asoServicio_Id)
        {
            return CBO.FillCollection<asoPeriodoDebito>(DataProvider.Instance().ExecuteReader(
                "sp_asoPeriodoDebito_0SelByasoServicio_Id"
                , p_asoServicio_Id
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoPeriodoDebito> _0Sel()
        {
            return CBO.FillCollection<asoPeriodoDebito>(DataProvider.Instance().ExecuteReader(
                "sp_asoPeriodoDebito_0Sel"

            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoPeriodoDebito> _0SelByasoServicio_Id_Desc_Coutas(Int32 p_asoServicio_Id)
        {
            return CBO.FillCollection<asoPeriodoDebito>(DataProvider.Instance().ExecuteReader(
                "sp_asoPeriodoDebito_0SelByasoServicio_Id_Desc_Coutas"
                , p_asoServicio_Id
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoPeriodoDebito> _0SelByAll(Int32? asoPeriodo_Id = null, Int32? asoServicio_Id = null, Int32? asoSocio_Id = null, Decimal? Valor = null, Decimal? Valor_Comision = null, String Estado = null, String Descripcion = null, String asoSocio_Nombre = null, DateTime? asoPeriodo_Fecha = null, Decimal? Valor_Mas_Comision = null, Int32? No_Cuotas = null, Int32? No_Cuotas_PEN = null, Int32? No_Cuotas_COB = null, String Desc_Coutas = null, Int32 PageIndex = 0, Int32 PageSize = 10, String SortField = "Id", String SortDirection = "ASC")
        {
            return CBO.FillCollection<asoPeriodoDebito>(DataProvider.Instance().ExecuteReader(
                "sp_asoPeriodoDebito_0SelByAll"
                , asoPeriodo_Id, asoServicio_Id, asoSocio_Id, Valor, Valor_Comision, Estado, Descripcion, asoSocio_Nombre, asoPeriodo_Fecha, Valor_Mas_Comision, No_Cuotas, No_Cuotas_PEN, No_Cuotas_COB, Desc_Coutas, PageIndex, PageSize, SortField, SortDirection
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public asoPeriodoDebito _1SelById(Int32 Id)
        {
            return CBO.FillObject<asoPeriodoDebito>(DataProvider.Instance().ExecuteReader(
                "sp_asoPeriodoDebito_1SelById"
                , Id
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public int _4Del(asoPeriodoDebito o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPeriodoDebito_4Del"
                    , o.Id
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPeriodoDebito, operacion: sp_asoPeriodoDebito_4Del, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public int _2Ins(asoPeriodoDebito o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPeriodoDebito_2Ins"
                    , o.asoPeriodo_Id, o.asoServicio_Id, o.asoSocio_Id, o.Valor, o.Valor_Comision, o.Estado, o.Descripcion
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPeriodoDebito, operacion: sp_asoPeriodoDebito_2Ins, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public int _3Upd(asoPeriodoDebito o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPeriodoDebito_3Upd"
                    , o.Id, o.asoPeriodo_Id, o.asoServicio_Id, o.asoSocio_Id, o.Valor, o.Valor_Comision, o.Estado, o.Descripcion
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPeriodoDebito, operacion: sp_asoPeriodoDebito_3Upd, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        public int _5GenerarDebitosDeUnServicio(Int32 p_asoServicio_Id)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPeriodoDebito_5GenerarDebitosDeUnServicio"
                    , p_asoServicio_Id
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPeriodoDebito, operacion: sp_asoPeriodoDebito_5GenerarDebitosDeUnServicio, parámetros. p_asoServicio_Id:> {0}", p_asoServicio_Id);
                throw new Exception(mensaje, exc);
            }
        }

        public int _5BorrarDebitosPEN(Int32 p_asoServicio_Id, Int32 p_asoPeriodo_Id)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPeriodoDebito_5BorrarDebitosPEN"
                    , p_asoServicio_Id, p_asoPeriodo_Id
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPeriodoDebito, operacion: sp_asoPeriodoDebito_5BorrarDebitosPEN, parámetros. p_asoServicio_Id:> {0}p_asoPeriodo_Id:> {1}", p_asoServicio_Id, p_asoPeriodo_Id);
                throw new Exception(mensaje, exc);
            }
        }

    }
}