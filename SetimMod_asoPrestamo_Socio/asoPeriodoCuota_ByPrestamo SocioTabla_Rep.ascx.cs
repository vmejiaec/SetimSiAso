using System;
using DotNetNuke.Common;
using SetimBasico;
using Microsoft.Reporting.WebForms;
using DotNetNuke.Entities.Users;

namespace SetimMod_asoPrestamo
{
    public partial class asoPeriodoCuota_ByPrestamo_SocioTabla_Rep : SetimModulo
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
            asoPeriodoCuotaControl ctlPeriodoCuota = new asoPeriodoCuotaControl();
            var lstDatos = ctlPeriodoCuota._0SelByasoPrestamo_Id((int)paginaEstadoMaster.Master_Id);
            // Poner los datos en el reporte
            rv_Reporte.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", lstDatos));
            // Prepara los parámetros del reporte
            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("rp_Usuario_Nombre", this._Usuario_Nombre);
            parametros[1] = new ReportParameter("rp_Titulo", paginaEstadoMaster.Master_Nombre);
            // Llamar al reporte
            rv_Reporte.LocalReport.SetParameters(parametros);
            rv_Reporte.LocalReport.Refresh();
        }
        // Cierra el reporte
        protected void Salir(object sender, EventArgs e)
        {
            string url = Globals.NavigateURL();
            //if (this._Nivel != 0)
            //    url = string.Format("{0}/mid/{1}?popUp=true", Globals.NavigateURL("View_Cuotas"), ModuleContext.ModuleId);
            Response.Redirect(url);
        }
    }
}