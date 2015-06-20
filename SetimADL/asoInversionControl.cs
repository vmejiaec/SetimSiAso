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
    ///Controladores para los procedimientos de asoInversion
    ///</summary>
    public partial class asoInversionControl
    {
        LogEventos _eventos = new LogEventos();
        public IList<asoInversion> _0Sel()
        {
            return CBO.FillCollection<asoInversion>(DataProvider.Instance().ExecuteReader(
                "sp_asoInversion_0Sel"

            ));
        }

        public IList<asoInversion> _0SelByAll(String Nombre = null, String Descripcion = null, Decimal? Porcentaje_Comision = null, String Tipo = null, Decimal? Valor = null, Int32? No_Periodos = null, Int32? No_Socios_Regs = null, Int32 PageIndex = 0, Int32 PageSize = 10, String SortField = "Id", String SortDirection = "ASC")
        {
            return CBO.FillCollection<asoInversion>(DataProvider.Instance().ExecuteReader(
                "sp_asoInversion_0SelByAll"
                , Nombre, Descripcion, Porcentaje_Comision, Tipo, Valor, No_Periodos, No_Socios_Regs, PageIndex, PageSize, SortField, SortDirection
            ));
        }

        public asoInversion _1SelById(Int32 Id)
        {
            return CBO.FillObject<asoInversion>(DataProvider.Instance().ExecuteReader(
                "sp_asoInversion_1SelById"
                , Id
            ));
        }

        public int _4Del(asoInversion o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoInversion_4Del"
                    , o.Id
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoInversion, operacion: sp_asoInversion_4Del, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        public int _2Ins(asoInversion o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoInversion_2Ins"
                    , o.Nombre, o.Descripcion, o.Porcentaje_Comision, o.Tipo, o.Valor, o.No_Periodos
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoInversion, operacion: sp_asoInversion_2Ins, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        public int _3Upd(asoInversion o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoInversion_3Upd"
                    , o.Id, o.Nombre, o.Descripcion, o.Porcentaje_Comision, o.Tipo, o.Valor, o.No_Periodos
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoInversion, operacion: sp_asoInversion_3Upd, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

    }
}