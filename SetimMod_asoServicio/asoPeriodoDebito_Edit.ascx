<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="asoPeriodoDebito_Edit.ascx.cs" Inherits="SetimMod_asoPeriodoDebito.asoPeriodoDebito_Edit" %>

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
            <dnn:Label runat="server" ID="lbasoPeriodo_Id" Text="asoPeriodo_Id:" HelpText="asoPeriodo_Id" />
            <asp:TextBox runat="server" ID="tbasoPeriodo_Id" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbasoPeriodo_Id" runat="server" ControlToValidate="tbasoPeriodo_Id" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoPeriodo_Id" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbasoPeriodo_Fecha" runat="server" CssClass="dnnFormLabel" AssociatedControlID="dnnDP_asoPeriodo_Fecha" Text="asoPeriodo_Fecha" />
            <dnn:DnnDatePicker runat="server" CssClass="dnnFormInput" ID="dnnDP_asoPeriodo_Fecha" />
            <asp:RequiredFieldValidator ID="rfv_dnnDP_asoPeriodo_Fecha" runat="server" ControlToValidate="dnnDP_asoPeriodo_Fecha" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoPeriodo_Fecha" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbasoServicio_Id" Text="asoServicio_Id:" HelpText="asoServicio_Id" />
            <asp:TextBox runat="server" ID="tbasoServicio_Id" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbasoServicio_Id" runat="server" ControlToValidate="tbasoServicio_Id" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoServicio_Id" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbasoSocio_Id" Text="asoSocio_Id:" HelpText="asoSocio_Id" />
            <asp:TextBox runat="server" ID="tbasoSocio_Id" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbasoSocio_Id" runat="server" ControlToValidate="tbasoSocio_Id" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoSocio_Id" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbValor" runat="server" Text="Valor:" HelpText="Valor" />
            <asp:TextBox runat="server" ID="tbValor" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Valor" runat="server" ControlToValidate="tbValor" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Valor" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbValor_Comision" runat="server" Text="Valor_Comision:" HelpText="Valor_Comision" />
            <asp:TextBox runat="server" ID="tbValor_Comision" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Valor_Comision" runat="server" ControlToValidate="tbValor_Comision" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Valor_Comision" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbEstado" runat="server" Text="Estado:" />
            <asp:DropDownList runat="server" ID="ddlEstado" />
        </div>

        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbDescripcion" Text="Descripcion:" HelpText="Descripcion" />
            <asp:TextBox runat="server" ID="tbDescripcion" TextMode="MultiLine" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbasoSocio_Nombre" Text="asoSocio_Nombre:" HelpText="asoSocio_Nombre" />
            <asp:TextBox runat="server" ID="tbasoSocio_Nombre" />
            <asp:RequiredFieldValidator ID="rfv_tbasoSocio_Nombre" runat="server" ControlToValidate="tbasoSocio_Nombre" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoSocio_Nombre" SetFocusOnError="true" />
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
