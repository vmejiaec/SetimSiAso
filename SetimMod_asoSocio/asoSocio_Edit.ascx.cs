using System;
using DotNetNuke.Common;
using DotNetNuke.UI.Modules;
using DotNetNuke.Collections;
using SetimBasico;

namespace SetimMod_asoSocio
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
                ColocarDatosEnFormulario(_EntidadId);
            }
        }
        protected void Guardar(object sender, EventArgs e)
        {
            var o = ColocarDatosEnObjeto();

            if (_EntidadId == -1)
                _EntidadControl._2Ins(o);
            else
                _EntidadControl._3Upd(o);

            Response.Redirect(Globals.NavigateURL());
        }

        protected void Cancelar(object sender, EventArgs e)
        {
            Response.Redirect(Globals.NavigateURL());
        }

        // Carga el formulario con los datos de un objeto
        protected void ColocarDatosEnFormulario(int entidadId)
        {
            // Consulta los datos de la entidad
            var o = _EntidadControl._1SelById(entidadId);
            // Campos propios
            tbId.Text = o.Id.ToString();
            tbUserId.Text = o.UserID.ToString();
            tbCI.Text = o.CI;
            tbDescripcion.Text = o.Descripcion;
            dnnDP_Fecha_Nacimiento.SelectedDate = o.Fecha_Nacimiento;
            ddlEstado.SelectedValue = o.Estado;
            tbValor_Accion.Text = o.Valor_Accion.ToString();
            tbValor_Ahorro.Text = o.Valor_Ahorro.ToString();
            // Campos calculados
            tbNombre.Text = o.Users_Nombre;
            tbEMail.Text = o.Users_EMail;
        }
        // Carga un objeto con los datos del formulario
        protected asoSocio ColocarDatosEnObjeto()
        {
            var o = new asoSocio()
            {
                Id = _EntidadId,
                UserID = Int32.Parse(tbUserId.Text),
                CI = tbCI.Text,
                Descripcion = tbDescripcion.Text,
                Fecha_Nacimiento = (DateTime)dnnDP_Fecha_Nacimiento.SelectedDate,
                Estado = ddlEstado.SelectedValue,
                Valor_Accion = string.IsNullOrWhiteSpace(tbValor_Accion.Text) ? 0 : decimal.Parse(tbValor_Accion.Text),
                Valor_Ahorro = string.IsNullOrWhiteSpace(tbValor_Ahorro.Text) ? 0 : decimal.Parse(tbValor_Ahorro.Text)
            };
            return o;
        }

    }
}