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
        // Entidad base
        private readonly asoSocioControl _EntidadControl = new asoSocioControl();
        // Datos para el ordenamiento
        class PaginacionFiltroOrden 
        {
            public int NoFilasPorPagina { get; set; }
            public int PaginaActual { get; set; }
            public string OrdenarCampo { get; set; }
            public string OrdenarSentido { get; set; }
            public string FiltroNombre { get; set; }
            public string FiltroValor { get; set; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Datos del usuario del DNN
            _ModuleId = ModuleContext.ModuleId;
            _UserId = ModuleContext.PortalSettings.UserId;
            // Datos de la página actual            
            int paginaIndex = Request.QueryString.GetValueOrDefault("paginaIndex", 0);
            // Solo si es primera vez, carga los datos por defecto.
            if (!IsPostBack)
            {
                // Inicializa el ordenamiento
                if (Session["PaginacionFiltroOrden"] == null)
                    Session["PaginacionFiltroOrden"] = new PaginacionFiltroOrden()
                    {
                        OrdenarCampo = "Users_Nombre",
                        OrdenarSentido = "ASC"
                    };
                // Inicializa la lista de estados en el filtro
                CargarFiltro_Campo();
                CargarFiltro_Estado();                
                // Carga de datos
                ConsultaDatos(paginaIndex);
            }
            // Inicializa el botón de edición
            addButton.NavigateUrl = ModuleContext.EditUrl("Edit");
        }
        // Carga los estados desde una lista de SetimLista
        private void CargarFiltro_Estado()
        {
            asoSetimListaDetControl SetimLista = new asoSetimListaDetControl();
            var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoSocio_Estado");
            ddlCab_Estado.DataSource = lista;
            ddlCab_Estado.DataTextField = "Texto";
            ddlCab_Estado.DataValueField = "Valor";
            ddlCab_Estado.DataBind();
        }
        // Carga los campos para filtrar 
        private void CargarFiltro_Campo()
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
                    ConsultaDatos(indice);
                    break;
            }            
        }
        // Filtrar 
        protected void filtrar()
        { 
            // Estado

        }
        // Proceso de carga de datos en el GridView
        protected void ConsultaDatos(int PaginaIndice)
        {
            PaginacionFiltroOrden filtros = (PaginacionFiltroOrden)Session["PaginacionFiltroOrden"];
            var NoRegsPorPagina = dgMaster.PageSize;
            
            var datos = _EntidadControl._0SelByAll(
                null, null, null, null, null, null, null,
                PaginaIndice, NoRegsPorPagina,
                filtros.OrdenarCampo, filtros.OrdenarSentido);
            
            // Calcula la página que el toca
            int noDatos = datos.Count();
            dgMaster.CurrentPageIndex = PaginaIndice;
            dgMaster.VirtualItemCount = noDatos < NoRegsPorPagina ? (PaginaIndice) * 10 + noDatos : (PaginaIndice + 2) * 10;
            
            // Coloa los datos en el grid
            dgMaster.DataSource = datos;
            dgMaster.DataBind();
            
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
            PaginacionFiltroOrden filtros = (PaginacionFiltroOrden)Session["PaginacionFiltroOrden"];
            if (filtros.OrdenarCampo == e.SortExpression)
                filtros.OrdenarSentido = filtros.OrdenarSentido == "ASC" ? "DES" : "ASC";
            else
            {
                filtros.OrdenarCampo = e.SortExpression;
                filtros.OrdenarSentido = "ASC";
            }
            Session["PaginacionFiltroOrden"] = filtros;
            // Consulta los datos
            ConsultaDatos(dgMaster.CurrentPageIndex);
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

        }

        protected void ddlFiltro_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}