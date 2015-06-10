<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="asoSocio_Lista.ascx.cs" Inherits="SetimMod_Socio.asoSocio_Lista" %>

<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>

<ul class="dnnActions dnnClear">
    <li>
        <asp:HyperLink runat="server" ID="addButton"
            CssClass="dnnPrimaryAction"
            Text="Nuevo" />
    </li>
    <li>
        <asp:LinkButton runat="server" ID="btCopiarSocios"
            CssClass="dnnSecondaryAction"
            OnClick="btCopiarSocios_OnClick"
            Text="Copiar Socios" />
    </li>
<%--    <li>
        <asp:HyperLink runat="server" ID="btConfigAportes"
            CssClass="dnnSecondaryAction"
            Text="Configurar Aportes" />
    </li>--%>
</ul>

<asp:Panel runat="server" ID="pnFiltros" CssClass="dnnFormMessage" DefaultButton="btBuscar">
    <div class="dnnClear">
        <asp:Label runat="server" ID="lbFiltro_Criterio" Text="Criterio: "/>
        <asp:TextBox runat="server" ID="tbFiltro_Criterio" Text="" CssClass="TextBox_Setim" />
        <asp:DropDownList runat="server" ID="ddlFiltro_Campo" AutoPostBack="true" CssClass="DropDownList_Setim" OnSelectedIndexChanged="ddlFiltro_Campo_SelectedIndexChanged" />
        <asp:Button runat="server" ID="btBuscar" Text="Buscar" OnClick="btBuscar_Click"  />
    </div>
</asp:Panel>

<asp:Panel runat="server" ID="pnCabecera" CssClass="dnnFormMessage dnnFormSuccess">
    <asp:Label runat="server" ID="lbCab_Estado" Text="Estado: "/>
    <asp:DropDownList runat="server" ID="ddlCab_Estado" AutoPostBack="true" CssClass="DropDownList_Setim" OnSelectedIndexChanged="ddlFiltro_Estado_SelectedIndexChanged"/>
</asp:Panel>

<asp:DataGrid runat="server" ID="dgMaster" 
    CssClass="dnnGrid" AutoGenerateColumns="False" GridLines="None"
    DataKeyField="Id"
    ShowFooter="true"
    AllowPaging="True" AllowCustomPaging="True" 
    PagerStyle-NextPageText="Siguiente &gt;" PagerStyle-PrevPageText="&lt; Anterior" 
    
    AllowSorting="True"

    OnItemCommand ="dgMaster_OnItemCommand"
    OnSortCommand="dgMaster_SortCommand" OnItemCreated="dgMaster_ItemCreated" >

    <PagerStyle Mode="NextPrev" HorizontalAlign="Left" />

    <headerstyle cssclass="dnnGridHeader" verticalalign="Top"/>
    <itemstyle cssclass="dnnGridItem" horizontalalign="Left" />
    <alternatingitemstyle cssclass="dnnGridAltItem" />
    <edititemstyle cssclass="dnnFormInput" />
    <selecteditemstyle BackColor="#c6dbec"/>
    <footerstyle cssclass="dnnGridFooter" />

    <Columns>        
        <asp:BoundColumn DataField="Id"                 HeaderText="Id"                 HeaderStyle-Width="35px"    FooterText ="Página No: "   />
        <asp:BoundColumn DataField="UserID"             HeaderText="UserID"             HeaderStyle-Width="35px"    ItemStyle-HorizontalAlign="Center"  Visible="false"/>
        <asp:BoundColumn DataField="CI"                 HeaderText="CI"                 HeaderStyle-Width="80px"    SortExpression="CI"                 HeaderStyle-HorizontalAlign="Center" />
        <asp:BoundColumn DataField="Users_Nombre"       HeaderText="Nombre"             HeaderStyle-Width="120px"   SortExpression="Users_Nombre" />
        <asp:BoundColumn DataField="Users_EMail"        HeaderText="EMail"              HeaderStyle-Width="90px"   />
        <asp:BoundColumn DataField="Descripcion"        HeaderText="Descripcion"        HeaderStyle-Width="120px"   SortExpression="Descripcion" />
        <asp:BoundColumn DataField="Fecha_Nacimiento"   HeaderText="Fecha Nacimiento"   HeaderStyle-Width="100px"   SortExpression="Fecha_Nacimiento"   DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundColumn DataField="Estado"             HeaderText="Estado"             HeaderStyle-Width="50px"    SortExpression="Estado"             ItemStyle-HorizontalAlign="Center" />
        <asp:BoundColumn DataField="Valor_Accion"       HeaderText="Valor Accion"       HeaderStyle-Width="90px"   SortExpression="Valor_Accion"       DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />
        <asp:BoundColumn DataField="Valor_Ahorro"       HeaderText="Valor Ahorro"       HeaderStyle-Width="90px"   SortExpression="Valor_Ahorro"       DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />

      <%--  <asp:ButtonColumn Text="Sel" ButtonType="LinkButton" CommandName="Select" />--%>
        <asp:TemplateColumn>
            <FooterTemplate>
                No de Filas: 
                <asp:DropDownList ID="ddlNoFilasPorPagina" runat="server" CssClass="DropDownList_Setim" AutoPostBack="true" OnSelectedIndexChanged="ddlNoFilasPorPagina_SelectedIndexChanged" >
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="20">20</asp:ListItem>
                    <asp:ListItem Value="50">50</asp:ListItem>
                </asp:DropDownList>
            </FooterTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn>
            <HeaderStyle Width="50px" />
            <ItemTemplate>
                <asp:HyperLink runat="server" ID="Hyperlink1"
                    NavigateUrl='<%# ModuleContext.EditUrl("EntidadId", Eval("Id").ToString(), "Edit") %>'
                    Text="Editar"/>
            </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn>
            <HeaderStyle Width="50px" />
            <ItemTemplate>
                <asp:LinkButton runat="server" ID="LinkButton1"
                    class ="confirm"
                    CommandArgument='<%# Eval("Id") %>'
                    CommandName ="Borrar" 
                    Text="Borrar"/>
            </ItemTemplate>
        </asp:TemplateColumn>
    </Columns>
</asp:DataGrid>

<script type="text/javascript">
    jQuery(function ($) {
        $('.confirm').dnnConfirm({
            text: '¿Desea proceder con la operación?',
            yestext: 'Si',
            notext: 'No',
            title: 'Confirmación'
        });
    });
</script>

<script type="text/javascript">
    $(document).ready(function(){
        $('input[class=TextBox_Setim]').css({ 'margin': '0px', 'padding': '2px' });
        $('select[class=DropDownList_Setim]').css({ 'margin': '0px', 'padding': '2px' });
    })
</script>