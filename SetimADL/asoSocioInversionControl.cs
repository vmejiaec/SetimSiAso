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
    ///Controladores para los procedimientos de asoSocioInversion
    ///</summary>
    public partial class asoSocioInversionControl
    {
        LogEventos _eventos = new LogEventos();
        public IList<asoSocioInversion> _0Sel()
        {
            return CBO.FillCollection<asoSocioInversion>(DataProvider.Instance().ExecuteReader(
                "sp_asoSocioInversion_0Sel"

            ));
        }

        public IList<asoSocioInversion> _0SelByAll(Int32? asoSocio_Id = null, Int32? asoInversion_Id = null, String asoSocio_Nombre = null, Int32 PageIndex = 0, Int32 PageSize = 10, String SortField = "Id", String SortDirection = "ASC")
        {
            return CBO.FillCollection<asoSocioInversion>(DataProvider.Instance().ExecuteReader(
                "sp_asoSocioInversion_0SelByAll"
                , asoSocio_Id, asoInversion_Id, asoSocio_Nombre, PageIndex, PageSize, SortField, SortDirection
            ));
        }

        public asoSocioInversion _1SelById(Int32 Id)
        {
            return CBO.FillObject<asoSocioInversion>(DataProvider.Instance().ExecuteReader(
                "sp_asoSocioInversion_1SelById"
                , Id
            ));
        }

        public int _4Del(asoSocioInversion o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoSocioInversion_4Del"
                    , o.Id
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoSocioInversion, operacion: sp_asoSocioInversion_4Del, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        public int _2Ins(asoSocioInversion o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoSocioInversion_2Ins"
                    , o.asoSocio_Id, o.asoInversion_Id
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoSocioInversion, operacion: sp_asoSocioInversion_2Ins, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        public int _3Upd(asoSocioInversion o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoSocioInversion_3Upd"
                    , o.Id, o.asoSocio_Id, o.asoInversion_Id
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoSocioInversion, operacion: sp_asoSocioInversion_3Upd, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

    }
}