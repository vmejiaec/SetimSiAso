<%@ Control Language="C#" AutoEventWireup="True"
    CodeBehind="asoPeriodoDebito_View.ascx.cs"
    Inherits="SetimMod_asoPeriodoDebito.asoPeriodoDebito_View" %>

<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>

<ul class="dnnActions dnnClear">
    <li>
        <asp:HyperLink runat="server" ID="addButton" Text="Nuevo" CssClass="dnnPrimaryAction" /></li>
    <li>
        <asp:LinkButton runat="server" ID="btGenerarDebitos" Text="Generar Débitos" CssClass="dnnSecondaryAction confirm" OnClick="btGenerarDebitos_OnClick" /></li>
</ul>

<asp:Panel runat="server" ID="pnFiltros" CssClass="dnnFormMessage" DefaultButton="btBuscar">
    <div class="dnnClear">
        <asp:Label runat="server" ID="lbFiltro_Criterio" Text="Criterio: " />
        <asp:TextBox runat="server" ID="tbFiltro_Criterio" Text="" CssClass="TextBox_Setim" />
        <asp:DropDownList runat="server" ID="ddlFiltro_Campo" AutoPostBack="true" CssClass="DropDownList_Setim" OnSelectedIndexChanged="ddlFiltro_Campo_SelectedIndexChanged" />
        <asp:Button runat="server" ID="btBuscar" Text="Buscar" OnClick="btBuscar_Click" />
    </div>
</asp:Panel>

<asp:Panel runat="server" ID="pnCabecera" CssClass="dnnFormMessage dnnFormSuccess">
    <asp:Label runat="server" ID="lbCab_Periodo" Text="Periodo: " />
    <asp:DropDownList runat="server" ID="ddlCab_Periodo" AutoPostBack="true" CssClass="DropDownList_Setim" OnSelectedIndexChanged="ddlFiltro_Periodo_SelectedIndexChanged" />
    <asp:Label runat="server" ID="lbCab_Estado" Text="Estado: " />
    <asp:DropDownList runat="server" ID="ddlCab_Estado" AutoPostBack="true" CssClass="DropDownList_Setim" OnSelectedIndexChanged="ddlFiltro_Estado_SelectedIndexChanged" />
</asp:Panel>

<asp:Label runat="server" ID="lbAvisos" ForeColor="#3399FF" Font-Italic="true" Font-Bold="true"></asp:Label>

<asp:DataGrid runat="server" ID="dgMaster"
    CssClass="dnnGrid" AutoGenerateColumns="False" GridLines="None"
    DataKeyField="Id"
    ShowFooter="true"
    AllowPaging="True" AllowCustomPaging="True" AllowSorting="True"
    PagerStyle-NextPageText="Siguiente &gt;" PagerStyle-PrevPageText="&lt; Anterior"
    OnItemCommand="dgMaster_OnItemCommand"
    OnSortCommand="dgMaster_SortCommand"
    OnItemCreated="dgMaster_ItemCreated">

    <PagerStyle Mode="NextPrev" HorizontalAlign="Left" />
    <HeaderStyle CssClass="dnnGridHeader" VerticalAlign="Top" />
    <ItemStyle CssClass="dnnGridItem" HorizontalAlign="Left" />
    <AlternatingItemStyle CssClass="dnnGridAltItem" />
    <EditItemStyle CssClass="dnnFormInput" />
    <SelectedItemStyle BackColor="#c6dbec" />
    <FooterStyle CssClass="dnnGridFooter" />

    <Columns>
        <asp:BoundColumn DataField="Id"                 HeaderText="Id" HeaderStyle-Width="50px" SortExpression="Id" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundColumn DataField="asoServicio_Id"     HeaderText="Servicio_Id" HeaderStyle-Width="50px" SortExpression="asoServicio_Id" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Right" Visible="false" />
        <asp:BoundColumn DataField="asoPeriodo_Id"      HeaderText="Periodo Id" HeaderStyle-Width="50px" SortExpression="asoPeriodo_Id" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundColumn DataField="asoPeriodo_Fecha"   HeaderText="Fecha" HeaderStyle-Width="50px" SortExpression="asoPeriodo_Fecha" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundColumn DataField="asoSocio_Id"        HeaderText="Socio Id" HeaderStyle-Width="50px" SortExpression="asoSocio_Id" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundColumn DataField="asoSocio_Nombre"    HeaderText="Socio Nombre" HeaderStyle-Width="50px" SortExpression="asoSocio_Nombre" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Left" />
        <asp:BoundColumn DataField="Valor"              HeaderText="Valor" HeaderStyle-Width="50px" SortExpression="Valor" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundColumn DataField="Valor_Comision"     HeaderText="Valor Comision" HeaderStyle-Width="50px" SortExpression="Valor_Comision" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundColumn DataField="Estado"             HeaderText="Estado" HeaderStyle-Width="50px" SortExpression="Estado" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundColumn DataField="Descripcion"        HeaderText="Descripcion" HeaderStyle-Width="50px" SortExpression="Descripcion" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Left" />

        <%--  <asp:ButtonColumn Text="Sel" ButtonType="LinkButton" CommandName="Select" />--%>
        <asp:TemplateColumn>
            <FooterTemplate>
                No de Filas: 
                <asp:DropDownList ID="ddlNoFilasPorPagina" runat="server" CssClass="DropDownList_Setim" AutoPostBack="true" OnSelectedIndexChanged="ddlNoFilasPorPagina_SelectedIndexChanged">
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
                    NavigateUrl='<%# ModuleContext.EditUrl("EntidadId", Eval("Id").ToString(), "Det_EditDebito") %>'
                    Text="Editar" />
            </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn>
            <HeaderStyle Width="50px" />
            <ItemTemplate>
                <asp:LinkButton runat="server" ID="LinkButton1"
                    class="confirm"
                    CommandArgument='<%# Eval("Id") %>'
                    CommandName="Borrar"
                    Text="Borrar" />
            </ItemTemplate>
        </asp:TemplateColumn>
    </Columns>
</asp:DataGrid>

<script type="text/javascript">
    jQuery(function ($) {
        try {
            $('.confirm').dnnConfirm({
                text: '¿Desea proceder con la operación?',
                yestext: 'Si',
                notext: 'No',
                title: 'Confirmación'
            });
        }
        catch (e)
        { }
    });
</script>

<script type="text/javascript">
    $(document).ready(function () {
        $('input[class=TextBox_Setim]').css({ 'margin': '0px', 'padding': '2px' });
        $('select[class=DropDownList_Setim]').css({ 'margin': '0px', 'padding': '2px' });
    })
</script>
