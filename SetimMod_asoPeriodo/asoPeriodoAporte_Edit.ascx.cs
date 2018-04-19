using System;
using DotNetNuke.Common;
using DotNetNuke.UI.Modules;
using DotNetNuke.Collections;
using SetimBasico;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Reflection;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;

namespace SetimMod_asoPeriodoAporte
{
    public partial class asoPeriodoAporte_Edit : SetimModulo
    {
        private readonly asoPeriodoAporteControl _EntidadControl = new asoPeriodoAporteControl();

        protected override void OnLoad(EventArgs e)
        {
            // Atajar la llamada del Ajax
            if (Request.Headers["X-SETIM-REQUEST"] == "TRUE") AjaxWrapper();
            // Proceso normal
            base.OnLoad(e);
            this._Nivel = 1;
            this._UserID = ModuleContext.PortalSettings.UserId;
            this._EntidadId = Request.QueryString.GetValueOrDefault("EntidadId", -1);
            if (!IsPostBack)
            {
                CargarDdl_Estados();
                CargarDdl_Tipos();
                ColocarDatosEnFormulario();
            }
            //Seguridad
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
                url = string.Format("{0}/mid/{1}?popUp=true", Globals.NavigateURL("View_Aporte"), ModuleContext.ModuleId);
            Response.Redirect(url);
        }
        // Cancela y regresa a la pantalla base
        protected void Cancelar(object sender, EventArgs e)
        {
            string url = Globals.NavigateURL();
            if (this._Nivel != 0)
                url = string.Format("{0}/mid/{1}?popUp=true", Globals.NavigateURL("View_Aporte"), ModuleContext.ModuleId);
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
                tbasoPeriodo_Id.Text = this.paginaEstadoMaster.Master_Id.ToString();
                tbasoSocio_Id.Text = "-1";
                ddlTipo.SelectedValue = "Seleccione..."; // Cambiar por el Tipo inicial
                ddlEstado.SelectedValue = "Seleccione..."; // Cambiar por el Estado inicial
                tbDescripcion.Text = "Descripcion";
                tbasoSocio_Nombre.Text = "Pulse dos letras...";
                tbasoPeriodo_Fecha.Text = this.paginaEstadoMaster.Master_Nombre; // Fecha del master
                tbValor_Accion.Text = "0";
                tbValor_Ahorro.Text = "0";
                tbValor_Voluntario.Text = "0";

            }
            else
            {
                // Consulta los datos de la entidad
                var o = _EntidadControl._1SelById(this._EntidadId);
                // Pone en los campos los valores del objeto
                tbId.Text = o.Id.ToString();
                tbasoPeriodo_Id.Text = o.asoPeriodo_Id.ToString();
                tbasoSocio_Id.Text = o.asoSocio_Id.ToString();
                ddlTipo.SelectedValue = o.Tipo;
                ddlEstado.SelectedValue = o.Estado;
                tbDescripcion.Text = o.Descripcion;
                tbasoSocio_Nombre.Text = o.asoSocio_Nombre;
                tbasoPeriodo_Fecha.Text = string.Format("{0:d}", o.asoPeriodo_Fecha);
                tbValor_Accion.Text = o.Valor_Accion.ToString();
                tbValor_Ahorro.Text = o.Valor_Ahorro.ToString();
                tbValor_Voluntario.Text = o.Valor_Voluntario.ToString();

            }
        }
        // Carga un objeto con los datos del formulario
        protected asoPeriodoAporte ColocarDatosEnObjeto()
        {
            var o = new asoPeriodoAporte();
            o.Id = _EntidadId;
            o.asoPeriodo_Id = Int32.Parse(tbasoPeriodo_Id.Text);
            o.asoSocio_Id = Int32.Parse(tbasoSocio_Id.Text);
            o.Tipo = ddlTipo.SelectedValue;
            o.Estado = ddlEstado.SelectedValue;
            o.Descripcion = tbDescripcion.Text;
            o.asoSocio_Nombre = tbasoSocio_Nombre.Text;
            //o.asoPeriodo_Fecha = (DateTime)dnnDP_asoPeriodo_Fecha.SelectedDate;
            o.Valor_Accion = string.IsNullOrWhiteSpace(tbValor_Accion.Text) ? 0 : decimal.Parse(tbValor_Accion.Text);
            o.Valor_Ahorro = string.IsNullOrWhiteSpace(tbValor_Ahorro.Text) ? 0 : decimal.Parse(tbValor_Ahorro.Text);
            o.Valor_Voluntario = string.IsNullOrWhiteSpace(tbValor_Voluntario.Text) ? 0 : decimal.Parse(tbValor_Voluntario.Text);

            return o;
        }
        // Carga los estados desde una lista 
        private void CargarDdl_Estados()
        {
            asoSetimListaDetControl SetimLista = new asoSetimListaDetControl();
            var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoPeriodoAporte_Estado");
            lista.RemoveAt(0);
            ddlEstado.DataSource = lista;
            ddlEstado.DataTextField = "Texto";
            ddlEstado.DataValueField = "Valor";
            ddlEstado.DataBind();
        }
        // Carga los Tipos desde una lista 
        private void CargarDdl_Tipos()
        {
            asoSetimListaDetControl SetimLista = new asoSetimListaDetControl();
            var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoPeriodoAporte_Tipo");
            lista.RemoveAt(0);
            ddlTipo.DataSource = lista;
            ddlTipo.DataTextField = "Texto";
            ddlTipo.DataValueField = "Valor";
            ddlTipo.DataBind();
        }

        // Soporte para autocompletar
        public string GetSociosActivosByPrefijo(string Prefijo)
        {
            asoSocioControl ctlSocio = new asoSocioControl();
            var lstSocios = ctlSocio._0SelByAll("ACT", "Users_Nombre", Prefijo, 0, 10, "Users_Nombre", "ASC");
            List<AutoCompletarItem> lista = new List<AutoCompletarItem>();
            foreach (var socio in lstSocios)
                lista.Add(new AutoCompletarItem { valor = socio.Id.ToString(), etiqueta = socio.Users_Nombre, desc = socio.Estado });
            var json = JsonConvert.SerializeObject(lista);
            return json;
        }
        // Repartidor de mensajes Ajax para autocompletar
        public void AjaxWrapper()
        {
            Response.Clear();
            string strData = "";
            try
            {
                MethodInfo mi = GetType().GetMethod(Request.Params["FUNCTION"]);
                object[] objs = new object[mi.GetParameters().Length];
                for (int i = 0; i < objs.Length; i++)
                {
                    objs[i] = (new PortalSecurity()).InputFilter(Request.Params["param" + i], PortalSecurity.FilterFlag.NoMarkup);
                }
                strData = mi.Invoke(this, objs).ToString();
            }
            catch (Exception ex)
            {
                strData = "{Error : Caught}";
                Exceptions.ProcessModuleLoadException(this, ex);
            }
            //
            Response.ContentType = "json";
            Response.Write(strData);
            Response.Flush();
            try { Response.End(); }
            catch { }
            return;
        }
    }
}
