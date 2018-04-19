using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.UI.Skins;
using DotNetNuke.Common;
using DotNetNuke.Framework.JavaScriptLibraries;
using SetimBasico;

namespace SetimMod_asoSocio
{
    public partial class asoSocio_Estado_Cta_Individual : SetimModulo
    {
        // Entidad base
        private readonly asoPeriodoAporteControl _EntidadControl = new asoPeriodoAporteControl();
        private int Periodo_Actual_Id = -1;
        private int SocioId;
        // Cada vez que se llama a la página
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Consulta el período actual
            asoParametroControl ctlParam = new asoParametroControl();
            var oParam = ctlParam._1SelById(1);
            Periodo_Actual_Id = oParam.asoPeriodo_Id_Actual;
            // Consulta el usuario y el socio
            this._UserID = ModuleContext.PortalSettings.UserId;
            var ctlSocio = new asoSocioControl();
            var oSocio = ctlSocio._1SelByUserID(this._UserID);
            SocioId = oSocio == null ? -1 : oSocio.Id;
            // Carga el nivel en jerarquía de master/detail 
            this._Nivel = 0;
            // Carga de jQuery
            JavaScript.RequestRegistration(CommonJs.jQuery);
            JavaScript.RequestRegistration(CommonJs.DnnPlugins);
            JavaScript.RequestRegistration(CommonJs.jQueryUI);
            // Datos del módulo y del usuario del DNN
            this._ModuleId = ModuleContext.ModuleId;
            // Solo si es primera vez, carga los datos por defecto.
            if (!IsPostBack)
            {
                // Verifica el estado de la página
                if (paginaEstado.ModuleID == this._ModuleId)
                {
                    ;
                }
                else
                {
                    // Si no se trata del estado de esta página, se inicializa todo el estado
                    paginaEstado = new PaginaEstado();
                    paginaEstado.ModuleID = this._ModuleId;
                }
                // Carga los años
                CargarDdl_Anio();
                // Carga los períodos
                CargarDdl_CamposDelFiltro();
                // Carga de datos
                ConsultaDatos();
            }
        }
        // Proceso de carga de datos en el GridView
        protected void ConsultaDatos()
        {
            // Consulta los datos del SP SelByAll
            var datosAportes = ConsultaSPAportes();
            int noDatos = datosAportes.Count();
            //if (noDatos > 0 )
            {
                // Coloca los datos en el grid
                dgMasterAportes.DataSource = datosAportes;
                dgMasterAportes.DataBind();
            }
            //
            var datosCuotas = ConsultaSPCuotas();
            noDatos = datosCuotas.Count();
            //if (noDatos > 0)
            {
                // Coloca los datos en el grid
                dgMasterCuotas.DataSource = datosCuotas;
                dgMasterCuotas.DataBind();
            }
            //
            var datosDebitos = ConsultaSPDebitos();
            noDatos = datosDebitos.Count();
            //if (noDatos > 0)
            {
                // Coloca los datos en el grid
                dgMasterDebito.DataSource = datosDebitos;
                dgMasterDebito.DataBind();
            }
            // Calcula los subtotales, total, el nombre del socio y los títulos
            Decimal SumAportes = 0, SumCuotas = 0, SumDebitos = 0, SumTotal = 0;
            String strSocioNombre = _Usuario_Nombre;

            SumAportes = datosAportes.Sum(aporte => aporte.Valor_Suma);
            SumCuotas = datosCuotas.Sum(cuota => cuota.Valor_Suma);
            SumDebitos = datosDebitos.Sum(debito => debito.Valor_Mas_Comision);
            SumTotal = SumAportes + SumCuotas + SumDebitos;

            AportesTotal.Text = string.Format("{0:N2}", SumAportes);
            PrestamosTotal.Text = string.Format("{0:N2}", SumCuotas);
            DebitosTotal.Text = string.Format("{0:N2}", SumDebitos);
            // Carga el título            
            lbFecha.Text = string.Format("Fecha: {0:d}", DateTime.Now);
            lbSocioNombre.Text = string.Format("Socio: {0}", strSocioNombre);
            lbSumaTotal.Text = string.Format("Total: {0:N2} ", SumTotal);
        }
        // Proceso para consultar a la base los datos
        private IList<asoPeriodoAporte> ConsultaSPAportes()
        {
            IList<asoPeriodoAporte> res = new List<asoPeriodoAporte>();
            res = _EntidadControl._0SelByPeriodoYSocio_ConSaldos(
                    Int32.Parse((string)paginaEstado.Filtro_Valor), //Periodo_Actual_Id,
                    SocioId  // usuario
                ); 
            return res;
        }
        private IList<asoPeriodoCuota> ConsultaSPCuotas()
        {
            IList<asoPeriodoCuota> res = new List<asoPeriodoCuota>();
            // En caso de filtrar por estado, utilizar paginaEstado.Filtro_Estado
            asoPeriodoCuotaControl ctlCuota = new asoPeriodoCuotaControl();
            res = ctlCuota._0SelByasoSocio_Id(
                    SocioId,  // usuario
                    Int32.Parse((string)paginaEstado.Filtro_Valor) //Periodo_Actual_Id
                );            
            return res;
        }
        private IList<asoPeriodoDebito> ConsultaSPDebitos()
        {
            IList<asoPeriodoDebito> res = new List<asoPeriodoDebito>();
            // En caso de filtrar por estado, utilizar paginaEstado.Filtro_Estado
            asoPeriodoDebitoControl ctlDebito = new asoPeriodoDebitoControl();
            res = ctlDebito._0SelByasoSocio_Id_Desc_Coutas(
                    SocioId, // usuario
                    Int32.Parse((string)paginaEstado.Filtro_Valor) //Periodo_Actual_Id
                );
            return res;
        }
        // Carga el campo para filtrar años
        private void CargarDdl_Anio()
        {
            asoAnioControl ctlAnio = new asoAnioControl();
            var lista = ctlAnio._0Sel();

            ddlFiltro_Anio.DataSource = lista;
            ddlFiltro_Anio.DataTextField = "Descripcion";
            ddlFiltro_Anio.DataValueField = "Anio";
            ddlFiltro_Anio.DataBind();

            paginaEstado.Filtro2_Valor = ddlFiltro_Anio.SelectedValue;

        }
        // Carga los campos para filtrar 
        private void CargarDdl_CamposDelFiltro()
        {
            asoPeriodoControl ctlPeriodo = new asoPeriodoControl();
            var lista = ctlPeriodo._0SelByAnio_Periodos_Cerrados(Int32.Parse((String)(paginaEstado.Filtro2_Valor)));
            foreach (var o in lista)
                o.Descripcion = string.Format("({0}) {1:d}",o.Id,o.Fecha_Periodo);

            ddlFiltro_Campo.DataSource = lista;
            ddlFiltro_Campo.DataTextField = "Descripcion";
            ddlFiltro_Campo.DataValueField = "Id";
            ddlFiltro_Campo.DataBind();
            // Carga el filtro de los campos desde el estado de la pagina
            paginaEstado.Filtro_Valor = ddlFiltro_Campo.SelectedValue;
        }
        // Cambio del año
        protected void ddlFiltro_Anio_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddl = (DropDownList)sender;
            paginaEstado.Filtro2_Valor = ddl.SelectedValue;
            CargarDdl_CamposDelFiltro();
            ConsultaDatos();
        }
        // Cambio del período
        protected void ddlFiltro_Campo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddl = (DropDownList)sender;
            paginaEstado.Filtro_Valor = ddl.SelectedValue;
            ConsultaDatos();
        }
    }
}