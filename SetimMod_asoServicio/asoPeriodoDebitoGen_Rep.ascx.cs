using System;
using DotNetNuke.Common;
using SetimBasico;
using Microsoft.Reporting.WebForms;
using DotNetNuke.Entities.Users;

namespace SetimMod_asoServicio
{
    public partial class asoPeriodoDebitoGen_Rep : SetimModulo
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
            var lstDebitos = ctlPeriodoDebito._0SelByAll_Desc_Coutas(0);
            rv_Reporte.LocalReport.DataSources.Add(new ReportDataSource("DataSet_asoPeriodoDebitoAll", lstDebitos));
            //
            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("rp_Usuario_Nombre",this._Usuario_Nombre);
            parametros[1] = new ReportParameter("rp_Titulo", "Título del reporte");
            
            rv_Reporte.LocalReport.SetParameters(parametros);
            rv_Reporte.LocalReport.Refresh();
        }
    }
}