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
    public partial class asoSocio_Estado_Cta : SetimModulo
    {
        // Entidad base
        private readonly asoPeriodoAporteControl _EntidadControl = new asoPeriodoAporteControl();
        private int Periodo_Actual_Id = -1;
        // Cada vez que se llama a la página
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Consulta el período actual
            asoParametroControl ctlParam = new asoParametroControl();
            var oParam = ctlParam._1SelById(1);
            Periodo_Actual_Id = oParam.asoPeriodo_Id_Actual;
            // Carga el nivel en jerarquía de master/detail 
            this._Nivel = 1;
            // Carga de jQuery
            JavaScript.RequestRegistration(CommonJs.jQuery);
            JavaScript.RequestRegistration(CommonJs.DnnPlugins);
            JavaScript.RequestRegistration(CommonJs.jQueryUI);
            // Datos del módulo y del usuario del DNN
            this._ModuleId = ModuleContext.ModuleId;
            this._UserID = ModuleContext.PortalSettings.UserId;
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
            if (noDatos > 0 )
            {
                // Coloca los datos en el grid
                dgMasterAportes.DataSource = datosAportes;
                dgMasterAportes.DataBind();
            }
            //
            var datosCuotas = ConsultaSPCuotas();
            noDatos = datosCuotas.Count();
            if (noDatos > 0)
            {
                // Coloca los datos en el grid
                dgMasterCuotas.DataSource = datosCuotas;
                dgMasterCuotas.DataBind();
            }
            //
            var datosDebitos = ConsultaSPDebitos();
            noDatos = datosDebitos.Count();
            if (noDatos > 0)
            {
                // Coloca los datos en el grid
                dgMasterDebito.DataSource = datosDebitos;
                dgMasterDebito.DataBind();
            }
        }
        // Proceso para consultar a la base los datos
        private IList<asoPeriodoAporte> ConsultaSPAportes()
        {
            IList<asoPeriodoAporte> res = new List<asoPeriodoAporte>();
            res = _EntidadControl._0SelByPeriodoYSocio_ConSaldos(
                    Periodo_Actual_Id,
                    (int)paginaEstadoMaster.Master_Id
                );
            return res;
        }
        private IList<asoPeriodoCuota> ConsultaSPCuotas()
        {
            IList<asoPeriodoCuota> res = new List<asoPeriodoCuota>();
            // En caso de filtrar por estado, utilizar paginaEstado.Filtro_Estado
            asoPeriodoCuotaControl ctlCuota = new asoPeriodoCuotaControl();
            res = ctlCuota._0SelByasoSocio_Id(
                    (int)paginaEstadoMaster.Master_Id,
                    Periodo_Actual_Id
                );            
            return res;
        }
        private IList<asoPeriodoDebito> ConsultaSPDebitos()
        {
            IList<asoPeriodoDebito> res = new List<asoPeriodoDebito>();
            // En caso de filtrar por estado, utilizar paginaEstado.Filtro_Estado
            asoPeriodoDebitoControl ctlDebito = new asoPeriodoDebitoControl();
            res = ctlDebito._0SelByasoSocio_Id_Desc_Coutas(
                    (int)paginaEstadoMaster.Master_Id,
                    Periodo_Actual_Id
                );
            return res;
        }
    }
}