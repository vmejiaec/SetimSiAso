using System;
using DotNetNuke.Common;
using DotNetNuke.UI.Modules;
using DotNetNuke.Collections;
using SetimBasico;

namespace SetimMod_asoSocioInversion
{
    public partial class asoSocioInversion_Edit : SetimModulo
    {
        private readonly asoSocioInversionControl _EntidadControl = new asoSocioInversionControl();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this._Nivel = 1;
            this._UserID = ModuleContext.PortalSettings.UserId;
            this._EntidadId = Request.QueryString.GetValueOrDefault("EntidadId", -1);
            if (!IsPostBack)
            {
                //CargarDdl_Estados();
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
                tbasoSocio_Id.Text = "0";
                tbasoInversion_Id.Text = "0";
                tbasoSocio_Nombre.Text = "asoSocio_Nombre";
            }
            else
            {
                // Consulta los datos de la entidad
                var o = _EntidadControl._1SelById(this._EntidadId);
                // Pone en los campos los valores del objeto
                tbId.Text = o.Id.ToString();
                tbasoSocio_Id.Text = o.asoSocio_Id.ToString();
                tbasoInversion_Id.Text = o.asoInversion_Id.ToString();
                tbasoSocio_Nombre.Text = o.asoSocio_Nombre;
            }
        }
        // Carga un objeto con los datos del formulario
        protected asoSocioInversion ColocarDatosEnObjeto()
        {
            var o = new asoSocioInversion();
            o.Id = _EntidadId;
            o.asoSocio_Id = Int32.Parse(tbasoSocio_Id.Text);
            o.asoInversion_Id = Int32.Parse(tbasoInversion_Id.Text);
            o.asoSocio_Nombre = tbasoSocio_Nombre.Text;

            return o;
        }
        //// Carga los estados desde una lista 
        //private void CargarDdl_Estados()
        //{
        //    asoSetimListaDetControl SetimLista = new asoSetimListaDetControl();
        //    var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoSocioInversion_Estado");
        //    lista.RemoveAt(0);
        //    ddlEstado.DataSource = lista;
        //    ddlEstado.DataTextField = "Texto";
        //    ddlEstado.DataValueField = "Valor";
        //    ddlEstado.DataBind();
        //}
    }
}
