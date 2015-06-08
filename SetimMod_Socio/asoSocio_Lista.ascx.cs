using System;
using System.Linq;
using System.Web.UI.WebControls;

using DotNetNuke.Services.Exceptions;
using DotNetNuke.UI.Modules;
using DotNetNuke.UI.Skins;
using DotNetNuke.Collections;
using DotNetNuke.Common.Lists;

using SetimBasico;

namespace SetimMod_Socio
{
    public partial class asoSocio_Lista : ModuleUserControlBase
    {
        // Usuario
        private int _UserId;
        private int _ModuleId;
        // Campo por defecto para ordenar la lista
        private string _Ordenar_Campo_Defaul = "Users_Nombre";
        // Estado de la página
        private PaginaEstado paginaEstado 
        {
            get
            {
                if (Session["paginaEstado"] == null)
                    Session["paginaEstado"]= new PaginaEstado();
                return (PaginaEstado)Session["paginaEstado"];
            }
            set
            {
                Session["paginaEstado"] = value;
            }
        }
        // Entidad base
        private readonly asoSocioControl _EntidadControl = new asoSocioControl();
        // Cada vez que se llama a la página
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Datos del módulo y del usuario del DNN
            _ModuleId = ModuleContext.ModuleId;
            _UserId = ModuleContext.PortalSettings.UserId;
            // Solo si es primera vez, carga los datos por defecto.
            if (!IsPostBack)
            {
                // Verifica el estado de la página
                if (paginaEstado.ModuleID == _ModuleId)
                {
                    if (paginaEstado.Ordenar_Campo == "") paginaEstado.Ordenar_Campo = _Ordenar_Campo_Defaul;
                    dgMaster.PageSize = paginaEstado.NoFilasPorPagina;
                }
                else
                {
                    paginaEstado.ModuleID = _ModuleId;
                    paginaEstado.Ordenar_Campo = _Ordenar_Campo_Defaul;
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
        // Carga los estados desde una lista de SetimLista
        private void CargarDdl_Estados()
        {
            asoSetimListaDetControl SetimLista = new asoSetimListaDetControl();
            var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoSocio_Estado");
            ddlCab_Estado.DataSource = lista;
            ddlCab_Estado.DataTextField = "Texto";
            ddlCab_Estado.DataValueField = "Valor";
            ddlCab_Estado.DataBind();
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
        }
        // Organiza los comandos generados por el DataGrid
        protected void dgMaster_OnItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (e.CommandName)
            { 
                case "Borrar":
                    int entidadId = int.Parse((string) e.CommandArgument);
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
            }            
        }
        // Filtrar 
        protected void filtrar()
        { 
            // Estado

        }
        // Proceso de carga de datos en el GridView
        protected void ConsultaDatos()
        {
            // Saca los datos del estado de la pagina
            int PaginaIndice = paginaEstado.PaginaActual;
            int NoRegsPorPagina = paginaEstado.NoFilasPorPagina;
            // Actualiza los datos en el DataGrid
            dgMaster.CurrentPageIndex = PaginaIndice;
            dgMaster.PageSize = NoRegsPorPagina;
            // Consulta los datos del SP SelByAll
            var datos = _EntidadControl._0SelByAll(
                null, null, null, null, null, null, null,
                PaginaIndice, NoRegsPorPagina,
                paginaEstado.Ordenar_Campo, paginaEstado.Ordenar_Sentido);
            // Calcula la página que el toca
            int noDatos = datos.Count();
            dgMaster.VirtualItemCount = noDatos < NoRegsPorPagina ?
                  (PaginaIndice) * NoRegsPorPagina + noDatos
                : (PaginaIndice + 2) * NoRegsPorPagina;
            // Coloa los datos en el grid
            dgMaster.DataSource = datos;
            dgMaster.DataBind();
            // Accede al Footer del DataGrid y pone el número de registros por página
            int NoRegs = dgMaster.Controls[0].Controls.Count;
            var footer = (DataGridItem)dgMaster.Controls[0].Controls[NoRegs - 2];
            var ddlNoFilasPorPagina = (DropDownList)(footer.FindControl("ddlNoFilasPorPagina"));
            ddlNoFilasPorPagina.SelectedValue = dgMaster.PageSize.ToString();
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
                Response.Redirect(Request.RawUrl,false);
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
                e.Item.Cells[0].Text = string.Format("Página No: {0}",dgMaster.CurrentPageIndex+1);
                e.Item.Cells[e.Item.Cells.Count - 3].ColumnSpan = 2;
                e.Item.Cells.RemoveAt(e.Item.Cells.Count - 1 );
                e.Item.Cells.RemoveAt(e.Item.Cells.Count - 1);
            }
        }

        protected void ddlNoFilasPorPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            int noFilasPorPagina = int.Parse( ((DropDownList)sender).SelectedValue.ToString());
            paginaEstado.NoFilasPorPagina = noFilasPorPagina;
            paginaEstado.PaginaActual = 0;
            ConsultaDatos();
        }

        protected void ddlFiltro_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}