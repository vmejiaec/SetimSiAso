using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.UI.Skins;
using DotNetNuke.Common;
using DotNetNuke.Framework.JavaScriptLibraries;
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
            // Obtiene el nombre del usuario
            UserInfo _currentUser = UserController.Instance.GetCurrentUserInfo();
            string Usuario_Nombre = string.Format("{0} {1}", _currentUser.FirstName, _currentUser.LastName);
            // Obtiene el nombre del servicio
            asoServicioControl ctrServicio = new asoServicioControl();
            var oServicio = ctrServicio._1SelById((int)paginaEstadoMaster.Master_Id);
            //
            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("rp_Usuario_Nombre", Usuario_Nombre);
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