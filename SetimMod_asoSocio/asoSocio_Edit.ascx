<%@ Control Language="C#" AutoEventWireup="True"
    CodeBehind="asoSocio_Edit.ascx.cs"
    Inherits="SetimMod_asoSocio.asoSocio_Edit" %>

<%@ Register Assembly="DotNetNuke.WebControls" Namespace="DotNetNuke.UI.WebControls" TagPrefix="DNN" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<script src="/Resources/Shared/scripts/autoNumeric-2.0-BETA.js" type="text/javascript"></script>

<%--Funcion para poner el formato numérico a los campos de Valor--%>
<script type="text/javascript">
    jQuery(function ($) {
        $('input[class=TextBox_Setim_Valor]').autoNumeric('init', { aSep: '.', aDec: ',' });
    });
</script>

<div id="dnnUsers" class="dnnForm dnnClear">
    <asp:Label ID="lbTitulo" runat="server" CssClass="dnnFormMessage dnnFormInfo" Text="Formulario para actualizar datos." />
    <fieldset>
        <legend></legend>
        <div class="dnnFormItem" style="visibility: hidden">
            <dnn:Label runat="server" ID="lbId" Text="Id:" HelpText="Id" />
            <asp:TextBox runat="server" ID="tbId" Enabled="false" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbUserID" Text="UserID:" HelpText="UserID" />
            <asp:TextBox runat="server" ID="tbUserID" Enabled="false" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbCI" Text="CI:" HelpText="CI" />
            <asp:TextBox runat="server" ID="tbCI" />
            <asp:RequiredFieldValidator ID="rfv_tbCI" runat="server" ControlToValidate="tbCI" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta CI" SetFocusOnError="true" />
        </div>

        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbDescripcion" Text="Descripcion:" HelpText="Descripcion" />
            <asp:TextBox runat="server" ID="tbDescripcion" TextMode="MultiLine" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbFecha_Nacimiento" runat="server" CssClass="dnnFormLabel" AssociatedControlID="dnnDP_Fecha_Nacimiento" Text="Fecha_Nacimiento" />
            <dnn:DnnDatePicker runat="server" CssClass="dnnFormInput" ID="dnnDP_Fecha_Nacimiento" />
            <asp:RequiredFieldValidator ID="rfv_dnnDP_Fecha_Nacimiento" runat="server" ControlToValidate="dnnDP_Fecha_Nacimiento" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Fecha_Nacimiento" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbEstado" runat="server" Text="Estado:" />
            <asp:DropDownList runat="server" ID="ddlEstado">
                <asp:ListItem Text="Activo" Value="ACT" />
                <asp:ListItem Text="Inactivo" Value="INA" />
            </asp:DropDownList>
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbUsers_EMail" Text="EMail:" HelpText="EMail" />
            <asp:TextBox runat="server" ID="tbUsers_EMail" />
            <asp:RequiredFieldValidator ID="rfv_tbUsers_EMail" runat="server" ControlToValidate="tbUsers_EMail" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Users_EMail" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbUsers_Nombre" Text="Nombre:" HelpText="Nombre" />
            <asp:TextBox runat="server" ID="tbUsers_Nombre" />
            <asp:RequiredFieldValidator ID="rfv_tbUsers_Nombre" runat="server" ControlToValidate="tbUsers_Nombre" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Users_Nombre" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbValor_Accion" runat="server" Text="Valor_Accion:" HelpText="Valor_Accion" />
            <asp:TextBox runat="server" ID="tbValor_Accion" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Valor_Accion" runat="server" ControlToValidate="tbValor_Accion" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Valor_Accion" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbValor_Ahorro" runat="server" Text="Valor_Ahorro:" HelpText="Valor_Ahorro" />
            <asp:TextBox runat="server" ID="tbValor_Ahorro" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Valor_Ahorro" runat="server" ControlToValidate="tbValor_Ahorro" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Valor_Ahorro" SetFocusOnError="true" />
        </div>
    </fieldset>

    <asp:ValidationSummary runat="server" ID="vsResumen" CssClass="dnnFormMessage dnnFormValidationSummary" />

</div>

<ul class="dnnActions dnnClear">
    <li>
        <asp:LinkButton runat="server" ID="saveButton" CssClass="dnnPrimaryAction" OnClick="Guardar" Text="Guardar" /></li>
    <li>
        <asp:LinkButton runat="server" ID="cancelButton" CssClass="dnnSecondaryAction" OnClick="Cancelar" Text="Cancelar" />
    </li>
</ul>
