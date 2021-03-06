﻿<%@ Control Language="C#" AutoEventWireup="True"
    CodeBehind="asoPeriodo_View.ascx.cs"
    Inherits="SetimMod_asoPeriodo.asoPeriodo_View" %>

<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>

<asp:Label runat="server" ID="lbTitulo" ForeColor="#3399FF" Font-Italic="true" Font-Bold="true"></asp:Label>

<br />
<ul class="dnnActions dnnClear">
    <li><asp:LinkButton runat="server" ID="btAccion" Text="Generar 6 Períodos" CssClass="dnnSecondaryAction confirm" OnClick="btAccion_OnClick" /></li>
    <li><asp:LinkButton runat="server" ID="lbMarcarPagados" Text="Marcar pagados" CssClass="dnnSecondaryAction confirm" OnClick="lbMarcarPagados_OnClick" /></li>
    <li><asp:LinkButton runat="server" ID="lbPeriodoActual" Text="Asignar período actual" CssClass="dnnSecondaryAction confirm" OnClick="lbPeriodoActual_OnClick" /></li>
    <li><asp:LinkButton runat="server" ID="lbCrearAportes" Text="Crear aportes" CssClass="dnnSecondaryAction confirm" OnClick="lbCrearAportes_OnClick" /></li>
    <li><asp:HyperLink runat="server" ID="hlAportes" CssClass="dnnPrimaryAction" Text="Aportes" /></li>
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
    <asp:Label runat="server" ID="lbCab_Estado" Text="Estado: " />
    <asp:DropDownList runat="server" ID="ddlCab_Estado" AutoPostBack="true" CssClass="DropDownList_Setim" OnSelectedIndexChanged="ddlFiltro_Estado_SelectedIndexChanged" />
</asp:Panel>

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
        <asp:BoundColumn DataField="Id" HeaderText="Id" HeaderStyle-Width="50px" SortExpression="Id" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundColumn DataField="No_Periodo" HeaderText="No_Periodo" HeaderStyle-Width="50px" SortExpression="No_Periodo" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundColumn DataField="Fecha_Periodo" HeaderText="Fecha_Periodo" HeaderStyle-Width="50px" SortExpression="Fecha_Periodo" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundColumn DataField="Estado" HeaderText="Estado" HeaderStyle-Width="50px" SortExpression="Estado" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Left" />
        <asp:BoundColumn DataField="Descripcion" HeaderText="Descripcion" HeaderStyle-Width="50px" SortExpression="Descripcion" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Left" />
        <asp:ButtonColumn Text="Sel" ButtonType="LinkButton" CommandName="Select" />
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
                    NavigateUrl='<%# ModuleContext.EditUrl("EntidadId", Eval("Id").ToString(), "Edit") %>'
                    Text="Editar" Enabled='<%# _Usuario_RolSetimEditar %>' />
            </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn>
            <HeaderStyle Width="50px" />
            <ItemTemplate>
                <asp:LinkButton runat="server" ID="LinkButton1"
                    class="confirm"
                    CommandArgument='<%# Eval("Id") %>'
                    CommandName="Borrar"
                    Text="Borrar" Enabled='<%# _Usuario_RolSetimEditar %>' />
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
