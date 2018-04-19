using System;
using DotNetNuke.Common;
using DotNetNuke.UI.Modules;
using DotNetNuke.Collections;
using SetimBasico;
using System.Reflection;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SetimMod_asoServicioSocio
{
    public partial class asoServicioSocio_Edit : SetimModulo
    {
        private readonly asoServicioSocioControl _EntidadControl = new asoServicioSocioControl();

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
                tbasoSocio_Id.Text = "0";
                tbasoServicio_Id.Text = this.paginaEstadoMaster.Master_Id.ToString();
                tbasoSocio_Nombre.Text = "Digitar 2 letras...";
                tbValor.Text = "0";
                tbNo_Periodos.Text = "0";
            }
            else
            {
                // Consulta los datos de la entidad
                var o = _EntidadControl._1SelById(this._EntidadId);
                // Pone en los campos los valores del objeto
                tbId.Text = o.Id.ToString();
                tbasoSocio_Id.Text = o.asoSocio_Id.ToString();
                tbasoServicio_Id.Text = o.asoServicio_Id.ToString();
                tbasoSocio_Nombre.Text = o.asoSocio_Nombre;
                tbValor.Text = o.Valor.ToString();
                tbNo_Periodos.Text = o.No_Periodos.ToString();
            }
        }
        // Carga un objeto con los datos del formulario
        protected asoServicioSocio ColocarDatosEnObjeto()
        {
            var o = new asoServicioSocio();
            o.Id = _EntidadId;
            o.asoSocio_Id = Int32.Parse(tbasoSocio_Id.Text);
            o.asoServicio_Id = Int32.Parse(tbasoServicio_Id.Text);
            o.asoSocio_Nombre = tbasoSocio_Nombre.Text;
            o.Valor = string.IsNullOrWhiteSpace(tbValor.Text) ? 0 : decimal.Parse(tbValor.Text);
            o.No_Periodos = Int32.Parse(tbNo_Periodos.Text);
            return o;
        }
        // Carga los estados desde una lista 
        private void CargarDdl_Estados()
        {
            //asoSetimListaDetControl SetimLista = new asoSetimListaDetControl();
            //var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoServicioSocio_Estado");
            //lista.RemoveAt(0);
            //ddlEstado.DataSource = lista;
            //ddlEstado.DataTextField = "Texto";
            //ddlEstado.DataValueField = "Valor";
            //ddlEstado.DataBind();
        }
        // Carga los Tipos desde una lista 
        private void CargarDdl_Tipos()
        {
            //asoSetimListaDetControl SetimLista = new asoSetimListaDetControl();
            //var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoServicioSocio_Tipo");
            //lista.RemoveAt(0);
            //ddlTipo.DataSource = lista;
            //ddlTipo.DataTextField = "Texto";
            //ddlTipo.DataValueField = "Valor";
            //ddlTipo.DataBind();
        }
        
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
