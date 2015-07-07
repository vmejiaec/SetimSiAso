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
    ///Controladores para los procedimientos de asoPeriodoAporte
    ///</summary>

    [DataObjectAttribute()]
    public partial class asoPeriodoAporteControl
    {
        LogEventos _eventos = new LogEventos();
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoPeriodoAporte> _0Sel()
        {
            return CBO.FillCollection<asoPeriodoAporte>(DataProvider.Instance().ExecuteReader(
                "sp_asoPeriodoAporte_0Sel"

            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoPeriodoAporte> _0SelByPeriodoYSocio_ConSaldos(Int32 p_asoPeriodo_Id, Int32 p_asoSocio_Id)
        {
            return CBO.FillCollection<asoPeriodoAporte>(DataProvider.Instance().ExecuteReader(
                "sp_asoPeriodoAporte_0SelByPeriodoYSocio_ConSaldos"
                , p_asoPeriodo_Id, p_asoSocio_Id
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoPeriodoAporte> _0SelBy_asoPeriodo_Id_12Regs(Int32 p_asoPeriodo_Id)
        {
            return CBO.FillCollection<asoPeriodoAporte>(DataProvider.Instance().ExecuteReader(
                "sp_asoPeriodoAporte_0SelBy_asoPeriodo_Id_12Regs"
                , p_asoPeriodo_Id
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoPeriodoAporte> _0SelByAll(Int32? asoPeriodo_Id = null, Int32? asoSocio_Id = null, String Tipo = null, String Estado = null, String Descripcion = null, String asoSocio_Nombre = null, DateTime? asoPeriodo_Fecha = null, Decimal? Valor_Accion = null, Decimal? Valor_Ahorro = null, Decimal? Valor_Voluntario = null, Decimal? Valor_Suma = null, Decimal? Valor_Saldo_Accion = null, Decimal? Valor_Saldo_Ahorro = null, Decimal? Valor_Saldo_Voluntario = null, Int32 PageIndex = 0, Int32 PageSize = 10, String SortField = "Id", String SortDirection = "ASC")
        {
            return CBO.FillCollection<asoPeriodoAporte>(DataProvider.Instance().ExecuteReader(
                "sp_asoPeriodoAporte_0SelByAll"
                , asoPeriodo_Id, asoSocio_Id, Tipo, Estado, Descripcion, asoSocio_Nombre, asoPeriodo_Fecha, Valor_Accion, Valor_Ahorro, Valor_Voluntario, Valor_Suma, Valor_Saldo_Accion, Valor_Saldo_Ahorro, Valor_Saldo_Voluntario, PageIndex, PageSize, SortField, SortDirection
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public asoPeriodoAporte _1SelById(Int32 Id)
        {
            return CBO.FillObject<asoPeriodoAporte>(DataProvider.Instance().ExecuteReader(
                "sp_asoPeriodoAporte_1SelById"
                , Id
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public int _3Upd(asoPeriodoAporte o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPeriodoAporte_3Upd"
                    , o.Id, o.asoPeriodo_Id, o.asoSocio_Id, o.Tipo, o.Estado, o.Descripcion, o.Valor_Accion, o.Valor_Ahorro, o.Valor_Voluntario
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPeriodoAporte, operacion: sp_asoPeriodoAporte_3Upd, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public int _4Del(asoPeriodoAporte o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPeriodoAporte_4Del"
                    , o.Id
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPeriodoAporte, operacion: sp_asoPeriodoAporte_4Del, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public int _2Ins(asoPeriodoAporte o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPeriodoAporte_2Ins"
                    , o.asoPeriodo_Id, o.asoSocio_Id, o.Tipo, o.Estado, o.Descripcion, o.Valor_Accion, o.Valor_Ahorro, o.Valor_Voluntario
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPeriodoAporte, operacion: sp_asoPeriodoAporte_2Ins, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

    }
}