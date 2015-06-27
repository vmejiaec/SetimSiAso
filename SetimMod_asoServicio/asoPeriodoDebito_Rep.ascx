<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="asoPeriodoDebito_Rep.ascx.cs" Inherits="SetimMod_asoServicio.asoPeriodoDebito_Rep" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Label runat="server" ID="hola" Text="Hola"></asp:Label>

<br/>

<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1200px">
    <LocalReport ReportPath=".\DesktopModules\Setim\SetimMod_asoServicio\Report1.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>

<asp:ObjectDataSource
    ID="ObjectDataSource1"
    runat="server"
    SelectMethod="_0Sel"
    TypeName="SetimBasico.asoPeriodoDebitoControl">

</asp:ObjectDataSource>


