using System;
using DotNetNuke.Common;
using DotNetNuke.UI.Modules;
using DotNetNuke.Collections;
using SetimBasico;

namespace SetimMod_asoSetimLista
{
    public partial class asoSetimLista_Edit : SetimModulo
    {
        private readonly asoSetimListaControl _EntidadControl = new asoSetimListaControl();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this._Nivel = 0;
            this._UserID = ModuleContext.PortalSettings.UserId;
            //Obtiene el identificador de la llamada
            this._EntidadId = Request.QueryString.GetValueOrDefault("EntidadId", -1);
            //Verifica si debe cargar datos en el formulario
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

            Response.Redirect(Globals.NavigateURL());
        }
        // Cancela y regresa a la pantalla base
        protected void Cancelar(object sender, EventArgs e)
        {
            Response.Redirect(Globals.NavigateURL());
        }
        // Carga el formulario con los datos de un objeto
        protected void ColocarDatosEnFormulario()
        {
            if (_EntidadId == -1)
            {
                // Valores por defecto para el INSERT
                tbId.Text = "0";
                tbNombre.Text = "Nombre";
                tbDescripcion.Text = "Descripcion";
                tbDetalles.Text = "...";
            }
            else
            {
                // Consulta los datos de la entidad para UPDATE
                var o = _EntidadControl._1SelById(this._EntidadId);
                tbId.Text = o.Id.ToString();
                tbNombre.Text = o.Nombre;
                tbDescripcion.Text = o.Descripcion;
                tbDetalles.Text = o.Detalles;
            }
        }
        // Carga un objeto con los datos del formulario
        protected asoSetimLista ColocarDatosEnObjeto()
        {
            var o = new asoSetimLista();
            o.Id = _EntidadId;
            o.Nombre = tbNombre.Text;
            o.Descripcion = tbDescripcion.Text;
            o.Detalles = tbDetalles.Text;

            return o;
        }

    }
}
