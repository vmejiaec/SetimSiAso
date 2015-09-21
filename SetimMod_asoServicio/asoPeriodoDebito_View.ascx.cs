using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.UI.Skins;
using DotNetNuke.Common;
using DotNetNuke.Framework.JavaScriptLibraries;
using SetimBasico;

namespace SetimMod_asoPeriodoDebito
{
    public partial class asoPeriodoDebito_View : SetimModulo
    {
        // Entidad base
        private readonly asoPeriodoDebitoControl _EntidadControl = new asoPeriodoDebitoControl();
        // Cada vez que se llama a la página
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
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
                    if (paginaEstado.Ordenar_Campo == "") paginaEstado.Ordenar_Campo = _Ordenar_Campo_Defaul;
                    dgMaster.PageSize = paginaEstado.NoFilasPorPagina;
                    if (paginaEstado.dgMasterItemIndex != -1) dgMaster.SelectedIndex = paginaEstado.dgMasterItemIndex;
                }
                else
                {
                    // Si no se trata del estado de esta página, se inicializa todo el estado
                    paginaEstado = new PaginaEstado();
                    paginaEstado.ModuleID = this._ModuleId;
                    paginaEstado.Ordenar_Campo = this._Ordenar_Campo_Defaul;
                }
                // Inicializa la lista de estados en el filtro
                CargarDdl_CamposDelFiltro();
                CargarDdl_Periodos();
                CargarDdl_Estados();
                // Carga de datos
                ConsultaDatos();
            }
            // Inicializa el botón de edición
            addButton.NavigateUrl = ModuleContext.EditUrl("Det_EditDebito");
            Reporte.NavigateUrl = ModuleContext.EditUrl("Det_DebitoRep");
            hlCargaArchivo.NavigateUrl = ModuleContext.EditUrl("Det_DebitoArc");
            // Publica los avisos
            lbAvisos.Text = paginaEstado.Avisos;
            // Consulta el nombre del servicio
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
        private IList<asoPeriodoDebito> ConsultaSP()
        {
            IList<asoPeriodoDebito> res = new List<asoPeriodoDebito>();
            // Preparación del filtro por períodos
            string sPeriodoId = paginaEstado.Filtro_Tipo;
            if (string.IsNullOrEmpty(sPeriodoId)) sPeriodoId = "-1";
            int? iPeriodoId = Int32.Parse(sPeriodoId);
            if (iPeriodoId == -1) iPeriodoId = null;
            // En caso de filtrar por estado, utilizar paginaEstado.Filtro_Estado
            res = _EntidadControl._0SelByAll(
                iPeriodoId, //asoPeriodo_Id: null,
                paginaEstadoMaster.Master_Id, //asoServicio_Id: paginaEstadoMaster.Master_Id,
                null, //asoSocio_Id: null,
                paginaEstado.Filtro_Estado, //estado: paginaEstado.Filtro_Estado,
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
        // Eventos de los filtros
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
        protected void ddlFiltro_Periodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddl = (DropDownList)sender;
            paginaEstado.Filtro_Tipo = ddl.SelectedValue == "-1" ? null : ddl.SelectedValue;
            paginaEstado.PaginaActual = 0;
            ConsultaDatos();
        }
        protected void btBuscar_Click(object sender, EventArgs e)
        {
            ddlFiltro_Campo_SelectedIndexChanged(ddlFiltro_Campo, e);
        }
        // Carga los estados desde una lista 
        private void CargarDdl_Estados()
        {
            asoSetimListaDetControl SetimLista = new asoSetimListaDetControl();
            var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoPeriodoDebito_Estado");
            ddlCab_Estado.DataSource = lista;
            ddlCab_Estado.DataTextField = "Texto";
            ddlCab_Estado.DataValueField = "Valor";
            ddlCab_Estado.DataBind();
            // Carga el estado del estado de la pagina
            ddlCab_Estado.SelectedValue = paginaEstado.Filtro_Estado ?? "TOD";
        }

        // Carga los períodos --------------------------------------------------------------------
        private void CargarDdl_Periodos()
        {
            asoPeriodoControl ctlPeriodo = new asoPeriodoControl();
            var lista = ctlPeriodo._0SelByasoServicio_Id((int)paginaEstadoMaster.Master_Id);
            //Transformación linq para poner la fecha en la descripción y utilizarla en el dropdownlist
            var lst = (from fila in lista
                       select new asoPeriodo { Id = fila.Id, No_Periodo = fila.No_Periodo, Fecha_Periodo = fila.Fecha_Periodo, Estado = fila.Estado, Descripcion = string.Format("{0:d}", fila.Fecha_Periodo) }
                       ).ToList<asoPeriodo>();
            // Añade la fila para todos con el id=-1
            asoPeriodo itemTodos = new asoPeriodo();
            itemTodos.Id = -1; // -1 significa todos
            itemTodos.Descripcion = "Todos";
            lst.Add(itemTodos);
            // Carga el dropdownlist con la lista
            ddlCab_Periodo.DataSource = lst;
            ddlCab_Periodo.DataTextField = "Descripcion";
            ddlCab_Periodo.DataValueField = "Id";
            ddlCab_Periodo.DataBind();
            // Carga el estado del estado de la pagina
            ddlCab_Periodo.SelectedValue = paginaEstado.Filtro_Tipo ?? "-1";
        }
        // --------------------------------------------------------------------

        // Carga los campos para filtrar 
        private void CargarDdl_CamposDelFiltro()
        {
            asoSetimListaDetControl SetimLista = new asoSetimListaDetControl();
            var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoPeriodoDebito_Filtro_Campos");
            ddlFiltro_Campo.DataSource = lista;
            ddlFiltro_Campo.DataTextField = "Texto";
            ddlFiltro_Campo.DataValueField = "Valor";
            ddlFiltro_Campo.DataBind();
            // Carga el filtro de los campos desde el estado de la pagina
            ddlFiltro_Campo.SelectedValue = paginaEstado.Filtro_Campo ?? "TOD";
            tbFiltro_Criterio.Text = paginaEstado.Filtro_Campo == null ? "" : paginaEstado.Filtro_Valor.ToString(); //Posible problema cuando no sea un string sino un int, decimal o fecha
        }
        // Boton para ejecutar una acción
        protected void btGenerarDebitos_OnClick(object sender, EventArgs e)
        {
            try
            {
                int x = _EntidadControl._5GenerarDebitosDeUnServicio((int)paginaEstadoMaster.Master_Id);
                paginaEstado.Avisos = string.Format("Debitos generados: {0}", x);
                Response.Redirect(Request.RawUrl, false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                const string headerText = "Error.";
                string messageText = string.Format("Hay error al generar los débitos de este servicio: {0} <br/> {1}", exc.Message, exc.InnerException.Message);
                Skin.AddModuleMessage(this,
                    headerText,
                    messageText,
                    DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning);
            }
        }
        //btBorrarDebitosPEN_OnClick
        protected void btBorrarDebitosPEN_OnClick(object sender, EventArgs e)
        {
            try
            {
                int Servicio_Id = (int)paginaEstadoMaster.Master_Id;
                var lstDebitos = _EntidadControl._0SelByasoServicio_Id(Servicio_Id);
                foreach (var deb in lstDebitos)
                {
                    try
                    {
                        if (deb.Estado == "PEN")
                        {
                            _EntidadControl._4Del(deb);
                        }
                    }
                    catch (Exception exc)
                    {
                        continue;
                    }
                }
                
                Response.Redirect(Request.RawUrl, false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                const string headerText = "Error.";
                string messageText = string.Format("Hay error al generar los débitos de este servicio: {0} <br/> {1}", exc.Message, exc.InnerException.Message);
                Skin.AddModuleMessage(this,
                    headerText,
                    messageText,
                    DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning);
            }
        }
        // Boton para ejecutar una accion
        protected void btConfigAportes_OnClick(object sender, EventArgs e)
        {
            int vId = (int)dgMaster.DataKeys[dgMaster.SelectedIndex];
            string url = Globals.NavigateURL(ModuleContext.PortalSettings.ActiveTab.TabID, "Edit", "mid", ModuleContext.ModuleId.ToString(), "EntidadId", vId.ToString());
            Response.Redirect(url + "?popUp=true");
        }
    }
}
