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

namespace SetimMod_asoPrestamo
{
    public partial class asoPrestamo_Edit : SetimModulo
    {
        private readonly asoPrestamoControl _EntidadControl = new asoPrestamoControl();

        protected override void OnLoad(EventArgs e)
        {
            // Atajar la llamada del Ajax
            if (Request.Headers["X-SETIM-REQUEST"] == "TRUE") AjaxWrapper();
            // Proceso normal
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
                // Consulta los parámetros
                asoParametroControl ctlParam = new asoParametroControl();
                var param = ctlParam._1SelById(1);
                // Usar this.paginaEstadoMaster.Master_Id.ToString() para la clave foranea
                tbId.Text = "0";
                tbasoSocio_Id.Text = "0";
                tbValor.Text = "0";
                tbTasa_Interes.Text = param.Tasa_Interes_Por_Defecto.ToString();
                tbNo_Periodos.Text = "0";
                tbasoSocio_Id_Garante.Text = "0";
                ddlEstado.SelectedValue = "Seleccione..."; // Cambiar por el Estado inicial
                tbDescripcion.Text = "Descripcion";
                tbasoSocio_Nombre.Text = "Digite 2 letras del nombre...";
                tbasoSocio_Nombre_Garante.Text = "Digite 2 letras del nombre...";
                dnnDP_Fecha_Solicitud.SelectedDate = DateTime.Today;
            }
            else
            {
                // Consulta los datos de la entidad
                var o = _EntidadControl._1SelById(this._EntidadId);
                // Pone en los campos los valores del objeto
                tbId.Text = o.Id.ToString();
                tbasoSocio_Id.Text = o.asoSocio_Id.ToString();
                tbValor.Text = o.Valor.ToString();
                tbTasa_Interes.Text = o.Tasa_Interes.ToString();
                tbNo_Periodos.Text = o.No_Periodos.ToString();
                dnnDP_Fecha_Solicitud.SelectedDate = o.Fecha_Solicitud;
                tbasoSocio_Id_Garante.Text = o.asoSocio_Id_Garante.ToString();
                ddlEstado.SelectedValue = o.Estado;
                tbDescripcion.Text = o.Descripcion;
                tbasoSocio_Nombre.Text = o.asoSocio_Nombre;
                tbasoSocio_Nombre_Garante.Text = o.asoSocio_Nombre_Garante;

            }
        }
        // Carga un objeto con los datos del formulario
        protected asoPrestamo ColocarDatosEnObjeto()
        {
            var o = new asoPrestamo();
            o.Id = _EntidadId;
            o.asoSocio_Id = Int32.Parse(tbasoSocio_Id.Text);
            o.Valor = string.IsNullOrWhiteSpace(tbValor.Text) ? 0 : decimal.Parse(tbValor.Text);
            o.Tasa_Interes = string.IsNullOrWhiteSpace(tbTasa_Interes.Text) ? 0 : decimal.Parse(tbTasa_Interes.Text);
            o.No_Periodos = Int32.Parse(tbNo_Periodos.Text);
            o.Fecha_Solicitud = (DateTime)dnnDP_Fecha_Solicitud.SelectedDate;
            o.asoSocio_Id_Garante = Int32.Parse(tbasoSocio_Id_Garante.Text);
            o.Estado = ddlEstado.SelectedValue;
            o.Descripcion = tbDescripcion.Text;
            o.asoSocio_Nombre = tbasoSocio_Nombre.Text;
            o.asoSocio_Nombre_Garante = tbasoSocio_Nombre_Garante.Text;

            return o;
        }
        // Carga los estados desde una lista 
        private void CargarDdl_Estados()
        {
            asoSetimListaDetControl SetimLista = new asoSetimListaDetControl();
            var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoPrestamo_Estado");
            lista.RemoveAt(0);
            ddlEstado.DataSource = lista;
            ddlEstado.DataTextField = "Texto";
            ddlEstado.DataValueField = "Valor";
            ddlEstado.DataBind();
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
