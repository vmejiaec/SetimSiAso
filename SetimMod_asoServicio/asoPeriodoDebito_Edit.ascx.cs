using System;
using DotNetNuke.Common;
using DotNetNuke.UI.Modules;
using DotNetNuke.Collections;
using SetimBasico;

namespace SetimMod_asoPeriodoDebito
{
    public partial class asoPeriodoDebito_Edit : SetimModulo
    {
        private readonly asoPeriodoDebitoControl _EntidadControl = new asoPeriodoDebitoControl();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this._Nivel = 0;
            this._UserID = ModuleContext.PortalSettings.UserId;
            this._EntidadId = Request.QueryString.GetValueOrDefault("EntidadId", -1);
            if (!IsPostBack)
            {
                CargarDdl_Estados();                
                ColocarDatosEnFormulario();
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

            string url = Globals.NavigateURL();
            if (this._Nivel != 0)
                url = string.Format("{0}/mid/{1}?popUp=true", Globals.NavigateURL("DetView"), ModuleContext.ModuleId);
            Response.Redirect(url);
        }
        // Cancela y regresa a la pantalla base
        protected void Cancelar(object sender, EventArgs e)
        {
            string url = Globals.NavigateURL();
            if (this._Nivel != 0)
                url = string.Format("{0}/mid/{1}?popUp=true", Globals.NavigateURL("DetView"), ModuleContext.ModuleId);
            Response.Redirect(url);
        }
        // Carga el formulario con los datos de un objeto
        protected void ColocarDatosEnFormulario()
        {
            if (_EntidadId == -1)
            {
                // Valores por defecto para el INSERT
                // Usar this.paginaEstadoMaster.Master_Id.ToString() para la clave foranea
                tbId.Text = "0";
                tbasoPeriodo_Id.Text = "0";
                tbasoServicio_Id.Text = "0";
                tbasoSocio_Id.Text = "0";
                tbValor.Text = "0";
                tbValor_Comision.Text = "0";
                ddlEstado.SelectedValue = "Seleccione..."; // Cambiar por el Estado inicial
                tbDescripcion.Text = "Descripcion";
                tbasoSocio_Nombre.Text = "asoSocio_Nombre";

            }
            else
            {
                // Consulta los datos de la entidad
                var o = _EntidadControl._1SelById(this._EntidadId);
                // Pone en los campos los valores del objeto
                tbId.Text = o.Id.ToString();
                tbasoPeriodo_Id.Text = o.asoPeriodo_Id.ToString();
                tbasoServicio_Id.Text = o.asoServicio_Id.ToString();
                tbasoSocio_Id.Text = o.asoSocio_Id.ToString();
                tbValor.Text = o.Valor.ToString();
                tbValor_Comision.Text = o.Valor_Comision.ToString();
                ddlEstado.SelectedValue = o.Estado;
                tbDescripcion.Text = o.Descripcion;
                tbasoSocio_Nombre.Text = o.asoSocio_Nombre;

            }
        }
        // Carga un objeto con los datos del formulario
        protected asoPeriodoDebito ColocarDatosEnObjeto()
        {
            var o = new asoPeriodoDebito();
            o.Id = _EntidadId;
            o.asoPeriodo_Id = Int32.Parse(tbasoPeriodo_Id.Text);
            o.asoServicio_Id = Int32.Parse(tbasoServicio_Id.Text);
            o.asoSocio_Id = Int32.Parse(tbasoSocio_Id.Text);
            o.Valor = string.IsNullOrWhiteSpace(tbValor.Text) ? 0 : decimal.Parse(tbValor.Text);
            o.Valor_Comision = string.IsNullOrWhiteSpace(tbValor_Comision.Text) ? 0 : decimal.Parse(tbValor_Comision.Text);
            o.Estado = ddlEstado.SelectedValue;
            o.Descripcion = tbDescripcion.Text;
            o.asoSocio_Nombre = tbasoSocio_Nombre.Text;

            return o;
        }
        // Carga los estados desde una lista 
        private void CargarDdl_Estados()
        {
            asoSetimListaDetControl SetimLista = new asoSetimListaDetControl();
            var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoPeriodoDebito_Estado");
            lista.RemoveAt(0);
            ddlEstado.DataSource = lista;
            ddlEstado.DataTextField = "Texto";
            ddlEstado.DataValueField = "Valor";
            ddlEstado.DataBind();
        }
    }
}
