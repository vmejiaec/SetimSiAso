<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="asoSocio_Edit.ascx.cs" Inherits="SetimMod_Socio.asoSocio_Edit" %>
<%@ Register Assembly="DotNetNuke.WebControls" Namespace="DotNetNuke.UI.WebControls" TagPrefix="DNN" %>

<%@ Register TagPrefix="dnn" TagName="Label" Src= "~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div id="dnnUsers" class="dnnForm dnnClear">
    <asp:Label ID="lbTitulo" runat="server" CssClass="dnnFormMessage dnnFormInfo" Text="Formulario para actualizar datos del socio." />
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbId" Text="Id:" HelpText="Identificador"/>
            <asp:TextBox runat="server" ID="tbId" Enabled="false"/>
        </div>
        <div class="dnnFormItem" style="display:none;">
            <dnn:Label ID="lbUserId" runat="server" Text="UserId:"/>
            <asp:TextBox runat="server" ID="tbUserId" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbNombre" runat="server" Text="Nombre:" HelpText="Este dato se lo modifica en el menú de Usuarios"/>
            <asp:TextBox runat="server" ID="tbNombre" Enabled="false"/>
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbCI" runat="server" Text="CI:" HelpText="Cédula de identidad del Socio"/>
            <asp:TextBox runat="server" ID="tbCI" />
            <asp:RequiredFieldValidator ID="rfv_tbCI" runat="server" ControlToValidate="tbCI" CssClass="dnnFormMessage dnnFormError" Text="Requerido" />
        </div>
        <div class="dnnFormItem" >
            <dnn:Label ID="lbEMail" runat="server" Text="Correo Electrónico:" HelpText="Este dato se lo modifica en el menú de Usuarios"/>
            <asp:TextBox runat="server" ID="tbEMail"  Enabled ="false"/>
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbDescripcion" runat="server" Text="Descripcion:"/>
            <asp:TextBox runat="server" ID="tbDescripcion" TextMode="MultiLine"/>
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbFecha_Nacimiento" runat="server" CssClass="dnnFormLabel" AssociatedControlID="dnnDP_Fecha_Nacimiento" Text="Fecha_Nacimiento" />
            <dnn:DnnDatePicker runat="server" CssClass="dnnFormInput" ID="dnnDP_Fecha_Nacimiento" />
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