<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="asoPeriodoDebito_Archivo.ascx.cs" Inherits="SetimMod_asoServicio.asoPeriodoDebito_Archivo" %>

<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<%@ Register tagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>

<%@ Register tagPrefix="dnn" tagName="UrlControl" Src="~/controls/URLControl.ascx" %>

<asp:Label runat="server" ID="lbTitulo" ForeColor="#3399FF" Font-Italic="true" Font-Bold="true"></asp:Label>

<ul class="dnnActions dnnClear">
    <li><asp:LinkButton runat="server" ID="btProcesarArchivo" Text="Procesar archivo" CssClass="dnnPrimaryAction confirm" OnClick="btProcesarArchivo_OnClick" /></li>
</ul>

<dnn:UrlControl runat="server" ID="FileUpload" 
                ShowLog="false"
                ShowNewWindow="false"
                ShowTrack="false"
                ShowImages="false"
                ShowNone="false"
                ShowTabs="false"
                ShowUrls="false"
                ShowUsers="false"
                ShowFiles="false"
                ShowUpLoad="true"  />

<dnn:DnnFilePicker runat="server" ID="FilePicker" FileFilter="xlsx" Height="150px" Width="400px"  />