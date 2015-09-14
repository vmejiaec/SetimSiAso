using System;
using DotNetNuke.Common;
using SetimBasico;
using Microsoft.Reporting.WebForms;
using DotNetNuke.Entities.Users;
using System.Web;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.UI.Skins;

namespace SetimMod_asoPrestamo
{
    public partial class asoPeriodoCuota_ByPrestamo_Rep : SetimModulo
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
            string path = HttpContext.Current.Server.MapPath("~/");
            rv_Reporte.LocalReport.ReportPath = path + @"DesktopModules\Setim\SetimMod_asoPrestamo\asoPeriodoCuota_ByPrestamo_Rep.rdlc";

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
            try
            {
                rv_Reporte.LocalReport.SetParameters(parametros);
                rv_Reporte.LocalReport.Refresh();
            }
            catch (Exception exc)
            {
                string mensaje = exc.Message;
                if (exc.InnerException != null)
                    mensaje = mensaje + " - " + exc.InnerException.Message;
                Exceptions.LogException(exc);
                const string headerText = "Error";
                string messageText = mensaje;
                Skin.AddModuleMessage(this,
                    headerText,
                    messageText,
                    DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning);
            }
        }
        // Cierra el reporte
        protected void Salir(object sender, EventArgs e)
        {
            string url = Globals.NavigateURL();
            if (this._Nivel != 0)
                url = string.Format("{0}/mid/{1}?popUp=true", Globals.NavigateURL("View_Cuotas"), ModuleContext.ModuleId);
            Response.Redirect(url);
        }
    }
}