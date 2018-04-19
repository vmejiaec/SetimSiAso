<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="asoParametro_Edit.ascx.cs" Inherits="SetimMod_asoParametro.asoParametro_Edit" %>

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
    <asp:Label ID="lbTitulo" runat="server" CssClass="dnnFormMessage dnnFormInfo" Text="Formulario para actualizar los parámetros del sistema." />
    <fieldset>
        <legend></legend>
        <div class="dnnFormItem" style="visibility: hidden">
            <dnn:Label runat="server" ID="lbId" Text="Id:" HelpText="Id" />
            <asp:TextBox runat="server" ID="tbId" Enabled="false" />
            <asp:RequiredFieldValidator ID="rfv_tbId" runat="server" ControlToValidate="tbId" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Id" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbasoPeriodo_Id_Actual" Text="Periodo_Id_Actual:" HelpText="asoPeriodo_Id_Actual" />
            <asp:TextBox runat="server" ID="tbasoPeriodo_Id_Actual" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbasoPeriodo_Id_Actual" runat="server" ControlToValidate="tbasoPeriodo_Id_Actual" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoPeriodo_Id_Actual" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbasoPeriodo_Actual_Fecha_Periodo" Text="Periodo_Actual_Fecha:" HelpText="asoPeriodo_Actual_Fecha_Periodo" />
            <asp:TextBox runat="server" ID="tbasoPeriodo_Actual_Fecha_Periodo" />
            <asp:RequiredFieldValidator ID="rfv_tbasoPeriodo_Actual_Fecha_Periodo" runat="server" ControlToValidate="tbasoPeriodo_Actual_Fecha_Periodo" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoPeriodo_Actual_Fecha_Periodo" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbPorcentaje_Comision_Por_Defecto" runat="server" Text="Porcentaje_Comision_Por_Defecto:" HelpText="Porcentaje_Comision_Por_Defecto" />
            <asp:TextBox runat="server" ID="tbPorcentaje_Comision_Por_Defecto" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Porcentaje_Comision_Por_Defecto" runat="server" ControlToValidate="tbPorcentaje_Comision_Por_Defecto" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Porcentaje_Comision_Por_Defecto" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbValor_Reingreso" runat="server" Text="Valor_Reingreso:" HelpText="Valor_Reingreso" />
            <asp:TextBox runat="server" ID="tbValor_Reingreso" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Valor_Reingreso" runat="server" ControlToValidate="tbValor_Reingreso" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Valor_Reingreso" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbNo_Periodos_Reingreso" Text="No_Periodos_Reingreso:" HelpText="No_Periodos_Reingreso" />
            <asp:TextBox runat="server" ID="tbNo_Periodos_Reingreso" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbNo_Periodos_Reingreso" runat="server" ControlToValidate="tbNo_Periodos_Reingreso" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta No_Periodos_Reingreso" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbValor_Accion_Minimo" runat="server" Text="Valor_Accion_Minimo:" HelpText="Valor_Accion_Minimo" />
            <asp:TextBox runat="server" ID="tbValor_Accion_Minimo" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Valor_Accion_Minimo" runat="server" ControlToValidate="tbValor_Accion_Minimo" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Valor_Accion_Minimo" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbValor_Ahorro_Minimo" runat="server" Text="Valor_Ahorro_Minimo:" HelpText="Valor_Ahorro_Minimo" />
            <asp:TextBox runat="server" ID="tbValor_Ahorro_Minimo" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Valor_Ahorro_Minimo" runat="server" ControlToValidate="tbValor_Ahorro_Minimo" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Valor_Ahorro_Minimo" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbTasa_Interes_Por_Defecto" runat="server" Text="Tasa_Interes_Por_Defecto:" HelpText="Tasa_Interes_Por_Defecto" />
            <asp:TextBox runat="server" ID="tbTasa_Interes_Por_Defecto" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Tasa_Interes_Por_Defecto" runat="server" ControlToValidate="tbTasa_Interes_Por_Defecto" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Tasa_Interes_Por_Defecto" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbNombre_Largo_Asociacion" Text="Nombre_Largo_Asociacion:" HelpText="Nombre_Largo_Asociacion" />
            <asp:TextBox runat="server" ID="tbNombre_Largo_Asociacion" />
            <asp:RequiredFieldValidator ID="rfv_tbNombre_Largo_Asociacion" runat="server" ControlToValidate="tbNombre_Largo_Asociacion" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Nombre_Largo_Asociacion" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbNombre_Corto_Asociacion" Text="Nombre_Corto_Asociacion:" HelpText="Nombre_Corto_Asociacion" />
            <asp:TextBox runat="server" ID="tbNombre_Corto_Asociacion" />
            <asp:RequiredFieldValidator ID="rfv_tbNombre_Corto_Asociacion" runat="server" ControlToValidate="tbNombre_Corto_Asociacion" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Nombre_Corto_Asociacion" SetFocusOnError="true" />
        </div>
    </fieldset>
    <asp:ValidationSummary runat="server" ID="vsResumen" CssClass="dnnFormMessage dnnFormValidationSummary" />
</div>
<%--Botones --%>
<ul class="dnnActions dnnClear">
    <li>
        <asp:LinkButton runat="server" ID="saveButton" CssClass="dnnPrimaryAction" OnClick="Guardar" Text="Guardar" /></li>
    <li>
        <asp:LinkButton runat="server" ID="cancelButton" CssClass="dnnSecondaryAction" OnClick="Cancelar" Text="Cancelar" CausesValidation="false" /></li>
</ul>
