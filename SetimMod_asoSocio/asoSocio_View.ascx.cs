using System;
using System.Linq;
using System.Web.UI.WebControls;

using DotNetNuke.Services.Exceptions;
using DotNetNuke.UI.Modules;
using DotNetNuke.UI.Skins;
using DotNetNuke.Common;

using SetimBasico;
using System.Collections.Generic;
using DotNetNuke.Framework.JavaScriptLibraries;

namespace SetimMod_asoSocio
{
    public partial class asoSocio_View : SetimModulo
    {        
        // Entidad base
        private readonly asoSocioControl _EntidadControl = new asoSocioControl();
        // Cada vez que se llama a la página
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Nivel de la relación 0-Master0 1-Master1 2-Master2
            this._Nivel = 0;
            // Campo por defecto para ordenar la lista
            this._Ordenar_Campo_Defaul = "Users_Nombre";
            // Datos del módulo y del usuario del DNN
            this._ModuleId = ModuleContext.ModuleId;
            this._UserID = ModuleContext.PortalSettings.UserId;
            // Carga de jQuery
            JavaScript.RequestRegistration(CommonJs.jQuery);
            JavaScript.RequestRegistration(CommonJs.DnnPlugins);
            JavaScript.RequestRegistration(CommonJs.jQueryUI);
            // Solo si es primera vez, carga los datos por defecto.
            if (!IsPostBack)
            {
                // Verifica el estado de la página
                if (paginaEstado.ModuleID == _ModuleId)
                {
                    if (paginaEstado.Ordenar_Campo == "") paginaEstado.Ordenar_Campo = _Ordenar_Campo_Defaul;
                    dgMaster.PageSize = paginaEstado.NoFilasPorPagina;
                    if (paginaEstado.dgMasterItemIndex != -1) dgMaster.SelectedIndex = paginaEstado.dgMasterItemIndex;
                }
                else
                {
                    // Si no se trata del estado de esta página, se inicializa todo el estado
                    paginaEstado = new PaginaEstado();
                    paginaEstado.ModuleID = _ModuleId;
                    paginaEstado.Ordenar_Campo = _Ordenar_Campo_Defaul;
                }
                // Inicializa la lista de estados en el filtro
                CargarDdl_CamposDelFiltro();
                CargarDdl_Estados();
                // Carga de datos
                ConsultaDatos();
            }
            // Inicializa los links
            hlEstadoCta.NavigateUrl = ModuleContext.EditUrl("View_EstadoCta");
        }
        // Carga los estados desde una lista de SetimLista
        private void CargarDdl_Estados()
        {
            asoSetimListaDetControl SetimLista = new asoSetimListaDetControl();
            var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoSocio_Estado");
            ddlCab_Estado.DataSource = lista;
            ddlCab_Estado.DataTextField = "Texto";
            ddlCab_Estado.DataValueField = "Valor";
            ddlCab_Estado.DataBind();
            // Carga el estado del estado de la pagina
            ddlCab_Estado.SelectedValue = paginaEstado.Filtro_Estado ?? "TOD";
        }
        // Carga los campos para filtrar 
        private void CargarDdl_CamposDelFiltro()
        {
            asoSetimListaDetControl SetimLista = new asoSetimListaDetControl();
            var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoSocio_Lista_Filtros");
            ddlFiltro_Campo.DataSource = lista;
            ddlFiltro_Campo.DataTextField = "Texto";
            ddlFiltro_Campo.DataValueField = "Valor";
            ddlFiltro_Campo.DataBind();
            // Carga el filtro de los campos desde el estado de la pagina
            ddlFiltro_Campo.SelectedValue = paginaEstado.Filtro_Campo ?? "TOD";
            tbFiltro_Criterio.Text = paginaEstado.Filtro_Campo == null ? "" : paginaEstado.Filtro_Valor.ToString(); //Posible problema cuando no sea un string sino un int, decimal o fecha
        }
        // Organiza los comandos generados por el DataGrid
        protected void dgMaster_OnItemCommand(object source, DataGridCommandEventArgs e)
        {
            int entidadId;
            switch (e.CommandName)
            {
                case "Borrar":
                    entidadId = int.Parse((string)e.CommandArgument);
                    BorrarEntidad(entidadId);
                    break;
                case "Page":
                    // recibe de argumento: Next o Prev y lo traduce en el índice de la nueva página
                    string dir = (string)e.CommandArgument;
                    int indice = ((DataGrid)source).CurrentPageIndex;
                    if (dir == "Next")
                        indice = indice + 1;
                    else
                        indice = indice - 1;
                    paginaEstado.PaginaActual = indice;
                    ConsultaDatos();
                    break;
                case "Select":
                    paginaEstado.dgMasterItemIndex = e.Item.ItemIndex;
                    string sEntidadId = e.Item.Cells[0].Text;
                    paginaEstado.Master_Id = Int32.Parse(sEntidadId);
                    break;
            }
        }

        // Proceso de carga de datos en el GridView
        protected void ConsultaDatos()
        {
            // Consulta los datos del SP SelByAll
            var datos = ConsultaSP();
            // Calcula la página que el toca en el datagrid
            int noDatos = datos.Count();
            if (noDatos > 0 || (noDatos == 0 && paginaEstado.PaginaActual == 0))
            {
                dgMaster.VirtualItemCount = noDatos < paginaEstado.NoFilasPorPagina ?
                      (paginaEstado.PaginaActual) * paginaEstado.NoFilasPorPagina + noDatos
                    : (paginaEstado.PaginaActual + 2) * paginaEstado.NoFilasPorPagina;
                dgMaster.CurrentPageIndex = paginaEstado.PaginaActual;
                dgMaster.PageSize = paginaEstado.NoFilasPorPagina;
                // Coloca los datos en el grid
                dgMaster.DataSource = datos;
                dgMaster.DataBind();
                // Accede al Footer del DataGrid y pone el número de registros por página
                int NoRegs = dgMaster.Controls[0].Controls.Count;
                var footer = (DataGridItem)dgMaster.Controls[0].Controls[NoRegs - 2];
                var ddlNoFilasPorPagina = (DropDownList)(footer.FindControl("ddlNoFilasPorPagina"));
                ddlNoFilasPorPagina.SelectedValue = dgMaster.PageSize.ToString();
            }
        }
        // Proceso para consultar a la base los datos
        private IList<asoSocio> ConsultaSP()
        {
            IList<asoSocio> res = new List<asoSocio>();
            res = _EntidadControl._0SelByAll(
                paginaEstado.Filtro_Estado,
                paginaEstado.Filtro_Campo, paginaEstado.Filtro_Valor,
                paginaEstado.PaginaActual, paginaEstado.NoFilasPorPagina,
                paginaEstado.Ordenar_Campo, paginaEstado.Ordenar_Sentido);
            return res;
        }
        // Proceso de borrado de la fila
        protected void BorrarEntidad(int entidadId)
        {
            try
            {
                var oSocio = _EntidadControl._1SelById(entidadId);
                int res = _EntidadControl._4Del(oSocio);
                Response.Redirect(Request.RawUrl, false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                const string headerText = "Error";
                const string messageText = "Al borrar hay error. Mire en el visor.";
                Skin.AddModuleMessage(this,
                    headerText,
                    messageText,
                    DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning);
            }
        }
        // Carga masiva de los socios en base de los usuario que tienen rol ="Socio"
        protected void btCopiarSocios_OnClick(object sender, EventArgs e)
        {
            try
            {
                _EntidadControl._5CopyFromUsers();
                Response.Redirect(Request.RawUrl, false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                const string headerText = "Error";
                const string messageText = "Al copiar los usuarios hay error. <br/> Mire en el visor.";
                Skin.AddModuleMessage(this,
                    headerText,
                    messageText,
                    DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning);
            }
        }

        // Aplica los parámetros de los aportes de reingreso
        // Crea los reingresos de aportes de acuerdo con los datos de los parámetros y del socio seleccionado
        protected void btAplicarReingreso_OnClick(object sender, EventArgs e)
        {
            try
            {
                // Consulta al usuario
                int SocioId = (int) paginaEstado.Master_Id;
                var ctlSocio = new asoSocioControl();
                var oSocio = ctlSocio._1SelById(SocioId);
                decimal valorAhorro = oSocio.Valor_Ahorro;
                // Consulta los parámetros
                var ctlParam = new asoParametroControl();
                var oParam = ctlParam._1SelById(1);
                int PeriodoActual = oParam.asoPeriodo_Id_Actual;
                int noPeriodosReingreso = oParam.No_Periodos_Reingreso;
                decimal valorReingreso = oParam.Valor_Reingreso;
                // Consulta los aportes que existan en los períodos que se van a generar y los borra
                var ctlAportes = new asoPeriodoAporteControl();
                var lstAportesABorrar = ctlAportes._0SelBy_asoPeriodo_Id_12Regs(PeriodoActual);
                var lstAportesABorrar_Enum = lstAportesABorrar.Where(ap => ap.asoSocio_Id == oSocio.Id);
                foreach (var aporte in lstAportesABorrar_Enum)
                    ctlAportes._4Del(aporte);
                // Genera los aportes                
                for (int i = 0; i < noPeriodosReingreso; i++)
                {
                    var aporte = new asoPeriodoAporte();
                    aporte.asoPeriodo_Id = PeriodoActual + i;
                    aporte.asoSocio_Id = SocioId;
                    aporte.Descripcion = string.Format("Aporte generado por reingreso {0}/{1}", i+1, noPeriodosReingreso); // Este texto hace que no se borre el aporte cuando se crean los aportes
                    aporte.Tipo = "ING";
                    aporte.Estado = "PEN";
                    aporte.Valor_Accion = oSocio.Valor_Accion + valorReingreso;
                    aporte.Valor_Ahorro = valorAhorro;
                    aporte.Valor_Voluntario = oSocio.Valor_Voluntario;

                    ctlAportes._2Ins(aporte);
                }
                // Fin
                Response.Redirect(Request.RawUrl, false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                const string headerText = "Error";
                const string messageText = "Al copiar los usuarios hay error. <br/> Mire en el visor.";
                Skin.AddModuleMessage(this,
                    headerText,
                    messageText,
                    DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning);
            }
        }

        protected void btConfigAportes_OnClick(object sender, EventArgs e)
        {
            int vId = (int)dgMaster.DataKeys[dgMaster.SelectedIndex];
            string url = Globals.NavigateURL(ModuleContext.PortalSettings.ActiveTab.TabID, "Edit", "mid", ModuleContext.ModuleId.ToString(), "EntidadId", vId.ToString());
            Response.Redirect(url + "?popUp=true");
        }

        protected void dgMaster_SortCommand(object source, DataGridSortCommandEventArgs e)
        {

            if (paginaEstado.Ordenar_Campo == e.SortExpression)
                paginaEstado.Ordenar_Sentido = paginaEstado.Ordenar_Sentido == "ASC" ? "DESC" : "ASC";
            else
            {
                paginaEstado.Ordenar_Campo = e.SortExpression;
                paginaEstado.Ordenar_Sentido = "ASC";
            }
            // Consulta los datos
            ConsultaDatos();
        }

        protected void dgMaster_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[0].ColumnSpan = 2;
                e.Item.Cells[0].Text = string.Format("Página No: {0}", dgMaster.CurrentPageIndex + 1);
                e.Item.Cells[e.Item.Cells.Count - 3].ColumnSpan = 2;
                e.Item.Cells.RemoveAt(e.Item.Cells.Count - 1);
                e.Item.Cells.RemoveAt(e.Item.Cells.Count - 1);
            }
        }

        protected void ddlNoFilasPorPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            int noFilasPorPagina = int.Parse(((DropDownList)sender).SelectedValue.ToString());
            paginaEstado.NoFilasPorPagina = noFilasPorPagina;
            paginaEstado.PaginaActual = 0;
            ConsultaDatos();
        }

        protected void ddlFiltro_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddl = (DropDownList)sender;
            paginaEstado.Filtro_Estado = ddl.SelectedValue == "TOD" ? null : ddl.SelectedValue;
            paginaEstado.PaginaActual = 0;
            ConsultaDatos();
        }

        protected void ddlFiltro_Campo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddl = (DropDownList)sender;
            paginaEstado.Filtro_Campo = ddl.SelectedValue == "TOD" ? null : ddl.SelectedValue;
            paginaEstado.Filtro_Valor = tbFiltro_Criterio.Text;
            paginaEstado.PaginaActual = 0;
            ConsultaDatos();
        }

        protected void btBuscar_Click(object sender, EventArgs e)
        {
            ddlFiltro_Campo_SelectedIndexChanged(ddlFiltro_Campo, e);
        }

    }
}