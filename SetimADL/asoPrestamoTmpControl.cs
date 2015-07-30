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
    ///Controladores para los procedimientos de asoPrestamoTmp
    ///</summary>

    [DataObjectAttribute()]
    public partial class asoPrestamoTmpControl
    {
        LogEventos _eventos = new LogEventos();
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoPrestamoTmp> _0Sel()
        {
            return CBO.FillCollection<asoPrestamoTmp>(DataProvider.Instance().ExecuteReader(
                "sp_asoPrestamoTmp_0Sel"

            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoPrestamoTmp> _0SelByAll(String CI = null, Decimal? Valor_Prestamo = null, Int32? No_Periodos = null, Int32? No_Periodos_Faltantes = null, Decimal? Valor_Capital = null, Decimal? Valor_Interes = null, Int32 PageIndex = 0, Int32 PageSize = 10, String SortField = "Id", String SortDirection = "ASC")
        {
            return CBO.FillCollection<asoPrestamoTmp>(DataProvider.Instance().ExecuteReader(
                "sp_asoPrestamoTmp_0SelByAll"
                , CI, Valor_Prestamo, No_Periodos, No_Periodos_Faltantes, Valor_Capital, Valor_Interes, PageIndex, PageSize, SortField, SortDirection
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public asoPrestamoTmp _1SelById(Int32 Id)
        {
            return CBO.FillObject<asoPrestamoTmp>(DataProvider.Instance().ExecuteReader(
                "sp_asoPrestamoTmp_1SelById"
                , Id
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public int _4Del(asoPrestamoTmp o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPrestamoTmp_4Del"
                    , o.Id
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPrestamoTmp, operacion: sp_asoPrestamoTmp_4Del, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public int _2Ins(asoPrestamoTmp o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPrestamoTmp_2Ins"
                    , o.CI, o.Valor_Prestamo, o.No_Periodos, o.No_Periodos_Faltantes, o.Valor_Capital, o.Valor_Interes
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPrestamoTmp, operacion: sp_asoPrestamoTmp_2Ins, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public int _3Upd(asoPrestamoTmp o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPrestamoTmp_3Upd"
                    , o.Id, o.CI, o.Valor_Prestamo, o.No_Periodos, o.No_Periodos_Faltantes, o.Valor_Capital, o.Valor_Interes
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPrestamoTmp, operacion: sp_asoPrestamoTmp_3Upd, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

    }
}