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
    ///Controladores para los procedimientos de asoSetimLista
    ///</summary>
    public partial class asoSetimListaControl
    {
        LogEventos _eventos = new LogEventos();
        public IList<asoSetimLista> _0Sel()
        {
            return CBO.FillCollection<asoSetimLista>(DataProvider.Instance().ExecuteReader(
                "sp_asoSetimLista_0Sel"

            ));
        }

        public IList<asoSetimLista> _0SelByAll(String Nombre = null, Int32 PageIndex = 0, Int32 PageSize = 10, String SortField = "Id", String SortDirection = "ASC")
        {
            return CBO.FillCollection<asoSetimLista>(DataProvider.Instance().ExecuteReader(
                "sp_asoSetimLista_0SelByAll"
                , Nombre, PageIndex, PageSize, SortField, SortDirection
            ));
        }

        public asoSetimLista _1SelById(Int32 Id)
        {
            return CBO.FillObject<asoSetimLista>(DataProvider.Instance().ExecuteReader(
                "sp_asoSetimLista_1SelById"
                , Id
            ));
        }

        public int _4Del(asoSetimLista o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoSetimLista_4Del"
                    , o.Id
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoSetimLista, operacion: sp_asoSetimLista_4Del, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        public int _2Ins(asoSetimLista o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoSetimLista_2Ins"
                    , o.Nombre
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoSetimLista, operacion: sp_asoSetimLista_2Ins, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        public int _3Upd(asoSetimLista o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoSetimLista_3Upd"
                    , o.Id, o.Nombre
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoSetimLista, operacion: sp_asoSetimLista_3Upd, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

    }
}