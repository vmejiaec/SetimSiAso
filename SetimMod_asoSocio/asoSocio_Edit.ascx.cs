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
        // Guardar o actualizar dependiendo del parámetro de llamada a la pantalla
        protected void Guardar(object sender, EventArgs e)
        {
            var o = ColocarDatosEnObjeto();

            if (_EntidadId == -1)
                _EntidadControl._2Ins(o);
            else
                _EntidadControl._3Upd(o);

            Response.Redirect(Globals.NavigateURL());
        }
        // Cancela y regresa a la pantalla base
        protected void Cancelar(object sender, EventArgs e)
        {
            Response.Redirect(Globals.NavigateURL());
        }
        // Carga el formulario con los datos de un objeto
        protected void ColocarDatosEnFormulario(int entidadId)
        {
            // Consulta los datos de la entidad
            var o = _EntidadControl._1SelById(entidadId);
            // Pone en los campos los valores del objeto
            tbId.Text = o.Id.ToString();
            tbUserID.Text = o.UserID.ToString();
            tbCI.Text = o.CI;
            tbDescripcion.Text = o.Descripcion;
            dnnDP_Fecha_Nacimiento.SelectedDate = o.Fecha_Nacimiento;
            ddlEstado.SelectedValue = o.Estado;
            tbUsers_EMail.Text = o.Users_EMail;
            tbUsers_Nombre.Text = o.Users_Nombre;
            tbValor_Accion.Text = string.Format("{0:N2}",o.Valor_Accion);
            tbValor_Ahorro.Text = string.Format("{0:N2}", o.Valor_Ahorro);
            tbValor_Voluntario.Text = string.Format("{0:N2}", o.Valor_Voluntario); 
        }
        // Carga un objeto con los datos del formulario
        protected asoSocio ColocarDatosEnObjeto()
        {
            var o = new asoSocio();
            o.Id = _EntidadId;
            o.UserID = Int32.Parse(tbUserID.Text);
            o.CI = tbCI.Text;
            o.Descripcion = tbDescripcion.Text;
            o.Fecha_Nacimiento = (DateTime)dnnDP_Fecha_Nacimiento.SelectedDate;
            o.Estado = ddlEstado.SelectedValue;
            o.Users_EMail = tbUsers_EMail.Text;
            o.Users_Nombre = tbUsers_Nombre.Text;
            o.Valor_Accion = string.IsNullOrWhiteSpace(tbValor_Accion.Text) ? 0 : decimal.Parse(tbValor_Accion.Text);
            o.Valor_Ahorro = string.IsNullOrWhiteSpace(tbValor_Ahorro.Text) ? 0 : decimal.Parse(tbValor_Ahorro.Text);
            o.Valor_Voluntario = string.IsNullOrWhiteSpace(tbValor_Voluntario.Text) ? 0 : decimal.Parse(tbValor_Voluntario.Text);

            return o;
        }

    }
}
