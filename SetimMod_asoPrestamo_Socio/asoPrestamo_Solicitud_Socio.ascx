<%@ Control Language="C#" AutoEventWireup="true" 
    CodeBehind="asoPrestamo_Solicitud_Socio.ascx.cs" 
    Inherits="SetimMod_asoPrestamo_Socio.asoPrestamo_Solicitud_Socio" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%--Botones --%>
<ul class="dnnActions dnnClear">
    <li><asp:LinkButton runat="server" ID="btSalir" CssClass="dnnPrimaryAction" OnClick="Salir" Text="Salir" CausesValidation="false" /></li>
</ul>
<br/>
<rsweb:ReportViewer ID="rv_Reporte" runat="server" 
    Font-Names="Verdana" Font-Size="8pt" 
    WaitMessageFont-Names="Verdana" 
    WaitMessageFont-Size="14pt" Width="1200px">
    <LocalReport ReportPath=".\DesktopModules\Setim\SetimMod_asoPrestamo_Socio\asoPrestamo_Solicitud_Socio.rdlc">
    </LocalReport>
</rsweb:ReportViewer>