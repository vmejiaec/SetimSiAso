using System;
using DotNetNuke.Common;
using DotNetNuke.UI.Modules;
using DotNetNuke.Collections;
using SetimBasico;

namespace SetimMod_asoPrestamo
{
    public partial class asoPrestamo_PreCancelar : SetimModulo
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
                ColocarDatosEnFormulario();
            }
        }
        // Guardar o actualizar dependiendo del parámetro de llamada a la pantalla
        protected void Guardar(object sender, EventArgs e)
        {
            // Calcula la diferencia de capital abonado
            decimal TasaInteres = decimal.Parse(tbTasaInteres.Text);
            decimal Abono = decimal.Parse( tbAbono.Text);
            decimal Capital = decimal.Parse(tbCapital.Text);
            decimal Interes = decimal.Parse(tbInteres.Text);
            decimal DifCapital = Capital + Interes - Abono;
            int NoPeriodosFaltan = Int32.Parse( tbPeriodosQueFaltan.Text);
            // Si la diferencia es cero, el abono cubre toda la precancelación
            var lstCuotas = _EntidadControl._0SelByasoPrestamo_Id((int)paginaEstadoMaster.Master_Id);
            if (DifCapital == 0)
            {
                bool bPrimerPendiente = true;
                foreach (var cuota in lstCuotas)
                {
                    if (cuota.Estado == "PEN")
                    {
                        if (bPrimerPendiente)
                        {   
                            // Se modifica la primera cuota pendiente de la tabla de amortización.
                            cuota.Valor_Capital = Capital;
                            cuota.Valor_Interes = Interes;
                            _EntidadControl._3Upd(cuota);
                            bPrimerPendiente = false;
                        }
                        else
                        {
                            // Se borran el resto de cuotas.
                            _EntidadControl._4Del(cuota);
                        }
                    }
                }
            }
            else  // La diferencia de capital permite recalcular la tabla actual
            { 
                // se barre las cuotas para actualizar el capital y el interés
                bool bPrimerPendiente = true;
                decimal DifCapitalPeriodo = Math.Round( DifCapital /(NoPeriodosFaltan - 1),2);
                decimal CapitalArrastre = DifCapital;
                int NoPer = 1;
                foreach (var cuota in lstCuotas)
                {
                    if (cuota.Estado == "PEN")
                    {
                        if (bPrimerPendiente)
                        {
                            // Se modifica la primera cuota pendiente de la tabla de amortización.
                            cuota.Valor_Capital = Abono - Interes;
                            cuota.Valor_Interes = Interes;
                            _EntidadControl._3Upd(cuota);
                            bPrimerPendiente = false;
                        }
                        else
                        {
                            // Se Actualiza el resto de cuotas
                            cuota.Valor_Interes = Math.Round(CapitalArrastre * TasaInteres / 1200, 2);
                            CapitalArrastre -= DifCapitalPeriodo;
                            if (NoPer == NoPeriodosFaltan - 1)
                                cuota.Valor_Capital = DifCapitalPeriodo + CapitalArrastre;
                            else
                            {
                                cuota.Valor_Capital = DifCapitalPeriodo;
                            }
                            _EntidadControl._3Upd(cuota);
                            NoPer ++;
                        }
                    }
                }
            }
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
            // Consulta los datos del prestamo
            var ctlPrestamo = new asoPrestamoControl();
            var oPrestamo = ctlPrestamo._1SelById((int)paginaEstadoMaster.Master_Id);
            // Consulta los datos de las cuotas del prestamo
            var lstCuotas = _EntidadControl._0SelByasoPrestamo_Id((int)paginaEstadoMaster.Master_Id);
            // Calcula el valor del capital y el interes para pre cancelar
            decimal CapitalPagado = 0;
            decimal InteresPagado = 0;
            int NoPeriodosPagados = 0;
            foreach (var cuota in lstCuotas)
            {
                if (cuota.Estado == "COB")
                {
                    CapitalPagado += cuota.Valor_Capital;
                    InteresPagado += cuota.Valor_Interes;
                    NoPeriodosPagados++;
                }
            }
            decimal CapitalPorPagar = oPrestamo.Valor - CapitalPagado;
            decimal InteresPorPagar = Math.Round(CapitalPorPagar * oPrestamo.Tasa_Interes / 1200, 2);
            decimal AbonoTotal = CapitalPorPagar + InteresPorPagar;
            int NoPeriodosFaltantes = oPrestamo.No_Periodos - NoPeriodosPagados;
            // Coloca los datos en la pantalla
            tbTasaInteres.Text = string.Format("{0:N2}", oPrestamo.Tasa_Interes);
            tbCapital.Text = string.Format("{0:N2}",CapitalPorPagar);
            tbInteres.Text = string.Format("{0:N2}", InteresPorPagar);
            tbCapitalMasInteres.Text = string.Format("{0:N2}", AbonoTotal);
            tbPeriodosQueFaltan.Text = NoPeriodosFaltantes.ToString();
            tbAbono.Text = string.Format("{0:N2}", AbonoTotal);
        }
    }
}