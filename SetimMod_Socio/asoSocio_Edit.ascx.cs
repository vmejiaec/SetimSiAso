using System;

using DotNetNuke.Common;
using DotNetNuke.UI.Modules;
using DotNetNuke.Collections;

using SetimBasico;

namespace SetimMod_Socio
{
    public partial class asoSocio_Edit : ModuleUserControlBase
    {
        private int _UserID;
        private int _EntidadId;
        private readonly asoSocioControl _EntidadControl = new asoSocioControl();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _UserID = ModuleContext.PortalSettings.UserId;
            //Obtiene el identificador de la llamada
            _EntidadId = Request.QueryString.GetValueOrDefault("EntidadId", -1);
            //Verifica si debe cargar datos en el formulario
            if (_EntidadId > -1 && !IsPostBack)
            {
                var o = _EntidadControl.sp_asoSocio_1SelById(_EntidadId);
                ColocarDatosEnFormulario(o);
            }
        }

        protected void ColocarDatosEnFormulario(asoSocio o)
        {
            tbId.Text = o.Id.ToString();
            tbUserId.Text = o.UserID.ToString();
            tbCI.Text = o.CI;
            tbDescripcion.Text = o.Descripcion;
            tbFecha_Nacimiento.Text = string.Format("{0:d}", o.Fecha_Nacimiento);
            tbEstado.Text = o.Estado;
        }

        protected void Guardar(object sender, EventArgs e)
        {
            var o = new asoSocio()
            {
                Id = _EntidadId,
                UserID = Int32.Parse(tbUserId.Text),
                CI = tbCI.Text,
                Descripcion = tbDescripcion.Text,
                Fecha_Nacimiento = DateTime.Parse(tbFecha_Nacimiento.Text),
                Estado = tbEstado.Text
            };

            if (_EntidadId == -1)
            {
                _EntidadControl.sp_asoSocio_2Ins(o);
            }
            else
            {
                _EntidadControl.sp_asoSocio_3Upd(o);
            }

            Response.Redirect(Globals.NavigateURL());
        }

        protected void Cancelar(object sender, EventArgs e)
        {
            Response.Redirect(Globals.NavigateURL());
        }
    }
}