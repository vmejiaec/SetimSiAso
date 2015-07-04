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
    ///Controladores para los procedimientos de asoPrestamo
    ///</summary>

    [DataObjectAttribute()]
    public partial class asoPrestamoControl
    {
        LogEventos _eventos = new LogEventos();
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoPrestamo> _0Sel()
        {
            return CBO.FillCollection<asoPrestamo>(DataProvider.Instance().ExecuteReader(
                "sp_asoPrestamo_0Sel"

            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public IList<asoPrestamo> _0SelByAll(Int32? asoSocio_Id = null, Decimal? Valor = null, Decimal? Tasa_Interes = null, Int32? No_Periodos = null, DateTime? Fecha_Solicitud = null, Int32? asoSocio_Id_Garante = null, String Estado = null, String Descripcion = null, String asoSocio_Nombre = null, String asoSocio_Nombre_Garante = null, Int32 PageIndex = 0, Int32 PageSize = 10, String SortField = "Id", String SortDirection = "ASC")
        {
            return CBO.FillCollection<asoPrestamo>(DataProvider.Instance().ExecuteReader(
                "sp_asoPrestamo_0SelByAll"
                , asoSocio_Id, Valor, Tasa_Interes, No_Periodos, Fecha_Solicitud, asoSocio_Id_Garante, Estado, Descripcion, asoSocio_Nombre, asoSocio_Nombre_Garante, PageIndex, PageSize, SortField, SortDirection
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public asoPrestamo _1SelById(Int32 Id)
        {
            return CBO.FillObject<asoPrestamo>(DataProvider.Instance().ExecuteReader(
                "sp_asoPrestamo_1SelById"
                , Id
            ));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public int _4Del(asoPrestamo o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPrestamo_4Del"
                    , o.Id
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPrestamo, operacion: sp_asoPrestamo_4Del, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public int _2Ins(asoPrestamo o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPrestamo_2Ins"
                    , o.asoSocio_Id, o.Valor, o.Tasa_Interes, o.No_Periodos, o.Fecha_Solicitud, o.asoSocio_Id_Garante, o.Estado, o.Descripcion
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPrestamo, operacion: sp_asoPrestamo_2Ins, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public int _3Upd(asoPrestamo o)
        {
            try
            {
                return DataProvider.Instance().ExecuteScalar<int>(
                    "sp_asoPrestamo_3Upd"
                    , o.Id, o.asoSocio_Id, o.Valor, o.Tasa_Interes, o.No_Periodos, o.Fecha_Solicitud, o.asoSocio_Id_Garante, o.Estado, o.Descripcion
                    );
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                string mensaje = string.Format("Error en: asoPrestamo, operacion: sp_asoPrestamo_3Upd, registro {0}.", o.Id);
                throw new Exception(mensaje, exc);
            }
        }

    }
}