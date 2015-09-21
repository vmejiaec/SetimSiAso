using System;
using DotNetNuke.Common;
using DotNetNuke.UI.Modules;
using DotNetNuke.Collections;
using SetimBasico;

namespace SetimMod_asoPeriodoCuota
{
    public partial class asoPeriodoCuota_Edit : SetimModulo
    {
        private readonly asoPeriodoCuotaControl _EntidadControl = new asoPeriodoCuotaControl();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this._Nivel = 1;
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
                url = string.Format("{0}/mid/{1}?popUp=true", Globals.NavigateURL("View_Cuotas"), ModuleContext.ModuleId);
            Response.Redirect(url);
        }
        // Cancela y regresa a la pantalla base
        protected void Cancelar(object sender, EventArgs e)
        {
            string url = Globals.NavigateURL();
            if (this._Nivel != 0)
                url = string.Format("{0}/mid/{1}?popUp=true", Globals.NavigateURL("View_Cuotas"), ModuleContext.ModuleId);
            Response.Redirect(url);
        }
        // Carga el formulario con los datos de un objeto
        protected void ColocarDatosEnFormulario()
        {
            if (_EntidadId == -1)
            {
                // Valores por defecto para el INSERT
                // Usar this.paginaEstadoMaster.Master_Id.ToString() para la clave foranea
                // Consulta los datos del préstamo
                int Prestamo_Id = (int) this.paginaEstadoMaster.Master_Id;
                asoPeriodoCuotaControl ctlCuotas = new asoPeriodoCuotaControl();
                var lstCoutasABorrar = ctlCuotas._0SelByasoPrestamo_Id(Prestamo_Id);
                int Periodo_maxId = -1;
                foreach (var c in lstCoutasABorrar)
                {
                    if (c.asoPeriodo_Id > Periodo_maxId)
                        Periodo_maxId = c.asoPeriodo_Id;
                }
                Periodo_maxId++;
                //
                tbId.Text = "0";
                tbasoPeriodo_Id.Text = Periodo_maxId.ToString();
                tbasoPrestamo_Id.Text = Prestamo_Id.ToString();
                tbValor_Capital.Text = "0";
                tbValor_Interes.Text = "0";
                ddlEstado.SelectedValue = "Seleccione..."; // Cambiar por el Estado inicial
                tbDescripcion.Text = "Descripcion";
                tbasoSocio_Nombre.Text = "asoSocio_Nombre";
                dnnDP_asoPeriodo_Fecha.SelectedDate = DateTime.Today; // Fecha actual por defecto

            }
            else
            {
                // Consulta los datos de la entidad
                var o = _EntidadControl._1SelById(this._EntidadId);
                // Pone en los campos los valores del objeto
                tbId.Text = o.Id.ToString();
                tbasoPeriodo_Id.Text = o.asoPeriodo_Id.ToString();
                tbasoPrestamo_Id.Text = o.asoPrestamo_Id.ToString();
                tbValor_Capital.Text = o.Valor_Capital.ToString();
                tbValor_Interes.Text = o.Valor_Interes.ToString();
                ddlEstado.SelectedValue = o.Estado;
                tbDescripcion.Text = o.Descripcion;
                tbasoSocio_Nombre.Text = o.asoSocio_Nombre;
                dnnDP_asoPeriodo_Fecha.SelectedDate = o.asoPeriodo_Fecha;

            }
        }
        // Carga un objeto con los datos del formulario
        protected asoPeriodoCuota ColocarDatosEnObjeto()
        {
            var o = new asoPeriodoCuota();
            o.Id = _EntidadId;
            o.asoPeriodo_Id = Int32.Parse(tbasoPeriodo_Id.Text);
            o.asoPrestamo_Id = Int32.Parse(tbasoPrestamo_Id.Text);
            o.Valor_Capital = string.IsNullOrWhiteSpace(tbValor_Capital.Text) ? 0 : decimal.Parse(tbValor_Capital.Text);
            o.Valor_Interes = string.IsNullOrWhiteSpace(tbValor_Interes.Text) ? 0 : decimal.Parse(tbValor_Interes.Text);
            o.Estado = ddlEstado.SelectedValue;
            o.Descripcion = tbDescripcion.Text;
            o.asoSocio_Nombre = tbasoSocio_Nombre.Text;
            o.asoPeriodo_Fecha = (DateTime)dnnDP_asoPeriodo_Fecha.SelectedDate;

            return o;
        }
        // Carga los estados desde una lista 
        private void CargarDdl_Estados()
        {
            asoSetimListaDetControl SetimLista = new asoSetimListaDetControl();
            var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoPeriodoCuota_Estado");
            lista.RemoveAt(0);
            ddlEstado.DataSource = lista;
            ddlEstado.DataTextField = "Texto";
            ddlEstado.DataValueField = "Valor";
            ddlEstado.DataBind();
        }
    }
}
