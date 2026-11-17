<%@ Page Title="Crystal Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="CrystalReport.aspx.cs" Inherits="CrystalReportPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="eyebrow">REPORTING</p>
    <h1>Placement Summary Report</h1>
    <p class="muted">Crystal Reports viewer for placement records.</p>
    <asp:Label ID="lblMessage" runat="server" CssClass="notice" />
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"
        AutoDataBind="true" ToolPanelView="None" HasCrystalLogo="false"
        HasExportButton="true" HasPrintButton="true" Width="100%" Height="700px" />
</asp:Content>
