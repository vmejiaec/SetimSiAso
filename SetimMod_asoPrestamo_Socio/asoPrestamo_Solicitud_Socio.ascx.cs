using System;
using DotNetNuke.Common;
using SetimBasico;
using Microsoft.Reporting.WebForms;
using DotNetNuke.Entities.Users;
using System.Collections.Generic;

namespace SetimMod_asoPrestamo_Socio
{
    public partial class asoPrestamo_Solicitud_Socio : SetimModulo
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
            asoPrestamoControl ctlPrestamo = new asoPrestamoControl();
            var oPrestamo = ctlPrestamo._1SelById((int)paginaEstadoMaster.Master_Id);
            List<asoPrestamo> lstPrestamo = new List<asoPrestamo>();
            lstPrestamo.Add(oPrestamo);
            int SocioId = oPrestamo.asoSocio_Id;
            int SocioId_Garante = oPrestamo.asoSocio_Id_Garante;
            string SocioNombre = oPrestamo.asoSocio_Nombre;
            string SocioNombre_Garante = oPrestamo.asoSocio_Nombre_Garante;
            var ctlSocio = new asoSocioControl();
            var oSocio = ctlSocio._1SelById(SocioId);
            string SocioCI = oSocio.CI;
            oSocio = ctlSocio._1SelById(SocioId_Garante);
            string SocioCI_Garante = oSocio.CI;
            // Obtiene parámetros del sistema
            var ctlParam = new asoParametroControl();
            var oParam = ctlParam._1SelById(1);
            string asoNombreLargo = oParam.Nombre_Largo_Asociacion;
            // Poner los datos en el reporte
            rv_Reporte.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", lstPrestamo));
            // Prepara los parámetros del reporte
            ReportParameter[] parametros = new ReportParameter[5];
            parametros[0] = new ReportParameter("rp_SocioNombre", SocioNombre);
            parametros[1] = new ReportParameter("rp_SocioCI", SocioCI);
            parametros[2] = new ReportParameter("rp_AsociacionNombre",asoNombreLargo );
            parametros[3] = new ReportParameter("rp_SocioCI_Garante", SocioCI_Garante);
            parametros[4] = new ReportParameter("rp_SocioNombre_Garante", SocioNombre_Garante);
            // Llamar al reporte
            rv_Reporte.LocalReport.SetParameters(parametros);
            rv_Reporte.LocalReport.Refresh();
        }
        // Cierra el reporte
        protected void Salir(object sender, EventArgs e)
        {
            string url = Globals.NavigateURL();
            Response.Redirect(url);
        }
    }
}