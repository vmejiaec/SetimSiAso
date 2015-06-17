using System;
using DotNetNuke.Common;
using DotNetNuke.UI.Modules;
using DotNetNuke.Collections;
using SetimBasico;

namespace SetimMod_asoSetimListaDet
{
    public partial class asoSetimListaDet_Edit : SetimModulo
    {
        private readonly asoSetimListaDetControl _EntidadControl = new asoSetimListaDetControl();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this._Nivel = 1;
            this._UserID = ModuleContext.PortalSettings.UserId;
            this._EntidadId = Request.QueryString.GetValueOrDefault("EntidadId", -1);
            if (!IsPostBack)
            {
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

            string url = string.Format("{0}/mid/{1}?popUp=true", Globals.NavigateURL("DetView"), ModuleContext.ModuleId);
            Response.Redirect(url);
        }
        // Cancela y regresa a la pantalla base
        protected void Cancelar(object sender, EventArgs e)
        {
            string url = string.Format("{0}/mid/{1}?popUp=true", Globals.NavigateURL("DetView"), ModuleContext.ModuleId);
            Response.Redirect(url);
        }
        // Carga el formulario con los datos de un objeto
        protected void ColocarDatosEnFormulario()
        {
            if (_EntidadId == -1)
            {
                // Valores por defecto para el INSERT
                // Si el Nivel = 1, usar this.paginaEstadoMaster.Master_Id.ToString() en el campo de la clave foranea
                tbId.Text = "0";
                tbasoSetimLista_Id.Text = this.paginaEstadoMaster.Master_Id.ToString();
                tbOrden.Text = "0";
                tbTexto.Text = "Texto";
                tbValor.Text = "Valor";

            }
            else
            {
                // Consulta los datos de la entidad
                var o = _EntidadControl._1SelById(this._EntidadId);
                // Pone en los campos los valores del objeto
                tbId.Text = o.Id.ToString();
                tbasoSetimLista_Id.Text = o.asoSetimLista_Id.ToString();
                tbOrden.Text = o.Orden.ToString();
                tbTexto.Text = o.Texto;
                tbValor.Text = o.Valor;

            }
        }
        // Carga un objeto con los datos del formulario
        protected asoSetimListaDet ColocarDatosEnObjeto()
        {
            var o = new asoSetimListaDet();
            o.Id = _EntidadId;
            o.asoSetimLista_Id = Int32.Parse(tbasoSetimLista_Id.Text);
            o.Orden = Int32.Parse(tbOrden.Text);
            o.Texto = tbTexto.Text;
            o.Valor = tbValor.Text;

            return o;
        }

    }
}
