<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="asoPrestamo_PreCancelar.ascx.cs" Inherits="SetimMod_asoPrestamo.asoPrestamo_PreCancelar" %>

<%@ Register Assembly="DotNetNuke.WebControls" Namespace="DotNetNuke.UI.WebControls" TagPrefix="DNN" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<%--Funcion para poner el formato numérico a los campos de Valor--%>
<script src="http://asoimpq.org/dnn/Resources/Shared/scripts/autoNumeric-2.0-Beta.js" type="text/javascript"></script>
<script type="text/javascript">
    jQuery(function ($) {
        $('input[class=TextBox_Setim_Valor]').autoNumeric('init', { aSep: '.', aDec: ',' });
    });
</script>

<%--Formulario de datos --%>
<div id="dnnUsers" class="dnnForm dnnClear">
    <asp:Label ID="lbTitulo" runat="server" CssClass="dnnFormMessage dnnFormInfo" Text="Pre cancelación del Prestamo." />
    <fieldset>
        <legend></legend>
        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbTasaInteres" text="Tasa de interés:" helptext="Tasa de interés" />
            <asp:TextBox runat="server" ID="tbTasaInteres" Enabled="false" CssClass="TextBox_Setim_Valor" />
        </div>
        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbCapital" text="Capital:" helptext="Capital" />
            <asp:TextBox runat="server" ID="tbCapital" Enabled="false" CssClass="TextBox_Setim_Valor" />
        </div>
        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbInteres" text="Interés:" helptext="Interés" />
            <asp:TextBox runat="server" ID="tbInteres" Enabled="false" CssClass="TextBox_Setim_Valor" />
        </div>
        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbCapitalMasInteres" text="Capital Mas Interes:" helptext="Capital Mas Interes" />
            <asp:TextBox runat="server" ID="tbCapitalMasInteres" Enabled="false" CssClass="TextBox_Setim_Valor"  />
        </div>
        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbPeriodosQueFaltan" text="Períodos que faltan:" helptext="Períodos que faltan" />
            <asp:TextBox runat="server" ID="tbPeriodosQueFaltan" Enabled="false"  />
        </div>
        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbAbono" text="Abono:" helptext="Abono" />
            <asp:TextBox runat="server" ID="tbAbono" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Abono" runat="server" ControlToValidate="tbAbono" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Abono" SetFocusOnError="true" />
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
