using System;
using DotNetNuke.Common;
using DotNetNuke.UI.Modules;
using DotNetNuke.Collections;
using SetimBasico;

namespace SetimMod_asoParametro
{
    public partial class asoParametro_Edit : SetimModulo
    {
        private readonly asoParametroControl _EntidadControl = new asoParametroControl();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this._Nivel = 0;
            this._UserID = ModuleContext.PortalSettings.UserId;
            this._EntidadId = Request.QueryString.GetValueOrDefault("EntidadId", 1);
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
                tbasoPeriodo_Id_Actual.Text = "0";
                tbPorcentaje_Comision_Por_Defecto.Text = "0";
                tbValor_Reingreso.Text = "0";
                tbNo_Periodos_Reingreso.Text = "0";
                tbValor_Accion_Minimo.Text = "0";
                tbValor_Ahorro_Minimo.Text = "0";
                tbTasa_Interes_Por_Defecto.Text = "0";
                tbNombre_Largo_Asociacion.Text = "Nombre_Largo_Asociacion";
                tbNombre_Corto_Asociacion.Text = "Nombre_Corto_Asociacion";

            }
            else
            {
                // Consulta los datos de la entidad
                var o = _EntidadControl._1SelById(this._EntidadId);
                // Pone en los campos los valores del objeto
                tbId.Text = o.Id.ToString();
                tbasoPeriodo_Id_Actual.Text = o.asoPeriodo_Id_Actual.ToString();
                tbPorcentaje_Comision_Por_Defecto.Text = o.Porcentaje_Comision_Por_Defecto.ToString();
                tbValor_Reingreso.Text = o.Valor_Reingreso.ToString();
                tbNo_Periodos_Reingreso.Text = o.No_Periodos_Reingreso.ToString();
                tbValor_Accion_Minimo.Text = o.Valor_Accion_Minimo.ToString();
                tbValor_Ahorro_Minimo.Text = o.Valor_Ahorro_Minimo.ToString();
                tbTasa_Interes_Por_Defecto.Text = o.Tasa_Interes_Por_Defecto.ToString();
                tbNombre_Largo_Asociacion.Text = o.Nombre_Largo_Asociacion;
                tbNombre_Corto_Asociacion.Text = o.Nombre_Corto_Asociacion;
                tbasoPeriodo_Actual_Fecha_Periodo.Text = string.Format("{0:d}", o.asoPeriodo_Actual_Fecha);
            }
        }
        // Carga un objeto con los datos del formulario
        protected asoParametro ColocarDatosEnObjeto()
        {
            var o = new asoParametro();
            o.Id = _EntidadId;
            o.asoPeriodo_Id_Actual = Int32.Parse(tbasoPeriodo_Id_Actual.Text);
            o.Porcentaje_Comision_Por_Defecto = string.IsNullOrWhiteSpace(tbPorcentaje_Comision_Por_Defecto.Text) ? 0 : decimal.Parse(tbPorcentaje_Comision_Por_Defecto.Text);
            o.Valor_Reingreso = string.IsNullOrWhiteSpace(tbValor_Reingreso.Text) ? 0 : decimal.Parse(tbValor_Reingreso.Text);
            o.No_Periodos_Reingreso = Int32.Parse(tbNo_Periodos_Reingreso.Text);
            o.Valor_Accion_Minimo = string.IsNullOrWhiteSpace(tbValor_Accion_Minimo.Text) ? 0 : decimal.Parse(tbValor_Accion_Minimo.Text);
            o.Valor_Ahorro_Minimo = string.IsNullOrWhiteSpace(tbValor_Ahorro_Minimo.Text) ? 0 : decimal.Parse(tbValor_Ahorro_Minimo.Text);
            o.Tasa_Interes_Por_Defecto = string.IsNullOrWhiteSpace(tbTasa_Interes_Por_Defecto.Text) ? 0 : decimal.Parse(tbTasa_Interes_Por_Defecto.Text);
            o.Nombre_Largo_Asociacion = tbNombre_Largo_Asociacion.Text;
            o.Nombre_Corto_Asociacion = tbNombre_Corto_Asociacion.Text;

            return o;
        }
    }
}
