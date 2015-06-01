using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using DotNetNuke.Services.Exceptions;
using DotNetNuke.UI.Modules;
using DotNetNuke.UI.Skins;
using DotNetNuke.UI.Utilities;

using SetimBasico;

namespace SetimMod_Socio
{
    public partial class asoSocio_Lista : ModuleUserControlBase
    {
        // Usuario
        private int _UserId;
        // Entidad base
        private readonly asoSocioControl _EntidadControl = new asoSocioControl();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _UserId = ModuleContext.PortalSettings.UserId;
            if (!IsPostBack)
            {
                tasks.DataSource = _EntidadControl.sp_asoSocio_0Sel();
                tasks.DataBind();
            }
            addButton.NavigateUrl = ModuleContext.EditUrl("Edit");
        }

        protected void DeleteTask(object source, DataGridCommandEventArgs e)
        {
            try
            {
                var socioId = Convert.ToInt32(e.CommandArgument);
                var oSocio = _EntidadControl.sp_asoSocio_1SelById(socioId);
                int res =  _EntidadControl.sp_asoSocio_4Del(oSocio);
                Response.Redirect(Request.RawUrl, false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                const string headerText = "Error";
                const string messageText = "Al borrar hay error. <br/> Mire en el visor.";
                Skin.AddModuleMessage(this,
                    headerText,
                    messageText,
                    DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning);
            }
        }
        protected void btCopiarSocios_OnClick(object sender, EventArgs e)
        {
            try
            {
                _EntidadControl.sp_asoSocio_5CopyFromUsers();
                Response.Redirect(Request.RawUrl,false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                const string headerText = "Error";
                const string messageText = "Al copiar los usuarios hay error. <br/> Mire en el visor.";
                Skin.AddModuleMessage(this,
                    headerText,
                    messageText,
                    DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning);
            }
        }
    }
}