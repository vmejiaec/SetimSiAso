using System;
using DotNetNuke.Common;
using DotNetNuke.UI.Modules;
using DotNetNuke.Collections;
using SetimBasico;

namespace SetimMod_asoPrestamoTmp
{
    public partial class asoPrestamoTmp_Edit : SetimModulo
    {
        private readonly asoPrestamoTmpControl _EntidadControl = new asoPrestamoTmpControl();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this._Nivel = 0;
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
                tbCI.Text = "CI";
                tbValor_Prestamo.Text = "0";
                tbNo_Periodos.Text = "0";
                tbNo_Periodos_Faltantes.Text = "0";
                tbValor_Capital.Text = "0";
                tbValor_Interes.Text = "0";

            }
            else
            {
                // Consulta los datos de la entidad
                var o = _EntidadControl._1SelById(this._EntidadId);
                // Pone en los campos los valores del objeto
                tbId.Text = o.Id.ToString();
                tbCI.Text = o.CI;
                tbValor_Prestamo.Text = o.Valor_Prestamo.ToString();
                tbNo_Periodos.Text = o.No_Periodos.ToString();
                tbNo_Periodos_Faltantes.Text = o.No_Periodos_Faltantes.ToString();
                tbValor_Capital.Text = o.Valor_Capital.ToString();
                tbValor_Interes.Text = o.Valor_Interes.ToString();

            }
        }
        // Carga un objeto con los datos del formulario
        protected asoPrestamoTmp ColocarDatosEnObjeto()
        {
            var o = new asoPrestamoTmp();
            o.Id = _EntidadId;
            o.CI = tbCI.Text;
            o.Valor_Prestamo = string.IsNullOrWhiteSpace(tbValor_Prestamo.Text) ? 0 : decimal.Parse(tbValor_Prestamo.Text);
            o.No_Periodos = Int32.Parse(tbNo_Periodos.Text);
            o.No_Periodos_Faltantes = Int32.Parse(tbNo_Periodos_Faltantes.Text);
            o.Valor_Capital = string.IsNullOrWhiteSpace(tbValor_Capital.Text) ? 0 : decimal.Parse(tbValor_Capital.Text);
            o.Valor_Interes = string.IsNullOrWhiteSpace(tbValor_Interes.Text) ? 0 : decimal.Parse(tbValor_Interes.Text);

            return o;
        }
    }
}
