using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.UI.Skins;
using DotNetNuke.Common;
using DotNetNuke.Framework.JavaScriptLibraries;
using SetimBasico;

namespace SetimMod_asoServicio
{
    public partial class asoPeriodoDebito_Rep : SetimModulo
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportViewer1.LocalReport.Refresh();
        }
    }
}