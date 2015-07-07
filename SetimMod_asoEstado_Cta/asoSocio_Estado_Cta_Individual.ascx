<%@ Control Language="C#" AutoEventWireup="True" 
    CodeBehind="asoSocio_Estado_Cta_Individual.ascx.cs" 
    Inherits="SetimMod_asoSocio.asoSocio_Estado_Cta_Individual" %>

<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>

<asp:Panel runat="server" ID="pnFiltros" CssClass="dnnFormMessage" >
    <div class="dnnClear">
        <asp:Label runat="server" ID="lbFiltro_Criterio" Text="Período: " />
        <asp:DropDownList runat="server" ID="ddlFiltro_Campo" AutoPostBack="true" CssClass="DropDownList_Setim" OnSelectedIndexChanged="ddlFiltro_Campo_SelectedIndexChanged" />
    </div>
</asp:Panel>

<div class="dnnFormMessage dnnFormSuccess">APORTES</div>

<asp:DataGrid runat="server" ID="dgMasterAportes"
    CssClass="dnnGrid" AutoGenerateColumns="False" GridLines="None"
    DataKeyField="Id"
    ShowFooter="true"
    AllowSorting="True" >

    <PagerStyle Mode="NextPrev" HorizontalAlign="Left" />
    <HeaderStyle CssClass="dnnGridHeader" VerticalAlign="Top" />
    <ItemStyle CssClass="dnnGridItem" HorizontalAlign="Left" />
    <AlternatingItemStyle CssClass="dnnGridAltItem" />
    <EditItemStyle CssClass="dnnFormInput" />
    <SelectedItemStyle BackColor="#c6dbec" />
    <FooterStyle CssClass="dnnGridFooter" />

    <Columns>
        <asp:BoundColumn DataField="Id"                     HeaderText="Id"               HeaderStyle-Width="20px" SortExpression="Id"               HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundColumn DataField="Tipo"                   HeaderText="Tipo"             HeaderStyle-Width="20px" SortExpression="Tipo"             HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundColumn DataField="Valor_Accion"           HeaderText="Valor Accion"     HeaderStyle-Width="50px" SortExpression="Valor_Accion"     HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundColumn DataField="Valor_Saldo_Accion"     HeaderText="Saldo Accion"     HeaderStyle-Width="50px"                                   HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundColumn DataField="Valor_Ahorro"           HeaderText="Valor Ahorro"     HeaderStyle-Width="50px" SortExpression="Valor_Ahorro"     HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundColumn DataField="Valor_Saldo_Ahorro"     HeaderText="Saldo Ahorro"     HeaderStyle-Width="50px"                                   HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundColumn DataField="Valor_Voluntario"       HeaderText="Valor Voluntario" HeaderStyle-Width="50px" SortExpression="Valor_Voluntario" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundColumn DataField="Valor_Saldo_Voluntario" HeaderText="Saldo Voluntario" HeaderStyle-Width="50px"                                   HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />
        
        <asp:BoundColumn DataField="Valor_Suma"             HeaderText="Aporte Total"     HeaderStyle-Width="50px" SortExpression="Valor_Suma" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />
        
        <%--  <asp:ButtonColumn Text="Sel" ButtonType="LinkButton" CommandName="Select" />--%>

    </Columns>
</asp:DataGrid>

<div class="dnnFormMessage dnnFormSuccess">PRESTAMOS</div>

<asp:DataGrid runat="server" ID="dgMasterCuotas"
    CssClass="dnnGrid" AutoGenerateColumns="False" GridLines="None"
    DataKeyField="Id"
    ShowFooter="true"
    AllowSorting="True">

    <PagerStyle Mode="NextPrev" HorizontalAlign="Left" />
    <HeaderStyle CssClass="dnnGridHeader" VerticalAlign="Top" />
    <ItemStyle CssClass="dnnGridItem" HorizontalAlign="Left" />
    <AlternatingItemStyle CssClass="dnnGridAltItem" />
    <EditItemStyle CssClass="dnnFormInput" />
    <SelectedItemStyle BackColor="#c6dbec" />
    <FooterStyle CssClass="dnnGridFooter" />

    <Columns>
        <asp:BoundColumn DataField="Id"                 HeaderText="Id"             HeaderStyle-Width="20px" SortExpression="Id" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundColumn DataField="asoPrestamo_Id"     HeaderText="Prestamo Id"    HeaderStyle-Width="20px" SortExpression="asoPrestamo_Id" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundColumn DataField="Valor_Capital"      HeaderText="Valor Capital"  HeaderStyle-Width="50px" SortExpression="Valor_Capital" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundColumn DataField="Valor_Interes"      HeaderText="Valor Interés"  HeaderStyle-Width="50px" SortExpression="Valor_Interes" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundColumn DataField="Valor_Suma"         HeaderText="Total"          HeaderStyle-Width="50px" SortExpression="Valor_Suma" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundColumn DataField="Desc_Cuotas"        HeaderText="Cuota"          HeaderStyle-Width="20px" SortExpression="Desc_Cuotas" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Center" />
        <%--  <asp:ButtonColumn Text="Sel" ButtonType="LinkButton" CommandName="Select" />--%>
    </Columns>
</asp:DataGrid>

<div class="dnnFormMessage dnnFormSuccess">DÉBITOS</div>

<asp:DataGrid runat="server" ID="dgMasterDebito"
    CssClass="dnnGrid" AutoGenerateColumns="False" GridLines="None"
    DataKeyField="Id"
    ShowFooter="true"
    AllowSorting="True">

    <PagerStyle Mode="NextPrev" HorizontalAlign="Left" />
    <HeaderStyle CssClass="dnnGridHeader" VerticalAlign="Top" />
    <ItemStyle CssClass="dnnGridItem" HorizontalAlign="Left" />
    <AlternatingItemStyle CssClass="dnnGridAltItem" />
    <EditItemStyle CssClass="dnnFormInput" />
    <SelectedItemStyle BackColor="#c6dbec" />
    <FooterStyle CssClass="dnnGridFooter" />

    <Columns>
        <asp:BoundColumn DataField="Id"                 HeaderText="Id"                 HeaderStyle-Width="20px" SortExpression="Id" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundColumn DataField="asoServicio_Id"     HeaderText="Servicio Id"        HeaderStyle-Width="20px" SortExpression="asoServicio_Id" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundColumn DataField="asoServicio_Nombre" HeaderText="Servicio Nombre"    HeaderStyle-Width="50px" SortExpression="asoServicio_Nombre" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Left" />
        <asp:BoundColumn DataField="Valor"              HeaderText="Valor"              HeaderStyle-Width="50px" SortExpression="Valor" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundColumn DataField="Valor_Comision"     HeaderText="Valor Comision"     HeaderStyle-Width="50px" SortExpression="Valor_Comision" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundColumn DataField="Valor_Mas_Comision" HeaderText="Débito Total"       HeaderStyle-Width="50px" SortExpression="Valor_Mas_Comision" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundColumn DataField="Desc_Coutas"        HeaderText="Cuota"              HeaderStyle-Width="20px" SortExpression="Desc_Cuotas" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0}" ItemStyle-HorizontalAlign="Center" />
        <%--  <asp:ButtonColumn Text="Sel" ButtonType="LinkButton" CommandName="Select" />--%>
    </Columns>
</asp:DataGrid>

<script type="text/javascript">
    $(document).ready(function () {
        $('input[class=TextBox_Setim]').css({ 'margin': '0px', 'padding': '2px' });
        $('select[class=DropDownList_Setim]').css({ 'margin': '0px', 'padding': '2px' });
    })
</script>