using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.UI.Skins;
using DotNetNuke.Common;
using DotNetNuke.Framework.JavaScriptLibraries;
using SetimBasico;

namespace SetimMod_asoPrestamoTmp
{
    public partial class asoPrestamoTmp_View : SetimModulo
    {
        // Entidad base
        private readonly asoPrestamoTmpControl _EntidadControl = new asoPrestamoTmpControl();
        // Cada vez que se llama a la página
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Carga el nivel en jerarquía de master/detail 
            this._Nivel = 0;
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
                CargarDdl_Estados();
                // Carga de datos
                ConsultaDatos();
            }
            // Inicializa el botón de edición
            addButton.NavigateUrl = ModuleContext.EditUrl("Edit");
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
        private IList<asoPrestamoTmp> ConsultaSP()
        {
            IList<asoPrestamoTmp> res = new List<asoPrestamoTmp>();
            // En caso de filtrar por estado, utilizar paginaEstado.Filtro_Estado
            res = _EntidadControl._0SelByAll(
                null, //paginaEstadoMaster.Master_Id,
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
        protected void btBuscar_Click(object sender, EventArgs e)
        {
            ddlFiltro_Campo_SelectedIndexChanged(ddlFiltro_Campo, e);
        }
        // Carga los estados desde una lista 
        private void CargarDdl_Estados()
        {
            asoSetimListaDetControl SetimLista = new asoSetimListaDetControl();
            var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoPrestamoTmp_Estado");
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
            var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoPrestamoTmp_Filtro_Campos");
            ddlFiltro_Campo.DataSource = lista;
            ddlFiltro_Campo.DataTextField = "Texto";
            ddlFiltro_Campo.DataValueField = "Valor";
            ddlFiltro_Campo.DataBind();
            // Carga el filtro de los campos desde el estado de la pagina
            ddlFiltro_Campo.SelectedValue = paginaEstado.Filtro_Campo ?? "TOD";
            tbFiltro_Criterio.Text = paginaEstado.Filtro_Campo == null ? "" : paginaEstado.Filtro_Valor.ToString(); //Posible problema cuando no sea un string sino un int, decimal o fecha
        }
        // Boton para ejecutar una acción
        protected void btAccion_OnClick(object sender, EventArgs e)
        {
            try
            {
                // Carga los datos de los préstamos vigentes en las tablas del sistema

                var lstPrestamosTmp = _EntidadControl._0Sel();
                var ctlPrestamo = new asoPrestamoControl();
                var ctlSocio = new asoSocioControl();
                var ctlCuota = new asoPeriodoCuotaControl();
                var ctlParam = new asoParametroControl();

                // Consulta los parámetros
                var oParam = ctlParam._1SelById(1);
                // Lista de mensajes
                List<string> errores = new List<string>();

                foreach (var oPrestamoTmp in lstPrestamosTmp)
                {
                    // Busca al socio por la cédula
                    var lstSocioRes = ctlSocio._0SelByAll(CI: oPrestamoTmp.CI);
                    // Si el usuario no existe se pasa al siguiente de la lista
                    if (lstSocioRes.Count == 0)
                    {
                        errores.Add(string.Format("Socio no encontrado con el CI: {0}", oPrestamoTmp.CI));
                        continue;
                    }
                    var oSocio = lstSocioRes[0];
                    // Crear el préstamo 
                    var oPrestamo = new asoPrestamo();
                    oPrestamo.asoSocio_Id = oSocio.Id;
                    oPrestamo.asoSocio_Id_Garante = oSocio.Id;
                    oPrestamo.Descripcion = string.Format("Préstamo anterior al sistema. Valor original {0:N2}, Períodos original: {1}",
                        oPrestamoTmp.Valor_Prestamo, oPrestamoTmp.No_Periodos);
                    oPrestamo.Fecha_Solicitud = DateTime.Today;
                    oPrestamo.No_Periodos = oPrestamoTmp.No_Periodos_Faltantes;
                    oPrestamo.Tasa_Interes = 8;
                    oPrestamo.Valor = oPrestamoTmp.No_Periodos_Faltantes * oPrestamoTmp.Valor_Capital;
                    oPrestamo.Estado = "APR";
                    // Graba el préstamo
                    int PrestamoId = ctlPrestamo._2Ins(oPrestamo);
                    // Si el prestamo es menor que 1, entonces pasa al siguiente en la lista
                    if (PrestamoId < 1)
                    {
                        errores.Add(string.Format("Error al insertar el prestamo del socio: {0} por valor: {1:N2}", oPrestamoTmp.CI, oPrestamoTmp.Valor_Prestamo));
                        continue;
                    }
                    // Crear las cuotas del préstamo
                    for (int i = 0; i < oPrestamoTmp.No_Periodos_Faltantes; i++)
                    {
                        var oCuota = new asoPeriodoCuota();
                        oCuota.asoPeriodo_Id = oParam.asoPeriodo_Id_Actual + i;
                        oCuota.asoPrestamo_Id = PrestamoId;
                        oCuota.Valor_Capital = oPrestamoTmp.Valor_Capital;
                        oCuota.Valor_Interes = oPrestamoTmp.Valor_Interes;
                        oCuota.Estado = "PEN";
                        oCuota.Descripcion = "Cuota generada en la carga inicial del sistema.";
                        int CuotaId = ctlCuota._2Ins(oCuota);
                        // Si el prestamo es menor que 1, entonces pasa al siguiente en la lista
                        if (CuotaId < 1)
                        {
                            errores.Add(string.Format("Error al insertar la cuota del prestamo: {0}.", PrestamoId));
                            continue;
                        }
                    }
                }
                if (errores.Count > 0)
                {
                    string erroresAcumulado = "";
                    foreach (var error in errores) erroresAcumulado += error;
                    throw new Exception(erroresAcumulado);
                }
                Response.Redirect(Request.RawUrl, false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                const string headerText = "Error";
                const string messageText = "Al ejecutar el proceso. <br/> Mire en el visor.";
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
