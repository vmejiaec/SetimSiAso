using System;
using DotNetNuke.Common;
using DotNetNuke.UI.Modules;
using DotNetNuke.Collections;
using SetimBasico;

namespace SetimMod_asoPeriodo
{
    public partial class asoPeriodo_Edit : SetimModulo
    {
        private readonly asoPeriodoControl _EntidadControl = new asoPeriodoControl();

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
            //Seguridad
            saveButton.Enabled = _Usuario_RolSetimEditar;
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
                tbNo_Periodo.Text = "0";
                dnnDP_Fecha_Periodo.SelectedDate = DateTime.Today; // Fecha actual por defecto
                ddlEstado.SelectedValue = "Seleccione..."; // Cambiar por el estado inicial
                tbDescripcion.Text = "Descripcion";

            }
            else
            {
                // Consulta los datos de la entidad
                var o = _EntidadControl._1SelById(this._EntidadId);
                // Pone en los campos los valores del objeto
                tbId.Text = o.Id.ToString();
                tbNo_Periodo.Text = o.No_Periodo.ToString();
                dnnDP_Fecha_Periodo.SelectedDate = o.Fecha_Periodo;
                ddlEstado.SelectedValue = o.Estado;
                tbDescripcion.Text = o.Descripcion;

            }
        }
        // Carga un objeto con los datos del formulario
        protected asoPeriodo ColocarDatosEnObjeto()
        {
            var o = new asoPeriodo();
            o.Id = _EntidadId;
            o.No_Periodo = Int32.Parse(tbNo_Periodo.Text);
            o.Fecha_Periodo = (DateTime)dnnDP_Fecha_Periodo.SelectedDate;
            o.Estado = ddlEstado.SelectedValue;
            o.Descripcion = tbDescripcion.Text;

            return o;
        }
        // Carga los estados desde una lista 
        private void CargarDdl_Estados()
        {
            asoSetimListaDetControl SetimLista = new asoSetimListaDetControl();
            var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoPeriodo_Estado");
            lista.RemoveAt(0);
            ddlEstado.DataSource = lista;
            ddlEstado.DataTextField = "Texto";
            ddlEstado.DataValueField = "Valor";
            ddlEstado.DataBind();
        }
    }
}
