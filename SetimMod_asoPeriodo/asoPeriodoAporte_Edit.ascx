<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="asoPeriodoAporte_Edit.ascx.cs" Inherits="SetimMod_asoPeriodoAporte.asoPeriodoAporte_Edit" %>

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
            <dnn:label id="lbasoPeriodo_Fecha" runat="server" cssclass="dnnFormLabel" associatedcontrolid="dnnDP_asoPeriodo_Fecha" text="asoPeriodo_Fecha" />
            <asp:TextBox runat="server" ID="tbasoPeriodo_Fecha" Enabled="false" />
        </div>
        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbasoSocio_Id" text="Socio_Id:" helptext="asoSocio_Id" />
            <asp:TextBox runat="server" ID="tbasoSocio_Id" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbasoSocio_Id" runat="server" ControlToValidate="tbasoSocio_Id" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoSocio_Id" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbasoSocio_Nombre" text="Socio_Nombre:" helptext="asoSocio_Nombre" />
            <asp:TextBox runat="server" ID="tbasoSocio_Nombre" />
            <asp:RequiredFieldValidator ID="rfv_tbasoSocio_Nombre" runat="server" ControlToValidate="tbasoSocio_Nombre" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoSocio_Nombre" SetFocusOnError="true" />
        </div>
<%--Inicio Autocompletar--%>
    <script type="text/javascript">
        $(function () {
            $("#<%= tbasoSocio_Nombre.ClientID %>").autocomplete({
                minLength: 2,
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        cache: false,
                        url: location.href,
                        dataType: "json",
                        data: ({ 'FUNCTION': 'GetSociosActivosByPrefijo', 'param0': request.term }),
                        success: function (data) {
                            response($.map(data, function (item) {
                                return {
                                    value: item.valor,
                                    label: item.etiqueta,
                                    desc: item.desc
                                }
                            }))
                        },
                        beforeSend: function (xhr) { xhr.setRequestHeader("X-SETIM-REQUEST", "TRUE"); },// Para atajarlo en el Load de la página
                        error: function (xhr, status, error) { alert(error); },
                        failure: function (response) { alert(response.responseText); }
                    });
                },
                focus: function (event, ui) {
                    $("#<%= tbasoSocio_Nombre.ClientID %>").val(ui.item.label);
                    return false;
                },
                select: function (event, ui) {
                    //$("#project").val(ui.item.label);
                    $("#<%= tbasoSocio_Id.ClientID %>").val(ui.item.value);
                    //$("#autocomplete-description").html(ui.item.desc);
                    return false;
                },
                open: function () {
                    $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
                },
                close: function () {
                    $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
                }
            });
        });
    </script>
<%--Fin Autocompletar--%>

        <div class="dnnFormItem">
            <dnn:label id="lbTipo" runat="server" text="Tipo:" />
            <asp:DropDownList runat="server" ID="ddlTipo" />
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
            <dnn:label id="lbValor_Accion" runat="server" text="Valor_Accion:" helptext="Valor_Accion" />
            <asp:TextBox runat="server" ID="tbValor_Accion" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Valor_Accion" runat="server" ControlToValidate="tbValor_Accion" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Valor_Accion" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="lbValor_Ahorro" runat="server" text="Valor_Ahorro:" helptext="Valor_Ahorro" />
            <asp:TextBox runat="server" ID="tbValor_Ahorro" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Valor_Ahorro" runat="server" ControlToValidate="tbValor_Ahorro" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Valor_Ahorro" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="lbValor_Voluntario" runat="server" text="Valor_Voluntario:" helptext="Valor_Voluntario" />
            <asp:TextBox runat="server" ID="tbValor_Voluntario" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Valor_Voluntario" runat="server" ControlToValidate="tbValor_Voluntario" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Valor_Voluntario" SetFocusOnError="true" />
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
