<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="asoPrestamo_Edit.ascx.cs" Inherits="SetimMod_asoPrestamo.asoPrestamo_Edit" %>

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
            </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbasoSocio_Id" Text="Socio_Id:" HelpText="asoSocio_Id" />
            <asp:TextBox runat="server" ID="tbasoSocio_Id" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbasoSocio_Id" runat="server" ControlToValidate="tbasoSocio_Id" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoSocio_Id" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbasoSocio_Nombre" Text="Socio_Nombre:" HelpText="asoSocio_Nombre" />
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
            <dnn:Label ID="lbValor" runat="server" Text="Valor:" HelpText="Valor" />
            <asp:TextBox runat="server" ID="tbValor" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Valor" runat="server" ControlToValidate="tbValor" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Valor" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbTasa_Interes" runat="server" Text="Tasa_Interes:" HelpText="Tasa_Interes" />
            <asp:TextBox runat="server" ID="tbTasa_Interes" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Tasa_Interes" runat="server" ControlToValidate="tbTasa_Interes" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Tasa_Interes" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbNo_Periodos" Text="No_Periodos:" HelpText="No_Periodos" />
            <asp:TextBox runat="server" ID="tbNo_Periodos" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbNo_Periodos" runat="server" ControlToValidate="tbNo_Periodos" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta No_Periodos" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbEstado" runat="server" Text="Estado:" />
            <asp:DropDownList runat="server" ID="ddlEstado" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lbFecha_Solicitud" runat="server" CssClass="dnnFormLabel" AssociatedControlID="dnnDP_Fecha_Solicitud" Text="Fecha_Solicitud" />
            <dnn:DnnDatePicker runat="server" CssClass="dnnFormInput" ID="dnnDP_Fecha_Solicitud" />
            <asp:RequiredFieldValidator ID="rfv_dnnDP_Fecha_Solicitud" runat="server" ControlToValidate="dnnDP_Fecha_Solicitud" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Fecha_Solicitud" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbasoSocio_Id_Garante" Text="asoSocio_Id_Garante:" HelpText="asoSocio_Id_Garante" />
            <asp:TextBox runat="server" ID="tbasoSocio_Id_Garante" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbasoSocio_Id_Garante" runat="server" ControlToValidate="tbasoSocio_Id_Garante" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoSocio_Id_Garante" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbasoSocio_Nombre_Garante" Text="asoSocio_Nombre_Garante:" HelpText="asoSocio_Nombre_Garante" />
            <asp:TextBox runat="server" ID="tbasoSocio_Nombre_Garante" />
            <asp:RequiredFieldValidator ID="rfv_tbasoSocio_Nombre_Garante" runat="server" ControlToValidate="tbasoSocio_Nombre_Garante" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoSocio_Nombre_Garante" SetFocusOnError="true" />
        </div>
<%--Inicio Autocompletar--%>
    <script type="text/javascript">
        $(function () {
            $("#<%= tbasoSocio_Nombre_Garante.ClientID %>").autocomplete({
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
                    $("#<%= tbasoSocio_Nombre_Garante.ClientID %>").val(ui.item.label);
                    return false;
                },
                select: function (event, ui) {
                    //$("#project").val(ui.item.label);
                    $("#<%= tbasoSocio_Id_Garante.ClientID %>").val(ui.item.value);
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
            <dnn:Label runat="server" ID="lbDescripcion" Text="Descripcion:" HelpText="Descripcion" />
            <asp:TextBox runat="server" ID="tbDescripcion" TextMode="MultiLine" />
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
