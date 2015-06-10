using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DotNetNuke.Common;
using DotNetNuke.UI.Modules;
using DotNetNuke.Collections;
using SetimBasico;

namespace SetimMod_asoSetimLista
{
    public partial class asoSetimLista_View : ModuleUserControlBase
    {
        private int _UserID;
        private int _EntidadId;
        private readonly asoSetimLista _EntidadControl = new asoSetimLista();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _UserID = ModuleContext.PortalSettings.UserId;
            //Obtiene el identificador de la llamada
            _EntidadId = Request.QueryString.GetValueOrDefault("EntidadId", -1);
            //Verifica si debe cargar datos en el formulario
            if (_EntidadId > -1 && !IsPostBack)
            {
                ;
            }
        }
    }
}