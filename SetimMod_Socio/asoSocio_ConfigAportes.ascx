<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="asoSocio_ConfigAportes.ascx.cs" Inherits="SetimMod_Socio.asoSocio_ConfigAportes" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src= "~/controls/LabelControl.ascx" %>

<div id="dnnUsers" class="dnnForm dnnClear">
    <asp:Label ID="lbTitulo" runat="server" CssClass="dnnFormMessage dnnFormInfo" Text="Formulario para actualizar datos del socio." />
    <fieldset>
        <legend></legend>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbId" Text="Id:" HelpText="Identificador"/>
            <asp:TextBox runat="server" ID="tbId" Enabled="false"/>
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbNombre" runat="server" Text="Nombre:" HelpText="Este dato se lo modifica en el menú de Usuarios"/>
            <asp:TextBox runat="server" ID="tbNombre" Enabled="false"/>
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbEstado" runat="server" Text="Estado:"/>
            <asp:DropDownList runat="server" ID="ddlEstado">
                <asp:ListItem Text="Activo" Value="ACT" />
                <asp:ListItem Text="Inactivo" Value="INA"/>
            </asp:DropDownList>
        </div>
    </fieldset>
</div>

<ul class="dnnActions dnnClear">
    <li>
        <asp:LinkButton runat="server" ID="saveButton" 
            CssClass="dnnPrimaryAction"
            OnClick="Guardar"
            Text="Guardar"
            />
    </li>
    <li>
        <asp:LinkButton runat="server" ID="cancelButton"
            CssClass="dnnSecondaryAction"
            OnClick="Cancelar"
            Text="Cancelar" />
    </li>
</ul>