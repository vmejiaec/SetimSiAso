<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="asoPrestamoTmp_Edit.ascx.cs" Inherits="SetimMod_asoPrestamoTmp.asoPrestamoTmp_Edit" %>

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
    <asp:Label ID="lbTitulo" runat="server" CssClass="dnnFormMessage dnnFormInfo" Text="Formulario para actualizar datos." />
    <fieldset>
        <legend></legend>
        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbId" text="Id:" helptext="Id" />
            <asp:TextBox runat="server" ID="tbId" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbId" runat="server" ControlToValidate="tbId" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Id" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbCI" text="CI:" helptext="CI" />
            <asp:TextBox runat="server" ID="tbCI" />
            <asp:RequiredFieldValidator ID="rfv_tbCI" runat="server" ControlToValidate="tbCI" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta CI" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="lbValor_Prestamo" runat="server" text="Valor_Prestamo:" helptext="Valor_Prestamo" />
            <asp:TextBox runat="server" ID="tbValor_Prestamo" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Valor_Prestamo" runat="server" ControlToValidate="tbValor_Prestamo" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Valor_Prestamo" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbNo_Periodos" text="No_Periodos:" helptext="No_Periodos" />
            <asp:TextBox runat="server" ID="tbNo_Periodos" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbNo_Periodos" runat="server" ControlToValidate="tbNo_Periodos" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta No_Periodos" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbNo_Periodos_Faltantes" text="No_Periodos_Faltantes:" helptext="No_Periodos_Faltantes" />
            <asp:TextBox runat="server" ID="tbNo_Periodos_Faltantes" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbNo_Periodos_Faltantes" runat="server" ControlToValidate="tbNo_Periodos_Faltantes" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta No_Periodos_Faltantes" SetFocusOnError="true" />
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
