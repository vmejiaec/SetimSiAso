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
    ///Controladores para los procedimientos de asoSetimListaDet
    ///</summary>
    public partial class asoSetimListaDetControl
    {
        LogEventos _eventos = new LogEventos();
        public IList<asoSetimListaDet> _0SelBy_asoSetimLista_Nombre(String asoSetimLista_Nombre)
        {
            return CBO.FillCollection<asoSetimListaDet>(DataProvider.Instance().ExecuteReader(
                "sp_asoSetimListaDet_0SelBy_asoSetimLista_Nombre"
                , asoSetimLista_Nombre
            ));
        }

        public IList<asoSetimListaDet> _0Sel()
        {
            return CBO.FillCollection<asoSetimListaDet>(DataProvider.Instance().ExecuteReader(
                "sp_asoSetimListaDet_0Sel"

            ));
        }

        public IList<asoSetimListaDet> _0SelByAll(Int32? asoSetimLista_Id = null, Int32? Orden = null, String Texto = null, String Valor = null, Int32 PageIndex = 0, Int32 PageSize = 10, String SortField = "Id", String SortDirection = "ASC")
        {
            return CBO.FillCollection<asoSetimListaDet>(DataProvider.Instance().ExecuteReader(
                "sp_asoSetimListaDet_0SelByAll"
                , asoSetimLista_Id, Orden, Texto, Valor, PageIndex, PageSize, SortField, SortDirection
            ));
        }

        public asoSetimListaDet _1SelById(Int32 Id)
        {
            return CBO.FillObject<asoSetimListaDet>(DataProvider.Instance().ExecuteReader(
                "sp_asoSetimListaDet_1SelById"
                , Id
            ));
        }

        public int _4Del(asoSetimListaDet o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoSetimListaDet_4Del"
                    , o.Id
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoSetimListaDet, operacion: sp_asoSetimListaDet_4Del, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        public int _2Ins(asoSetimListaDet o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoSetimListaDet_2Ins"
                    , o.asoSetimLista_Id, o.Orden, o.Texto, o.Valor
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoSetimListaDet, operacion: sp_asoSetimListaDet_2Ins, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        public int _3Upd(asoSetimListaDet o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoSetimListaDet_3Upd"
                    , o.Id, o.asoSetimLista_Id, o.Orden, o.Texto, o.Valor
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoSetimListaDet, operacion: sp_asoSetimListaDet_3Upd, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

    }
}