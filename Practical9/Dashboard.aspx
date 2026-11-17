<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-heading">
        <div><p class="eyebrow">PLACEMENT OVERVIEW</p><h1>Student Placement Dashboard</h1>
        <p class="muted">Track student placement status, companies and package details.</p></div>
        <a class="report-link" href="CrystalReport.aspx">View Crystal Report →</a>
    </div>
    <div class="stats">
        <div class="stat"><span>Total Students</span><strong><asp:Label ID="lblTotal" runat="server" /></strong></div>
        <div class="stat"><span>Placed Students</span><strong><asp:Label ID="lblPlaced" runat="server" /></strong></div>
        <div class="stat"><span>Placement Rate</span><strong><asp:Label ID="lblRate" runat="server" /></strong></div>
        <div class="stat"><span>Average Package</span><strong><asp:Label ID="lblAverage" runat="server" /></strong></div>
    </div>
    <section class="panel">
        <div class="panel-head"><div><h2>Placement Records</h2><p class="muted">Filter records by department.</p></div>
            <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" CssClass="select" />
        </div>
        <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False"
            DataKeyNames="StudentId" CssClass="data-grid" GridLines="None"
            OnSelectedIndexChanged="gvStudents_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="View" />
                <asp:BoundField DataField="StudentId" HeaderText="ID" />
                <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                <asp:BoundField DataField="Department" HeaderText="Department" />
                <asp:BoundField DataField="CompanyName" HeaderText="Company" />
                <asp:BoundField DataField="PackageLPA" HeaderText="Package (LPA)" DataFormatString="{0:0.00}" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
            </Columns>
            <EmptyDataTemplate>No placement records found.</EmptyDataTemplate>
        </asp:GridView>
    </section>
    <section class="panel details-panel">
        <h2>Student Details</h2>
        <asp:DetailsView ID="dvStudent" runat="server" AutoGenerateRows="true" CssClass="details"
            GridLines="None" EmptyDataText="Select a student using the View link above." />
    </section>
</asp:Content>
