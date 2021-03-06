﻿<%@ Control Language="C#" AutoEventWireup="True"
    CodeBehind="asoPrestamo_Socio_View.ascx.cs"
    Inherits="SetimMod_asoPrestamo.asoPrestamo_Socio_View" %>

<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>

<ul class="dnnActions dnnClear">
    <li><asp:HyperLink runat="server" ID="addButton" Text="Crear Solicitud" CssClass="dnnPrimaryAction" /></li>
    <li><asp:HyperLink runat="server" ID="hlReporteSolicitudPrestamo" Text="Solicitud" CssClass="dnnSecondaryAction" /></li>
    <li><asp:HyperLink runat="server" ID="hlTablaAmortizacion" Text="Tabla de Amortización" CssClass="dnnSecondaryAction" /></li>
</ul>

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
        <asp:BoundColumn DataField="Id"                     HeaderText="Id"             HeaderStyle-Width="50px" SortExpression="Id" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundColumn DataField="Valor"                  HeaderText="Valor"          HeaderStyle-Width="50px" SortExpression="Valor" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundColumn DataField="Tasa_Interes"           HeaderText="Tasa Interes"   HeaderStyle-Width="50px" SortExpression="Tasa_Interes" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundColumn DataField="No_Periodos"            HeaderText="No Periodos"    HeaderStyle-Width="50px" SortExpression="No_Periodos" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundColumn DataField="Fecha_Solicitud"        HeaderText="Fecha Solicitud" HeaderStyle-Width="50px" SortExpression="Fecha_Solicitud" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundColumn DataField="Estado"                 HeaderText="Estado"         HeaderStyle-Width="50px" SortExpression="Estado" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundColumn DataField="Descripcion"            HeaderText="Descripcion"    HeaderStyle-Width="50px" SortExpression="Descripcion" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Left" />
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
