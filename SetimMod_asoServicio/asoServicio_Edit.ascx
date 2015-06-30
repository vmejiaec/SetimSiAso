<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="asoServicio_Edit.ascx.cs" Inherits="SetimMod_asoServicio.asoServicio_Edit" %>

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
            <asp:TextBox runat="server" ID="tbId" Enabled="false" />
            <asp:RequiredFieldValidator ID="rfv_tbId" runat="server" ControlToValidate="tbId" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Id" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbNombre" Text="Nombre:" HelpText="Nombre" />
            <asp:TextBox runat="server" ID="tbNombre" />
            <asp:RequiredFieldValidator ID="rfv_tbNombre" runat="server" ControlToValidate="tbNombre" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Nombre" SetFocusOnError="true" />
        </div>

        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbDescripcion" Text="Descripcion:" HelpText="Descripcion" />
            <asp:TextBox runat="server" ID="tbDescripcion" TextMode="MultiLine" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbPorcentaje_Comision" runat="server" Text="Porcentaje_Comision:" HelpText="Porcentaje_Comision" />
            <asp:TextBox runat="server" ID="tbPorcentaje_Comision" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Porcentaje_Comision" runat="server" ControlToValidate="tbPorcentaje_Comision" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Porcentaje_Comision" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbTipo" runat="server" Text="Tipo:" />
            <asp:DropDownList runat="server" ID="ddlTipo" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbValor" runat="server" Text="Valor:" HelpText="Valor" />
            <asp:TextBox runat="server" ID="tbValor" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Valor" runat="server" ControlToValidate="tbValor" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Valor" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbNo_Periodos" Text="No_Periodos:" HelpText="No_Periodos" />
            <asp:TextBox runat="server" ID="tbNo_Periodos" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbNo_Periodos" runat="server" ControlToValidate="tbNo_Periodos" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta No_Periodos" SetFocusOnError="true" />
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
