using System;
using System.Linq;
using System.Web.UI.WebControls;
using DotNetNuke.Collections;
using System.Collections.Generic;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.UI.Modules;
using DotNetNuke.UI.Skins;
using DotNetNuke.Common;
using SetimBasico;

namespace SetimMod_asoSetimListaDet
{
    public partial class asoSetimListaDet_View : ModuleUserControlBase
    {
        // Usuario
        private int _UserId;
        private int _ModuleId;
        public int? _EntidadPadreId;
        // Campo por defecto para ordenar la lista
        private string _Ordenar_Campo_Defaul = "Id";
        // Estado de la página
        private PaginaEstado paginaEstado
        {
            get
            {
                if (Session["paginaEstado"] == null) Session["paginaEstado"] = new PaginaEstado();
                return (PaginaEstado)Session["paginaEstado"];
            }
            set
            { Session["paginaEstado"] = value; }
        }
        // Entidad base
        private readonly asoSetimListaDetControl _EntidadControl = new asoSetimListaDetControl();
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
                //Obtiene el identificador de la llamada
                _EntidadPadreId = Request.QueryString.GetValueOrDefault("EntidadId", -1);
                // Inicializa el botón de edición usando el padre Id de la llamada
                addButton.NavigateUrl = ModuleContext.EditUrl("EntidadId", "", "DetEdit", "EntidadPadreId", _EntidadPadreId.ToString());
                // Verifica el estado de la página
                if (paginaEstado.ModuleID == _ModuleId)
                {
                    if (paginaEstado.Ordenar_Campo == "") paginaEstado.Ordenar_Campo = _Ordenar_Campo_Defaul;
                    dgMaster.PageSize = paginaEstado.NoFilasPorPagina;
                    if (paginaEstado.dgMasterItemIndex != -1) dgMaster.SelectedIndex = paginaEstado.dgMasterItemIndex;
                    // Si existe valor en la entidad padre, entonces la inicializa
                    if (_EntidadPadreId != -1)
                    {
                        paginaEstado.Filtro_Campo = "asoSetimLista_Id";
                        paginaEstado.Filtro_Valor = _EntidadPadreId;
                    }
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
                // Carga de datos
                ConsultaDatos();
            }
        }

        // Carga los campos para filtrar 
        private void CargarDdl_CamposDelFiltro()
        {
            asoSetimListaDetControl SetimLista = new asoSetimListaDetControl();
            var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoSetimListaDet_Filtro_Campos");
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
                //case "Select":
                //    paginaEstado.dgMasterItemIndex = e.Item.ItemIndex;
                //    string sEntidadId = e.Item.Cells[0].Text;
                //    entidadId = 1;
                //    btConfigAportes.NavigateUrl = ModuleContext.EditUrl("EntidadId", sEntidadId, "ConfigAportes");
                //    break;
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
        private IList<asoSetimListaDet> ConsultaSP()
        {
            IList<asoSetimListaDet> res = new List<asoSetimListaDet>();
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
            paginaEstado.Filtro_Valor = "%" + tbFiltro_Criterio.Text + "%";
            paginaEstado.PaginaActual = 0;
            ConsultaDatos();
        }

        protected void btBuscar_Click(object sender, EventArgs e)
        {
            ddlFiltro_Campo_SelectedIndexChanged(ddlFiltro_Campo, e);
        }

    }
}
