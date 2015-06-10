<%@ Control Language="C#" AutoEventWireup="true" 
    CodeBehind="asoSetimLista_View.ascx.cs" 
    Inherits="SetimMod_asoSetimLista.asoSetimLista_View" %>

<%@ Register Assembly="DotNetNuke.WebControls" Namespace="DotNetNuke.UI.WebControls" TagPrefix="DNN" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src= "~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<script src="/Resources/Shared/scripts/autoNumeric-2.0-BETA.js" type="text/javascript"></script>

<%--Funcion para poner el formato numérico a los campos de Valor--%>
<script type="text/javascript">
    jQuery(function ($) {
        $('input[class=TextBox_Setim_Valor]').autoNumeric('init', { aSep: '.', aDec: ',' });
    });
</script>

<asp:TextBox runat="server" ID="tbValor_Accion" CssClass="TextBox_Setim_Valor" />