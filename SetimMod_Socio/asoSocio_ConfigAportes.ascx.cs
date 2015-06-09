using System;
using DotNetNuke.Common;
using DotNetNuke.UI.Modules;
using DotNetNuke.Collections;
using SetimBasico;

namespace SetimMod_Socio
{
    public partial class asoSocio_ConfigAportes : ModuleUserControlBase
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
        // Guardar los datos de la pantalla
        protected void Guardar(object sender, EventArgs e)
        {
            var o = ColocarDatosEnObjeto();
            //Realizar la operación dependiendo del parámetro 
            //if (_EntidadId == -1)
            //    _EntidadControl._2Ins(o);
            //else
            //    _EntidadControl._3Upd(o);
            Response.Redirect(Globals.NavigateURL());
        }
        // Salir sin guardar
        protected void Cancelar(object sender, EventArgs e)
        {
            Response.Redirect(Globals.NavigateURL());
        }
        // Carga el formulario con los datos de un objeto
        protected void ColocarDatosEnFormulario(int entidadId)
        {
            // Consulta los datos de la entidad
            var o = _EntidadControl._1SelById(entidadId);
            // Campos propios
            tbId.Text = o.Id.ToString();
            ddlEstado.SelectedValue = o.Estado;
            // Campos calculados
            tbNombre.Text = o.Users_Nombre;
        }
        // Carga un objeto con los datos del formulario
        protected asoSocio ColocarDatosEnObjeto()
        {
            var o = new asoSocio()
            {
                Id = _EntidadId,
                Estado = ddlEstado.SelectedValue
            };
            return o;
        }
    }
}