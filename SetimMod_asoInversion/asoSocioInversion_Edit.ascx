<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="asoSocioInversion_Edit.ascx.cs" Inherits="SetimMod_asoSocioInversion.asoSocioInversion_Edit" %>

<%@ Register Assembly="DotNetNuke.WebControls" Namespace="DotNetNuke.UI.WebControls" TagPrefix="DNN" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<%--Funcion para poner el formato numérico a los campos de Valor--%>
<script src="/Resources/Shared/scripts/autoNumeric-2.0-BETA.js" type="text/javascript"></script>
<script type="text/javascript">
    jQuery(function ($) {
        $('input[class=TextBox_Setim_Valor]').autoNumeric('init', { aSep: '.', aDec: ',' });
    });
</script>
<%--Formulario de datos --%>
<div id="dnnUsers" class="dnnForm dnnClear">
    <asp:Label ID="lbTitulo" runat="server" CssClass="dnnFormMessage dnnFormInfo" Text="Formulario para actualizar datos." />
    <fieldset>
        <legend></legend>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbId" Text="Id:" HelpText="Id" />
            <asp:TextBox runat="server" ID="tbId" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbId" runat="server" ControlToValidate="tbId" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Id" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbasoSocio_Id" Text="asoSocio_Id:" HelpText="asoSocio_Id" />
            <asp:TextBox runat="server" ID="tbasoSocio_Id" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbasoSocio_Id" runat="server" ControlToValidate="tbasoSocio_Id" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoSocio_Id" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbasoInversion_Id" Text="asoInversion_Id:" HelpText="asoInversion_Id" />
            <asp:TextBox runat="server" ID="tbasoInversion_Id" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbasoInversion_Id" runat="server" ControlToValidate="tbasoInversion_Id" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoInversion_Id" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbasoSocio_Nombre" Text="asoSocio_Nombre:" HelpText="asoSocio_Nombre" />
            <asp:TextBox runat="server" ID="tbasoSocio_Nombre" />
            <asp:RequiredFieldValidator ID="rfv_tbasoSocio_Nombre" runat="server" ControlToValidate="tbasoSocio_Nombre" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoSocio_Nombre" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbNo_Socios_Regs" Text="No_Socios_Regs:" HelpText="No_Socios_Regs" />
            <asp:TextBox runat="server" ID="tbNo_Socios_Regs" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbNo_Socios_Regs" runat="server" ControlToValidate="tbNo_Socios_Regs" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta No_Socios_Regs" SetFocusOnError="true" />
        </div>
    </fieldset>
    <asp:ValidationSummary runat="server" ID="vsResumen" CssClass="dnnFormMessage dnnFormValidationSummary" />
</div>
<%--Botones --%>
<ul class="dnnActions dnnClear">
    <li>
        <asp:LinkButton runat="server" ID="saveButton" CssClass="dnnPrimaryAction" OnClick="Guardar" Text="Guardar" /></li>
    <li>
        <asp:LinkButton runat="server" ID="cancelButton" CssClass="dnnSecondaryAction" OnClick="Cancelar" Text="Cancelar" CausesValidation="false" />
    </li>
</ul>
