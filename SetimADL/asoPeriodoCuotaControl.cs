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
    ///Controladores para los procedimientos de asoPeriodoCuota
    ///</summary>

    [DataObjectAttribute()]
    public partial class asoPeriodoCuotaControl
    {
        LogEventos _eventos = new LogEventos();
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoPeriodoCuota> _0SelByasoPrestamo_Id(Int32 p_asoPrestamo_Id)
        {
            return CBO.FillCollection<asoPeriodoCuota>(DataProvider.Instance().ExecuteReader(
                "sp_asoPeriodoCuota_0SelByasoPrestamo_Id"
                , p_asoPrestamo_Id
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoPeriodoCuota> _0Sel()
        {
            return CBO.FillCollection<asoPeriodoCuota>(DataProvider.Instance().ExecuteReader(
                "sp_asoPeriodoCuota_0Sel"

            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoPeriodoCuota> _0SelByasoSocio_Id(Int32 p_asoSocio_Id, Int32 p_asoPeriodo_Id)
        {
            return CBO.FillCollection<asoPeriodoCuota>(DataProvider.Instance().ExecuteReader(
                "sp_asoPeriodoCuota_0SelByasoSocio_Id"
                , p_asoSocio_Id, p_asoPeriodo_Id
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoPeriodoCuota> _0SelByAll(Int32? asoPeriodo_Id = null, Int32? asoPrestamo_Id = null, Decimal? Valor_Capital = null, Decimal? Valor_Interes = null, String Estado = null, String Descripcion = null, String asoSocio_Nombre = null, DateTime? asoPeriodo_Fecha = null, Decimal? Valor_Suma = null, Int32? asoSocio_Id = null, Int32? No_Cuotas = null, Int32? No_Cuotas_PEN = null, Int32? No_Cuotas_COB = null, String Desc_Cuotas = null, Int32 PageIndex = 0, Int32 PageSize = 10, String SortField = "Id", String SortDirection = "ASC")
        {
            return CBO.FillCollection<asoPeriodoCuota>(DataProvider.Instance().ExecuteReader(
                "sp_asoPeriodoCuota_0SelByAll"
                , asoPeriodo_Id, asoPrestamo_Id, Valor_Capital, Valor_Interes, Estado, Descripcion, asoSocio_Nombre, asoPeriodo_Fecha, Valor_Suma, asoSocio_Id, No_Cuotas, No_Cuotas_PEN, No_Cuotas_COB, Desc_Cuotas, PageIndex, PageSize, SortField, SortDirection
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public asoPeriodoCuota _1SelById(Int32 Id)
        {
            return CBO.FillObject<asoPeriodoCuota>(DataProvider.Instance().ExecuteReader(
                "sp_asoPeriodoCuota_1SelById"
                , Id
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public int _4Del(asoPeriodoCuota o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPeriodoCuota_4Del"
                    , o.Id
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPeriodoCuota, operacion: sp_asoPeriodoCuota_4Del, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public int _2Ins(asoPeriodoCuota o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPeriodoCuota_2Ins"
                    , o.asoPeriodo_Id, o.asoPrestamo_Id, o.Valor_Capital, o.Valor_Interes, o.Estado, o.Descripcion
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPeriodoCuota, operacion: sp_asoPeriodoCuota_2Ins, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public int _3Upd(asoPeriodoCuota o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPeriodoCuota_3Upd"
                    , o.Id, o.asoPeriodo_Id, o.asoPrestamo_Id, o.Valor_Capital, o.Valor_Interes, o.Estado, o.Descripcion
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPeriodoCuota, operacion: sp_asoPeriodoCuota_3Upd, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

    }
}