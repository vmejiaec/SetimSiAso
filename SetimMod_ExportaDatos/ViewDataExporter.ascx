<%@ Control Language="C#" Inherits="forDNN.Modules.DataExporter.ViewDataExporter"
    AutoEventWireup="true" CodeBehind="ViewDataExporter.ascx.cs" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>

<script type="text/javascript">
    function sourceChanged()
    {
        var objSource = document.getElementById("<%=ddlSource.ClientID%>");
        var objTables = document.getElementById("<%=ddlTables.ClientID%>");
        var objViews = document.getElementById("<%=ddlViews.ClientID%>");
        var objQuery = document.getElementById("<%=tbQuery.ClientID%>");

        objTables.style["display"] = "none";
        objViews.style["display"] = "none";
        objQuery.style["display"] = "none";

        switch (objSource.value)
        {
            case "0":
                objTables.style["display"] = "block";
                break;
            case "1":
                objViews.style["display"] = "block";
                break;
            case "2":
                objQuery.style["display"] = "block";
                break;
        }
    }
</script>

<div class="dnnClear dnnForm">
    <fieldset>
        <div class="dnnFormItem" style="visibility:hidden">
            <dnn:Label runat="server" ID="lblSourceType" CssClass="SubHead" resourcekey="SourceType"></dnn:Label>
            <asp:DropDownList runat="server" ID="ddlSource" CssClass="DropDownClass">
                <%--<asp:ListItem Selected="True" Value="0" resourcekey="Tables"></asp:ListItem>--%>
                <asp:ListItem Value="1" resourcekey="Views"></asp:ListItem>
                <%--<asp:ListItem Value="2" resourcekey="Query"></asp:ListItem>--%>
            </asp:DropDownList>
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lblSource" CssClass="SubHead" resourcekey="Source"></dnn:Label>
            <asp:DropDownList runat="server" ID="ddlTables" CssClass="DropDownClass">
            </asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddlViews" Style="display: none;" CssClass="DropDownClass">
            </asp:DropDownList>
            <asp:TextBox ID="tbQuery" runat="server" TextMode="MultiLine" CssClass="QueryClass"
                Style="display: none;"></asp:TextBox>
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="ExportType" CssClass="SubHead" resourcekey="ExportType"></dnn:Label>
            <asp:RadioButtonList runat="server" ID="rblExportType" RepeatDirection="Horizontal"
                RepeatColumns="3" RepeatLayout="Table">
                <asp:ListItem Selected="True" Value="0" resourcekey="Excel"></asp:ListItem>
                <asp:ListItem Value="1" resourcekey="XML"></asp:ListItem>
                <asp:ListItem Value="2" resourcekey="CSV"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </fieldset>
    <asp:LinkButton ID="btnExport" runat="server" CssClass="dnnPrimaryAction" resourcekey="Export"
        OnClick="btnExport_Click"></asp:LinkButton>
</div>

<asp:Label ID="lblIcon" runat="server"></asp:Label>