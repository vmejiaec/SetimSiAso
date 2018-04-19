<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="asoSetimListaDet_Edit.ascx.cs" Inherits="SetimMod_asoSetimListaDet.asoSetimListaDet_Edit" %>

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
            <dnn:Label runat="server" ID="lbId" Text="Id:" HelpText="Id" />
            <asp:TextBox runat="server" ID="tbId" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbId" runat="server" ControlToValidate="tbId" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Id" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbasoSetimLista_Id" Text="asoSetimLista_Id:" HelpText="asoSetimLista_Id" />
            <asp:TextBox runat="server" ID="tbasoSetimLista_Id" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbasoSetimLista_Id" runat="server" ControlToValidate="tbasoSetimLista_Id" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoSetimLista_Id" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbOrden" Text="Orden:" HelpText="Orden" />
            <asp:TextBox runat="server" ID="tbOrden" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbOrden" runat="server" ControlToValidate="tbOrden" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Orden" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbTexto" Text="Texto:" HelpText="Texto" />
            <asp:TextBox runat="server" ID="tbTexto" />
            <asp:RequiredFieldValidator ID="rfv_tbTexto" runat="server" ControlToValidate="tbTexto" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Texto" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbValor" Text="Valor:" HelpText="Valor" />
            <asp:TextBox runat="server" ID="tbValor" />
            <asp:RequiredFieldValidator ID="rfv_tbValor" runat="server" ControlToValidate="tbValor" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Valor" SetFocusOnError="true" />
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
