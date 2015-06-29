<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="asoPeriodoDebito_Archivo.ascx.cs" Inherits="SetimMod_asoServicio.asoPeriodoDebito_Archivo" %>

<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<%@ Register tagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>

<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="FilePickerUploader" Src="~/controls/FilePickerUploader.ascx" %>

<asp:Label runat="server" ID="lbTitulo" ForeColor="#3399FF" Font-Italic="true" Font-Bold="true"></asp:Label>

<ul class="dnnActions dnnClear">
    <li><asp:LinkButton runat="server" ID="btProcesarArchivo" Text="Procesar archivo" CssClass="dnnPrimaryAction confirm" OnClick="btProcesarArchivo_OnClick" /></li>
    <li><asp:LinkButton runat="server" ID="btSalir" CssClass="dnnSecondaryAction" OnClick="Salir" Text="Salir" CausesValidation="false" /></li>
</ul>

<div id="dnnUsers" class="dnnForm dnnClear">
    <fieldset>
        <legend></legend>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lbId" Text="Archivo:" HelpText="Archivo para procesar" />
            <dnn:DnnFilePicker  runat="server" ID="fpArchivo" FileFilter="xls"   />
        </div>
    </fieldset>
</div>


    
    
