﻿<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="asoSetimLista_Edit.ascx.cs" Inherits="SetimMod_asoSetimLista.asoSetimLista_Edit" %>

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
            <dnn:Label runat="server" ID="lbNombre" Text="Nombre:" HelpText="Nombre" />
            <asp:TextBox runat="server" ID="tbNombre" />
            <asp:RequiredFieldValidator ID="rfv_tbNombre" runat="server" ControlToValidate="tbNombre" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Nombre" SetFocusOnError="true" />
        </div>

        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbDescripcion" Text="Descripcion:" HelpText="Descripcion" />
            <asp:TextBox runat="server" ID="tbDescripcion" TextMode="MultiLine" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbDetalles" Text="Detalles:" HelpText="Detalles" />
            <asp:TextBox runat="server" ID="tbDetalles" />
            <asp:RequiredFieldValidator ID="rfv_tbDetalles" runat="server" ControlToValidate="tbDetalles" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Detalles" SetFocusOnError="true" />
        </div>
    </fieldset>

    <asp:ValidationSummary runat="server" ID="vsResumen" CssClass="dnnFormMessage dnnFormValidationSummary" />

</div>
<%--Botones --%>
<ul class="dnnActions dnnClear">
    <li><asp:LinkButton runat="server" ID="saveButton" CssClass="dnnPrimaryAction" OnClick="Guardar" Text="Guardar" /></li>
    <li><asp:LinkButton runat="server" ID="cancelButton" CssClass="dnnSecondaryAction" OnClick="Cancelar" Text="Cancelar"  CausesValidation="false" /></li>
</ul>
