﻿using System;
using DotNetNuke.Common;
using SetimBasico;
using Microsoft.Reporting.WebForms;
using DotNetNuke.Entities.Users;

namespace SetimMod_asoServicio
{
    public partial class asoPeriodoDebito_Rep : SetimModulo
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this._Nivel = 1;
            if (!IsPostBack)
            {
                CargaParametrosAlReporte();
            }
        }
        void CargaParametrosAlReporte()
        {
            // Obtiene los datos para el reporte
            asoPeriodoDebitoControl ctlPeriodoDebito = new asoPeriodoDebitoControl();
            var lstDebitos = ctlPeriodoDebito._0SelByasoServicio_Id_Desc_Coutas((int)paginaEstadoMaster.Master_Id);
            rv_Reporte.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", lstDebitos));
            // Obtiene el nombre del servicio
            asoServicioControl ctrServicio = new asoServicioControl();
            var oServicio = ctrServicio._1SelById((int)paginaEstadoMaster.Master_Id);
            //
            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("rp_Usuario_Nombre",this._Usuario_Nombre);
            parametros[1] = new ReportParameter("rp_Titulo", oServicio.Nombre);
            
            rv_Reporte.LocalReport.SetParameters(parametros);
            rv_Reporte.LocalReport.Refresh();
        }
        // Cierra el reporte
        protected void Salir(object sender, EventArgs e)
        {
            string url = Globals.NavigateURL();
            if (this._Nivel != 0)
                url = string.Format("{0}/mid/{1}?popUp=true", Globals.NavigateURL("Det_ViewDebito"), ModuleContext.ModuleId);
            Response.Redirect(url);
        }
    }
}