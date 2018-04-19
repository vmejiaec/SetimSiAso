<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="asoPeriodoDebitoGen_Rep.ascx.cs" Inherits="SetimMod_asoServicio.asoPeriodoDebitoGen_Rep" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<br/>
<rsweb:ReportViewer ID="rv_Reporte" runat="server" 
    Font-Names="Verdana" Font-Size="8pt" 
    WaitMessageFont-Names="Verdana" 
    WaitMessageFont-Size="14pt" Width="1200px">
    <LocalReport ReportPath=".\DesktopModules\Setim\SetimMod_asoServicio\asoPeriodoDebitoGen_Rep.rdlc">
    </LocalReport>
</rsweb:ReportViewer>