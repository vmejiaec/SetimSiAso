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
    ///Controladores para los procedimientos de asoServicioSocio
    ///</summary>

    [DataObjectAttribute()]
    public partial class asoServicioSocioControl
    {
        LogEventos _eventos = new LogEventos();
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoServicioSocio> _0Sel()
        {
            return CBO.FillCollection<asoServicioSocio>(DataProvider.Instance().ExecuteReader(
                "sp_asoServicioSocio_0Sel"

            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoServicioSocio> _0SelByAll(Int32? asoSocio_Id = null, Int32? asoServicio_Id = null, String asoSocio_Nombre = null, Decimal? Valor = null, Int32? No_Periodos = null, Int32 PageIndex = 0, Int32 PageSize = 10, String SortField = "Id", String SortDirection = "ASC")
        {
            return CBO.FillCollection<asoServicioSocio>(DataProvider.Instance().ExecuteReader(
                "sp_asoServicioSocio_0SelByAll"
                , asoSocio_Id, asoServicio_Id, asoSocio_Nombre, Valor, No_Periodos, PageIndex, PageSize, SortField, SortDirection
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public asoServicioSocio _1SelById(Int32 Id)
        {
            return CBO.FillObject<asoServicioSocio>(DataProvider.Instance().ExecuteReader(
                "sp_asoServicioSocio_1SelById"
                , Id
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public int _4Del(asoServicioSocio o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoServicioSocio_4Del"
                    , o.Id
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoServicioSocio, operacion: sp_asoServicioSocio_4Del, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public int _2Ins(asoServicioSocio o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoServicioSocio_2Ins"
                    , o.asoSocio_Id, o.asoServicio_Id, o.asoSocio_Nombre, o.Valor, o.No_Periodos
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoServicioSocio, operacion: sp_asoServicioSocio_2Ins, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public int _3Upd(asoServicioSocio o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoServicioSocio_3Upd"
                    , o.Id, o.asoSocio_Id, o.asoServicio_Id, o.asoSocio_Nombre, o.Valor, o.No_Periodos
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoServicioSocio, operacion: sp_asoServicioSocio_3Upd, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        public int _5CargaSociosActivos(Int32 p_asoServicio_Id)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoServicioSocio_5CargaSociosActivos"
                    , p_asoServicio_Id
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoServicioSocio, operacion: sp_asoServicioSocio_5CargaSociosActivos, parámetros. p_asoServicio_Id:> {0}", p_asoServicio_Id);
                throw new Exception(mensaje, exc);
            }
        }

    }
}