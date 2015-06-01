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

<asp:DataGrid runat="server" ID="tasks"
    AutoGenerateColumns="false"
    GridLines="None"
    OnItemCommand ="DeleteTask"
    >
    <HeaderStyle CssClass="taskListHeader" />
    <ItemStyle CssClass="taskListRow" />
    <AlternatingItemStyle CssClass="gridEstiloAlternante" />
    <Columns>
        <asp:BoundColumn DataField="Id" HeaderStyle-Width="50px" HeaderText="Id"/>
        <asp:BoundColumn DataField="UserID" HeaderStyle-Width="50px" HeaderText="UserID"/>
        <asp:BoundColumn DataField="CI" HeaderStyle-Width="80px" HeaderText="CI"/>
        <asp:BoundColumn DataField="Descripcion" HeaderStyle-Width="250px" HeaderText="Descripcion"/>
        <asp:BoundColumn DataField="Fecha_Nacimiento" HeaderStyle-Width="140px" HeaderText="Fecha_Nacimiento" DataFormatString="{0:d}"/>
        <asp:BoundColumn DataField="Estado" HeaderStyle-Width="50px" HeaderText="Estado"/>

        <asp:TemplateColumn>
            <HeaderStyle Width="50px" />
            <ItemTemplate>
                <asp:HyperLink runat="server" ID="Hyperlink1"
                    NavigateUrl='<%# ModuleContext.EditUrl("EntidadId", Eval("Id").ToString(), "Edit") %>'
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
                    CommandName ="Delete" 
                    Text="Borrar"
                />
            </ItemTemplate>
        </asp:TemplateColumn>

    </Columns>
</asp:DataGrid>

<div><asp:Label runat="server" ID="msj" Text=">:"></asp:Label></div>

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