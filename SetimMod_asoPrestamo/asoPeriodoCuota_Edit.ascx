<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="asoPeriodoCuota_Edit.ascx.cs" Inherits="SetimMod_asoPeriodoCuota.asoPeriodoCuota_Edit" %>

<%@ Register Assembly="DotNetNuke.WebControls" Namespace="DotNetNuke.UI.WebControls" TagPrefix="DNN" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<%--Funcion para poner el formato numérico a los campos de Valor--%>
<%--<script src="http://asoimpq.org/dnn/Resources/Shared/scripts/autoNumeric-2.0-Beta.js" type="text/javascript"></script>--%>
<script src="http://asoimpq.org/Resources/Shared/scripts/autoNumeric-2.0-Beta.js" type="text/javascript"></script>

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
            <dnn:label runat="server" id="lbId" text="Id:" helptext="Id" />
            <asp:TextBox runat="server" ID="tbId" Enabled="false" />
            <asp:RequiredFieldValidator ID="rfv_tbId" runat="server" ControlToValidate="tbId" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Id" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbasoPeriodo_Id" text="asoPeriodo_Id:" helptext="asoPeriodo_Id" />
            <asp:TextBox runat="server" ID="tbasoPeriodo_Id" Enabled="false" />
            <asp:RequiredFieldValidator ID="rfv_tbasoPeriodo_Id" runat="server" ControlToValidate="tbasoPeriodo_Id" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoPeriodo_Id" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbasoPrestamo_Id" text="asoPrestamo_Id:" helptext="asoPrestamo_Id" />
            <asp:TextBox runat="server" ID="tbasoPrestamo_Id" Enabled="false" />
            <asp:RequiredFieldValidator ID="rfv_tbasoPrestamo_Id" runat="server" ControlToValidate="tbasoPrestamo_Id" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoPrestamo_Id" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="lbValor_Capital" runat="server" text="Valor_Capital:" helptext="Valor_Capital" />
            <asp:TextBox runat="server" ID="tbValor_Capital" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Valor_Capital" runat="server" ControlToValidate="tbValor_Capital" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Valor_Capital" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="lbValor_Interes" runat="server" text="Valor_Interes:" helptext="Valor_Interes" />
            <asp:TextBox runat="server" ID="tbValor_Interes" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Valor_Interes" runat="server" ControlToValidate="tbValor_Interes" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Valor_Interes" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="lbEstado" runat="server" text="Estado:" />
            <asp:DropDownList runat="server" ID="ddlEstado" />
        </div>

        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbDescripcion" text="Descripcion:" helptext="Descripcion" />
            <asp:TextBox runat="server" ID="tbDescripcion" TextMode="MultiLine" />
        </div>
        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbasoSocio_Nombre" text="asoSocio_Nombre:" helptext="asoSocio_Nombre" />
            <asp:TextBox runat="server" ID="tbasoSocio_Nombre" />
            <asp:RequiredFieldValidator ID="rfv_tbasoSocio_Nombre" runat="server" ControlToValidate="tbasoSocio_Nombre" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoSocio_Nombre" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="lbasoPeriodo_Fecha" runat="server" cssclass="dnnFormLabel" associatedcontrolid="dnnDP_asoPeriodo_Fecha" text="asoPeriodo_Fecha" />
            <dnn:dnndatepicker runat="server" cssclass="dnnFormInput" id="dnnDP_asoPeriodo_Fecha" />
            <asp:RequiredFieldValidator ID="rfv_dnnDP_asoPeriodo_Fecha" runat="server" ControlToValidate="dnnDP_asoPeriodo_Fecha" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoPeriodo_Fecha" SetFocusOnError="true" />
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
