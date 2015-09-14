<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="asoPeriodoDebito_Edit.ascx.cs" Inherits="SetimMod_asoPeriodoDebito.asoPeriodoDebito_Edit" %>

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
        <div class="dnnFormItem" style="visibility: hidden">
            <dnn:label runat="server" id="lbId" text="Id:" helptext="Id" />
            <asp:TextBox runat="server" ID="tbId" Enabled="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbasoServicio_Id" text="Servicio_Id:" helptext="asoServicio_Id" />
            <asp:TextBox runat="server" ID="tbasoServicio_Id" Enabled="false" />
        </div>
        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbasoServicio_Nombre" text="Servicio_Nombre:" helptext="asoServicio_Nombre" />
            <asp:TextBox runat="server" ID="tbasoServicio_Nombre" Enabled="false" />
        </div>
        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbasoPeriodo_Id" text="Periodo_Id:" helptext="asoPeriodo_Id" />
            <asp:TextBox runat="server" ID="tbasoPeriodo_Id" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbasoPeriodo_Id" runat="server" ControlToValidate="tbasoPeriodo_Id" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoPeriodo_Id" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="lbasoPeriodo_Fecha" runat="server" cssclass="dnnFormLabel" associatedcontrolid="dnnDP_asoPeriodo_Fecha" text="Periodo_Fecha" />
            <asp:TextBox runat="server" ID="tb_asoPeriodo_Fecha" Enabled="true" />
        </div>

        <script type="text/javascript">
            $(function () {
                $("#<%= tb_asoPeriodo_Fecha.ClientID %>").autocomplete({
                    minLength: 2,
                    source: function (request, response) {
                        $.ajax({
                            type: "POST",
                            cache: false,
                            url: location.href,
                            dataType: "json",
                            data: ({ 'FUNCTION': 'GetPeriodosByPrefijo', 'param0': request.term }),
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
                        $("#<%= tb_asoPeriodo_Fecha.ClientID %>").val(ui.item.label);
                        return false;
                    },
                    select: function (event, ui) {
                        //$("#project").val(ui.item.label);
                        $("#<%= tbasoPeriodo_Id.ClientID %>").val(ui.item.value);
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

        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbasoSocio_Id" text="asoSocio_Id:" helptext="Socio_Id" />
            <asp:TextBox runat="server" ID="tbasoSocio_Id" Enabled="true" />
            <asp:RequiredFieldValidator ID="rfv_tbasoSocio_Id" runat="server" ControlToValidate="tbasoSocio_Id" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoSocio_Id" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbasoSocio_Nombre" text="asoSocio_Nombre:" helptext="Socio_Nombre" />
            <asp:TextBox runat="server" ID="tbasoSocio_Nombre" />
            <asp:RequiredFieldValidator ID="rfv_tbasoSocio_Nombre" runat="server" ControlToValidate="tbasoSocio_Nombre" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta asoSocio_Nombre" SetFocusOnError="true" />
        </div>

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
                            data: ({ 'FUNCTION': 'GetSociosByServicioPrefijo', 'param0': request.term }),
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
                        $("#<%= tbasoSocio_Id.ClientID %>").val(ui.item.value);
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

        <div class="dnnFormItem">
            <dnn:label id="lbValor" runat="server" text="Valor:" helptext="Valor" />
            <asp:TextBox runat="server" ID="tbValor" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Valor" runat="server" ControlToValidate="tbValor" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Valor" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="lbValor_Comision" runat="server" text="Valor_Comision:" helptext="Valor_Comision" />
            <asp:TextBox runat="server" ID="tbValor_Comision" CssClass="TextBox_Setim_Valor" />
            <asp:RequiredFieldValidator ID="rfv_Valor_Comision" runat="server" ControlToValidate="tbValor_Comision" CssClass="dnnFormMessage dnnFormError" Text="Requerido" ErrorMessage="Falta Valor_Comision" SetFocusOnError="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="lbEstado" runat="server" text="Estado:" />
            <asp:DropDownList runat="server" ID="ddlEstado" />
        </div>
        <div class="dnnFormItem">
            <dnn:label runat="server" id="lbDescripcion" text="Descripcion:" helptext="Descripcion" />
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
