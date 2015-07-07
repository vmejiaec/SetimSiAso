<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="asoPeriodoCuota_ByPrestamo SocioTabla_Rep.ascx.cs" 
    Inherits="SetimMod_asoPrestamo.asoPeriodoCuota_ByPrestamo_SocioTabla_Rep" %>

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
    <LocalReport ReportPath=".\DesktopModules\Setim\SetimMod_asoPrestamo_Socio\asoPeriodoCuota_ByPrestamo_SocioTabla_Rep.rdlc">
    </LocalReport>
</rsweb:ReportViewer>