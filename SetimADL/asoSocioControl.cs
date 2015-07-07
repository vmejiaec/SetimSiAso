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
    ///Controladores para los procedimientos de asoSocio
    ///</summary>

    [DataObjectAttribute()]
    public partial class asoSocioControl
    {
        LogEventos _eventos = new LogEventos();
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoSocio> _0Sel()
        {
            return CBO.FillCollection<asoSocio>(DataProvider.Instance().ExecuteReader(
                "sp_asoSocio_0Sel"

            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoSocio> _0SelBy_asoServicio_Id_By_Prefijo(Int32 p_asoServicio_Id, String p_Prefijo)
        {
            return CBO.FillCollection<asoSocio>(DataProvider.Instance().ExecuteReader(
                "sp_asoSocio_0SelBy_asoServicio_Id_By_Prefijo"
                , p_asoServicio_Id, p_Prefijo
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoSocio> _0SelByEstado(String Estado)
        {
            return CBO.FillCollection<asoSocio>(DataProvider.Instance().ExecuteReader(
                "sp_asoSocio_0SelByEstado"
                , Estado
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoSocio> _0SelByAll(Int32? UserID = null, String CI = null, String Descripcion = null, DateTime? Fecha_Nacimiento = null, String Estado = null, String Users_EMail = null, String Users_Nombre = null, Decimal? Valor_Accion = null, Decimal? Valor_Ahorro = null, Int32 PageIndex = 0, Int32 PageSize = 10, String SortField = "Id", String SortDirection = "ASC")
        {
            return CBO.FillCollection<asoSocio>(DataProvider.Instance().ExecuteReader(
                "sp_asoSocio_0SelByAll"
                , UserID, CI, Descripcion, Fecha_Nacimiento, Estado, Users_EMail, Users_Nombre, Valor_Accion, Valor_Ahorro, PageIndex, PageSize, SortField, SortDirection
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public asoSocio _1SelById(Int32 Id)
        {
            return CBO.FillObject<asoSocio>(DataProvider.Instance().ExecuteReader(
                "sp_asoSocio_1SelById"
                , Id
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public asoSocio _1SelByUserID(Int32 p_UserID)
        {
            return CBO.FillObject<asoSocio>(DataProvider.Instance().ExecuteReader(
                "sp_asoSocio_1SelByUserID"
                , p_UserID
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public int _4Del(asoSocio o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoSocio_4Del"
                    , o.Id
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoSocio, operacion: sp_asoSocio_4Del, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public int _2Ins(asoSocio o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoSocio_2Ins"
                    , o.UserID, o.CI, o.Descripcion, o.Fecha_Nacimiento, o.Estado, o.Valor_Accion, o.Valor_Ahorro
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoSocio, operacion: sp_asoSocio_2Ins, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public int _3Upd(asoSocio o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoSocio_3Upd"
                    , o.Id, o.UserID, o.CI, o.Descripcion, o.Fecha_Nacimiento, o.Estado, o.Valor_Accion, o.Valor_Ahorro
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoSocio, operacion: sp_asoSocio_3Upd, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        public int _5CopyFromUsers()
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoSocio_5CopyFromUsers"

                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoSocio, operacion: sp_asoSocio_5CopyFromUsers, parámetros. ");
                throw new Exception(mensaje, exc);
            }
        }

        public int _5NoUsuariosPorEstado(String Estado)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoSocio_5NoUsuariosPorEstado"
                    , Estado
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoSocio, operacion: sp_asoSocio_5NoUsuariosPorEstado, parámetros. Estado:> {0}", Estado);
                throw new Exception(mensaje, exc);
            }
        }

    }
}