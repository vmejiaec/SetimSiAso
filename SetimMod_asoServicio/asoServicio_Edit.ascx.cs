using System;
using DotNetNuke.Common;
using DotNetNuke.UI.Modules;
using DotNetNuke.Collections;
using SetimBasico;

namespace SetimMod_asoServicio
{
    public partial class asoServicio_Edit : SetimModulo
    {
        private readonly asoServicioControl _EntidadControl = new asoServicioControl();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this._Nivel = 0;
            this._UserID = ModuleContext.PortalSettings.UserId;
            this._EntidadId = Request.QueryString.GetValueOrDefault("EntidadId", -1);
            if (!IsPostBack)
            {
                CargarDdl_Estados();
                CargarDdl_Tipos();
                ColocarDatosEnFormulario();
            }
            // Seguridad
            saveButton.Enabled = this._Usuario_RolSetimEditar;
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
                tbNombre.Text = "Nombre";
                tbDescripcion.Text = "Descripcion";
                tbPorcentaje_Comision.Text = "0";
                ddlTipo.SelectedValue = "Seleccione..."; // Cambiar por el Tipo inicial
                tbValor.Text = "0";
                tbNo_Periodos.Text = "0";
                tbNo_Socios_Regs.Text = "0";

            }
            else
            {
                // Consulta los datos de la entidad
                var o = _EntidadControl._1SelById(this._EntidadId);
                // Pone en los campos los valores del objeto
                tbId.Text = o.Id.ToString();
                tbNombre.Text = o.Nombre;
                tbDescripcion.Text = o.Descripcion;
                tbPorcentaje_Comision.Text = o.Porcentaje_Comision.ToString();
                ddlTipo.SelectedValue = o.Tipo;
                tbValor.Text = o.Valor.ToString();
                tbNo_Periodos.Text = o.No_Periodos.ToString();
                tbNo_Socios_Regs.Text = o.No_Socios_Regs.ToString();

            }
        }
        // Carga un objeto con los datos del formulario
        protected asoServicio ColocarDatosEnObjeto()
        {
            var o = new asoServicio();
            o.Id = _EntidadId;
            o.Nombre = tbNombre.Text;
            o.Descripcion = tbDescripcion.Text;
            o.Porcentaje_Comision = string.IsNullOrWhiteSpace(tbPorcentaje_Comision.Text) ? 0 : decimal.Parse(tbPorcentaje_Comision.Text);
            o.Tipo = ddlTipo.SelectedValue;
            o.Valor = string.IsNullOrWhiteSpace(tbValor.Text) ? 0 : decimal.Parse(tbValor.Text);
            o.No_Periodos = Int32.Parse(tbNo_Periodos.Text);
            o.No_Socios_Regs = Int32.Parse(tbNo_Socios_Regs.Text);

            return o;
        }
        // Carga los estados desde una lista 
        private void CargarDdl_Estados()
        {
            //asoSetimListaDetControl SetimLista = new asoSetimListaDetControl();
            //var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoServicio_Estado");
            //lista.RemoveAt(0);
            //ddlEstado.DataSource = lista;
            //ddlEstado.DataTextField = "Texto";
            //ddlEstado.DataValueField = "Valor";
            //ddlEstado.DataBind();
        }
        // Carga los Tipos desde una lista 
        private void CargarDdl_Tipos()
        {
            asoSetimListaDetControl SetimLista = new asoSetimListaDetControl();
            var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoServicio_Tipo");
            lista.RemoveAt(0);
            ddlTipo.DataSource = lista;
            ddlTipo.DataTextField = "Texto";
            ddlTipo.DataValueField = "Valor";
            ddlTipo.DataBind();
        }
    }
}
