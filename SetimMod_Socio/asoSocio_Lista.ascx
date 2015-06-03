<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="asoSocio_Lista.ascx.cs" Inherits="SetimMod_Socio.asoSocio_Lista" %>

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
</ul>

<asp:DataGrid runat="server" ID="dgMaster" 
    CssClass="dnnGrid" AutoGenerateColumns="False" GridLines="None"
    
    AllowPaging="True" AllowCustomPaging="True" 
    PagerStyle-NextPageText="Siguiente &gt;" PagerStyle-PrevPageText="&lt; Anterior" 
    
    AllowSorting="True"

    OnItemCommand ="dgMaster_OnItemCommand"
    OnSortCommand="dgMaster_SortCommand">

    <PagerStyle Mode="NextPrev" HorizontalAlign="Left" />
    <headerstyle cssclass="dnnGridHeader" verticalalign="Top"/>
    <itemstyle cssclass="dnnGridItem" horizontalalign="Left" />

    <Columns>
        <asp:BoundColumn DataField="Id"                 HeaderText="Id"                 HeaderStyle-Width="50px"    />
        <asp:BoundColumn DataField="UserID"             HeaderText="UserID"             HeaderStyle-Width="50px"    ItemStyle-HorizontalAlign="Center"  Visible="false"/>
        <asp:BoundColumn DataField="CI"                 HeaderText="CI"                 HeaderStyle-Width="80px"    HeaderStyle-HorizontalAlign="Center"/>
        <asp:BoundColumn DataField="Users_Nombre"       HeaderText="Nombre"             HeaderStyle-Width="150px"   SortExpression="Users_Nombre" />
        <asp:BoundColumn DataField="Users_EMail"        HeaderText="EMail"              HeaderStyle-Width="100px"   SortExpression="EMail" />
        <asp:BoundColumn DataField="Descripcion"        HeaderText="Descripcion"        HeaderStyle-Width="150px"   SortExpression="Descripcion" />
        <asp:BoundColumn DataField="Fecha_Nacimiento"   HeaderText="Fecha_Nacimiento"   HeaderStyle-Width="100px"   SortExpression="Fecha_Nacimiento" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center"/>
        <asp:BoundColumn DataField="Estado"             HeaderText="Estado"             HeaderStyle-Width="50px"    SortExpression="Estado" ItemStyle-HorizontalAlign="Center"/>
        <asp:TemplateColumn>
            <HeaderStyle Width="50px" />
            <ItemTemplate>
                <asp:HyperLink runat="server" ID="Hyperlink1"
                    NavigateUrl='<%# ModuleContext.EditUrl("EntidadId", Eval("Id").ToString(), "Edit", "paginaIndex", dgMaster.CurrentPageIndex.ToString()) %>'
                    Text="Editar"
                />
            </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn>
            <HeaderStyle Width="50px" />
            <ItemTemplate>
                <asp:LinkButton runat="server" ID="LinkButton1"
                    class ="confirm"
                    CommandArgument='<%# Eval("Id") %>'
                    CommandName ="Borrar" 
                    Text="Borrar"
                />
            </ItemTemplate>
        </asp:TemplateColumn>
    </Columns>
</asp:DataGrid>

<div><i>Página No: <%=dgMaster.CurrentPageIndex+1%>.</i></div>

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