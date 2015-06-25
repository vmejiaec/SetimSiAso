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
    ///Controladores para los procedimientos de asoServicio
    ///</summary>
    public partial class asoServicioControl
    {
        LogEventos _eventos = new LogEventos();
        public IList<asoServicio> _0Sel()
        {
            return CBO.FillCollection<asoServicio>(DataProvider.Instance().ExecuteReader(
                "sp_asoServicio_0Sel"

            ));
        }

        public IList<asoServicio> _0SelByAll(String Nombre = null, String Descripcion = null, Decimal? Porcentaje_Comision = null, String Tipo = null, Decimal? Valor = null, Int32? No_Periodos = null, Int32? No_Socios_Regs = null, Int32 PageIndex = 0, Int32 PageSize = 10, String SortField = "Id", String SortDirection = "ASC")
        {
            return CBO.FillCollection<asoServicio>(DataProvider.Instance().ExecuteReader(
                "sp_asoServicio_0SelByAll"
                , Nombre, Descripcion, Porcentaje_Comision, Tipo, Valor, No_Periodos, No_Socios_Regs, PageIndex, PageSize, SortField, SortDirection
            ));
        }

        public asoServicio _1SelById(Int32 Id)
        {
            return CBO.FillObject<asoServicio>(DataProvider.Instance().ExecuteReader(
                "sp_asoServicio_1SelById"
                , Id
            ));
        }

        public int _4Del(asoServicio o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoServicio_4Del"
                    , o.Id
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoServicio, operacion: sp_asoServicio_4Del, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        public int _2Ins(asoServicio o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoServicio_2Ins"
                    , o.Nombre, o.Descripcion, o.Porcentaje_Comision, o.Tipo, o.Valor, o.No_Periodos
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoServicio, operacion: sp_asoServicio_2Ins, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        public int _3Upd(asoServicio o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoServicio_3Upd"
                    , o.Id, o.Nombre, o.Descripcion, o.Porcentaje_Comision, o.Tipo, o.Valor, o.No_Periodos
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoServicio, operacion: sp_asoServicio_3Upd, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

    }
}