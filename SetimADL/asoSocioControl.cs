﻿using System;
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
    ///Controladores para los procedimientos de asoSocio
    ///</summary>
    public class asoSocioControl
    {
        LogEventos _eventos = new LogEventos();
        public IList<asoSocio> sp_asoSocio_0Sel()
        {
            var dr = DataProvider.Instance().ExecuteReader("sp_asoSocio_0Sel");
            return CBO.FillCollection<asoSocio>(dr);
        }

        public IList<asoSocio> sp_asoSocio_0SelByAll(Int32 UserID, String CI, String Descripcion, DateTime Fecha_Nacimiento, String Estado, Int32 PageIndex, Int32 PageSize, String SortField, String SortDirection)
        {
            return CBO.FillCollection<asoSocio>(DataProvider.Instance().ExecuteReader(
                "sp_asoSocio_0SelByAll"
                , UserID, CI, Descripcion, Fecha_Nacimiento, Estado, PageIndex, PageSize, SortField, SortDirection
            ));
        }

        public IList<asoSocio> sp_asoSocio_0SelByEstado(String Estado)
        {
            return CBO.FillCollection<asoSocio>(DataProvider.Instance().ExecuteReader(
                "sp_asoSocio_0SelByEstado"
                , Estado
            ));
        }

        public asoSocio sp_asoSocio_1SelById(Int32 Id)
        {
            return CBO.FillObject<asoSocio>(DataProvider.Instance().ExecuteReader(
                "sp_asoSocio_1SelById"
                , Id
            ));
        }

        public int sp_asoSocio_4Del(asoSocio o)
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
                throw new Exception(mensaje,exc);
            }
        }

        public int sp_asoSocio_2Ins(asoSocio o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoSocio_2Ins"
                    , o.UserID, o.CI, o.Descripcion, o.Fecha_Nacimiento, o.Estado
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoSocio, operacion: sp_asoSocio_2Ins, registro {0}.", o.Id);
                throw new Exception(mensaje,exc);
            }
        }

        public int sp_asoSocio_3Upd(asoSocio o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoSocio_3Upd"
                    , o.Id, o.UserID, o.CI, o.Descripcion, o.Fecha_Nacimiento, o.Estado
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoSocio, operacion: sp_asoSocio_3Upd, registro {0}.", o.Id);
                throw new Exception(mensaje,exc);
            }
        }

        public int sp_asoSocio_5CopyFromUsers()
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
                throw new Exception(mensaje,exc);
            }
        }

        public int sp_asoSocio_5NoUsuariosPorEstado(String Estado)
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
                throw new Exception(mensaje,exc);
            }
        }

    }
}